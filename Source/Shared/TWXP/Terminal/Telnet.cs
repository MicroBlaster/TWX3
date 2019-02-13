using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TWX.Terminal
{
    internal class TelnetClient
    {
        private NetworkStream stream;

        private bool active;
        private bool ansiDetected;

        public event EventHandler<EventArgs> Initialized = delegate { };
        public event EventHandler<EventArgs> Receive = delegate { };
        public event EventHandler<EventArgs> Disconnect = delegate { };

        public IPEndPoint RemoteEP { get; private set; }
        public IPEndPoint LocalEP { get; private set; }
        public string ReverseDNS { get; private set; }

        public TelnetClient(TcpClient tcpClient)
        {
            stream = tcpClient.GetStream();

            stream.ReadTimeout = 500;

            active = false;
            ansiDetected = false;

            // Initialize the connection.
            Initialize();
        }

        private async void Initialize()
        {
            byte[] readBuffer = new byte[4096];

            // Get the local and remote endpoints from the stream.
            PropertyInfo socket = stream.GetType().GetProperty("Socket", BindingFlags.NonPublic | BindingFlags.Instance);
            RemoteEP = (IPEndPoint)((Socket)socket.GetValue(stream, null)).RemoteEndPoint;
            LocalEP = (IPEndPoint)((Socket)socket.GetValue(stream, null)).LocalEndPoint;

            // Start reverse DNS lookup using an asynchronous task.
            Task<IPHostEntry> rdnsTask = Dns.GetHostEntryAsync(IPAddress.Parse(RemoteEP.Address.ToString()));

            // Send ASCII FF + BS and ANSI Clear Screen 
            Write("\u000c\u0008\u001B[2J\r");

            // Send Telnet handshake
            byte[] telnet = {
                    255, 251, 1,    // Telnet (IAC)(Will)(ECHO) - Will Echo
                    255, 251, 3 };  // Telnet (IAC)(Will)(SGA)  - Will Supress Go Ahead
            stream.Write(telnet, 0, telnet.Length);

            // Send Banner and Initializing
            //Write("TWX Proxy 3" + "\r\n\u001B[0;32m  Initializing...");
            Write("TWX Proxy 3 Initializing...");

            // Send ANSI detect.
            byte[] ansi = { 27, 91, 54, 110 }; // ANSI (ESC)[6n - Request Cursor Position
            stream.Write(ansi, 0, ansi.Length);
            await Task.Delay(200);

            try
            {
                // Read the response.
                stream.Read(readBuffer, 0, 1024);

                // Check if response contains an ANSI excape sequence.
                // ansiDetected = Encoding.UTF8.GetString(readBuffer).Contains("\u001B[");
                ansiDetected = Regex.IsMatch(Encoding.UTF8.GetString(readBuffer), "\\x1b[[0-9;]*R");
            }
            catch (Exception)
            {

                // TODO: Log ANSI detection error.
            }


            // TODO: skip ReverseDNS if localhost or local interface
            // Get the reverse DNS result.
            //await Task.Delay(2000);
            ReverseDNS = "UNKNOWN";
            try
            {
                rdnsTask.Wait();
                ReverseDNS = rdnsTask.Result.HostName;
            }
            catch (Exception)
            {
                // TODO: Log reverse DNS error.
            }

            // Send initialized event
            Initialized(this, new EventArgs());
        }

        public void Write(String text)
        {
            //Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //byte[] buffer = Encoding.GetEncoding("IBM437").GetBytes(text);
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);
        }

    }
}
