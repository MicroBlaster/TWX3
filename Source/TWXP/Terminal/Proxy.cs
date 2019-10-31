using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TWXP
{
    public class Proxy
    {
        const int DEFAULT_PORT = 2300;

        public event EventHandler<EventArgs> Connected = delegate { };

        public string ProxyAddress { get; set; }
        public IPAddress ProxyIP { get; private set; }
        public int ProxyPort { get; set; }

        public int ListenPort { get; set; }

        private bool active;
        private TcpListener tcpListener;

        internal List<TelnetClient> Clients { get; private set; }
        public Scripts Scripts { get; private set; }

        
        /// <summary>
        /// Initalize a proxy without any parameters.
        /// </summary>
        public Proxy()
        {
            active = false;
            ProxyAddress = "";
            ProxyIP = IPAddress.Any;
            ProxyPort = DEFAULT_PORT;

            Clients = new List<TelnetClient>();
            Scripts = new Scripts(this);
        }

        /// <summary>
        /// Initialize a proxy with ProxyAddress defined
        /// </summary>
        /// <param name="Address"></param>
        public Proxy(String Address)
        {
            active = false;
            ProxyAddress = Address;
            ProxyIP = IPAddress.Any;
            ProxyPort = DEFAULT_PORT;
        }

        /// <summary>
        /// Initialize a Proxy with Proxy IP and Port defined
        /// </summary>
        /// <param name="IP">Specifies the IP Address to bind for the TCP listener.</param>
        /// <param name="Port">Specifies the Port to bind for the TCP listener.</param>
        public Proxy(IPAddress IP, int Port)
        {
            active = false;
            ProxyAddress = IP + ":" + Port;
            ProxyIP = IP;
            ProxyPort = Port;
            ProxyAddress = null;
        }

        public async Task StartAsync()
        {
            if (active == true) return;
            else active = true;

            if (tcpListener != null)
            {
                tcpListener.Start();
                return;
            }

            if (!string.IsNullOrEmpty(ProxyAddress))
            {
                try
                {
                    // Set the porrt if specified in ProxyAddress.
                    if (ProxyAddress.Contains(":"))
                    {
                        String[] s = ProxyAddress.Split(':');
                        ProxyAddress = s[0];
                        ProxyPort = int.Parse(s[1]);
                    }

                    // Resolve host binding from ProxyAddress
                    IPHostEntry ipHost = await Dns.GetHostEntryAsync(ProxyAddress);
                    ProxyIP = ipHost.AddressList[1];
                }
                catch { }
            }

            try
            {
                tcpListener = new TcpListener(ProxyIP, ProxyPort);
                tcpListener.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n \n*** Error *** Unable to open TCP listener. Socket returned error message:\n{0}", e.Message);
                //Environment.Exit(1);

            }

            await HandleConnectionsAsync(tcpListener);

            tcpListener.Stop();
        }

        private async Task HandleConnectionsAsync(TcpListener listener)
        {
            while (active)
            {
                // Wait for connections.
                TelnetClient client = new TelnetClient(await listener.AcceptTcpClientAsync());

                // Add the client to the list of clients
                Clients.Add(client);

                // Raise client connected event.
                //Connected(client, new EventArgs());
                ClientConnected(client);

                //Handle New connection
            }
        }

        private void ClientConnected(TelnetClient client)
        {
            // Send ASCII FF + BS and ANSI Clear Screen + Banner
            client.Write("\u000c\u0008\u001B[2J\r\u001B[0;33mTWX Proxy 3 - Version 3.1944a Alpha - Please do not distribute.\n\r\n\r");

            // Send Greeting
            client.Write(String.Format("\u001B[1;31mConnection accepted from {0}({1})\n\r\n\r",client.RemoteEP,client.ReverseDNS));
        }

        public void Pause()
        {
            tcpListener.Stop();
        }

        public void Resume()
        {
            tcpListener.Start();
        }

        public void Stop()
        {
            active = false;
        }

        public void Connect()
        {

        }

        public void Echo(string s)
        {
            foreach(TelnetClient c in Clients)
            {
                c.Write(s.Replace("*", "\r\n"));
            }
        }
    }
}
