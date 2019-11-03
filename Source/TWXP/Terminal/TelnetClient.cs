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
    internal class TelnetClient
    {
        public event EventHandler<EventArgs> Initialized = delegate { };
        public event EventHandler<EventArgs> Receive = delegate { };
        public event EventHandler<EventArgs> Disconnected = delegate { };

        public IPEndPoint RemoteEP { get; private set; }
        public IPEndPoint LocalEP { get; private set; }
        public string ReverseDNS { get; private set; }

        private TcpClient tcpClient;
        private NetworkStream stream;
        private MemoryStream output = new MemoryStream();

        private bool active;
        private bool ansiDetected;

        public TelnetClient(TcpClient tcpclient)
        {
            tcpClient = tcpclient;


            active = true;
            ansiDetected = false;

            // Initialize the connection.
            Initialize();
        }

        private async void Initialize()
        {
            if (tcpClient.Connected)
            {
                // Get the underlying stream from the client.
                using (stream = tcpClient.GetStream())
                {
                    byte[] resp = new byte[4096];
                    int bytes;

                    stream.ReadTimeout = 500;

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
                        //todo: this needs to timeout
                        // Read the response.
                        stream.Read(resp, 0, 1024);

                        // Check if response contains an ANSI excape sequence.
                        // ansiDetected = Encoding.UTF8.GetString(readBuffer).Contains("\u001B[");
                        ansiDetected = Regex.IsMatch(Encoding.UTF8.GetString(resp), "\\x1b[[0-9;]*R");
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

                        await Task.Delay(200);

                        if (!stream.DataAvailable && output.Length > 0)
                        {
                            // Send receive event
                            Receive(Encoding.ASCII.GetString(output.ToArray()), new EventArgs());
                            output.SetLength(0);
                        }
                    } while (tcpClient.Connected);

                    // Send disconnect event
                    Disconnected(this, new EventArgs());
                }
            }
        }

        public void Write(String text)
        {
            //StringBuilder output = new StringBuilder();

            if (tcpClient.Connected && stream != null)
            {
                //foreach (char c in text)
                //{
                //    if (c > 31) output.Append(c);
                //}

                //Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                //byte[] buffer = Encoding.GetEncoding("IBM437").GetBytes(text);
                byte[] buffer = Encoding.ASCII.GetBytes(text);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

    }
}
