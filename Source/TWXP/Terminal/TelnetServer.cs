using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TWXP
{
    public class TelnetServer
    {

        public string Address { get; set; }
        public IPAddress IP { get; private set; }
        public int Port { get; set; }

        //public bool Connected { get; private set; }
        //public bool Connecting { get; private set; }
        //public bool Disconnecting { get; private set; }

        private bool active;

        public event EventHandler<EventArgs> Receive = delegate { };
        public event EventHandler<EventArgs> Disconnected = delegate { };

        public IPEndPoint RemoteEP { get; private set; }
        public IPEndPoint LocalEP { get; private set; }

        private TcpClient tcpClient;
        private NetworkStream stream;
        private MemoryStream output = new MemoryStream();

        public TelnetServer()
        {
            active = false;
            //tcpClient = new TcpClient();
        }

        public void Connect(string address, int port = 2002)
        {
            Address = address;
            Port = port;

            try
            {
                // Set the port if specified in address.
                if (address.Contains(":"))
                {
                    String[] s = address.Split(':');
                    Address = s[0];
                    Port = int.Parse(s[1]);
                }
            }
            catch { }

            Connect();
        }

        private async void Connect()
        {
            ///if (tcpClient != null && tcpClient.Connected) return;
            if (active) return;
            active = true;

            if (tcpClient != null)
            {
                tcpClient.Client.Close();
                tcpClient.Close();
            }
            tcpClient = new TcpClient();

            tcpClient.Connect(Address, Port);
            if (tcpClient.Connected)
            {
                // Get the underlying stream from the client.
                using (stream = tcpClient.GetStream())
                {
                    byte[] resp = new byte[2048];
                    int bytes;

                    // Get the local and remote endpoints from the stream.
                    PropertyInfo socket = stream.GetType().GetProperty("Socket", BindingFlags.NonPublic | BindingFlags.Instance);
                    RemoteEP = (IPEndPoint)((Socket)socket.GetValue(stream, null)).RemoteEndPoint;
                    LocalEP = (IPEndPoint)((Socket)socket.GetValue(stream, null)).LocalEndPoint;

                    // Send Telnet handshake
                    byte[] telnet = {
                    255, 251, 1,    // Telnet (IAC)(Will)(ECHO) - Will Echo
                    255, 251, 3 };  // Telnet (IAC)(Will)(SGA)  - Will Supress Go Ahead
                    stream.Write(telnet, 0, telnet.Length);


                    stream.ReadTimeout = 500;

                    do
                    {
                        try
                        {
                            bytes = stream.Read(resp, 0, resp.Length);

                            if (bytes == 0)
                            {
                                // No Bytes Received, send Telnet (IAC)(DO)(AYT) - Are you there?
                                stream.Write(new byte[]{ 255, 253, 246 }, 0 ,3); 
                            }
                            else
                            {
                                output.Write(resp, 0, bytes);
                            }
                        }
                        catch { }

                        if(!stream.DataAvailable && output.Length > 0)
                        {
                            StringBuilder control = new StringBuilder();
                            StringBuilder text = new StringBuilder();

                            foreach (char c in Encoding.ASCII.GetString(output.ToArray()))
                            {
                                if (c < 32 && c != 13 && c != 10 && c != 27) control.Append(c);
                                else text.Append(c);
                            }

                            //todo: process control characters

                            // Send receive event
                            Receive(text.ToString(), new EventArgs());
                            output.SetLength(0);
                        }

                        await Task.Delay(200);

                    } while (active && tcpClient.Connected);

                    active = false;
                    tcpClient.Client.Close();
                    tcpClient.Close();

                    // Send disconnect event
                    Disconnected(this, new EventArgs());

                    //tcpClient.Close();
                    //tcpClient.Dispose();
                    //tcpClient.Client.Disconnect(true);
                }
            }
        }

        public void Write(String text)
        {
            if (tcpClient.Connected && stream != null)
            {
                //Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                //byte[] buffer = Encoding.GetEncoding("IBM437").GetBytes(text);
                byte[] buffer = Encoding.ASCII.GetBytes(text);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        public void Disconnect()
        {
            active = false;
            //tcpClient.Client.Disconnect(true);
        }
    }
}
