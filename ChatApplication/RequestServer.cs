using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApplication
{
    public class RequestServer
    {
        private static TcpListener _listener;

        private static bool _isListening = false;
        public static bool IsListening { get { return _isListening; } }

        public static void StartListener(string _ip, int _port)
        {
            IPAddress ip = IPAddress.Parse(_ip);
            IPEndPoint localServerIp = new IPEndPoint(ip, _port);
            _listener = new TcpListener(localServerIp);
            _listener.Start();
            _isListening = true;
            Console.WriteLine("Starting Server on " + _ip + ":" + _port);
            ListenForClientConnection();

        }

        private static async void ListenForClientConnection()
        {
            while (_isListening)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    OnClientConnectionCallback(client);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Stopped Listening for Clients.");
                }
            }
        }

        private static void OnClientConnectionCallback(TcpClient client)
        {
            try
            {
                TcpClient clientSocket = (TcpClient) client;
                User user = new User(clientSocket);
                Console.WriteLine("Connected!");
                ClientRequestHandler clientReq = new ClientRequestHandler(user); // Handle each connection
                clientReq.StartClient();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void StopListener()
        {
            _listener.Stop();
            _isListening = false;
            Console.WriteLine("Stopping Server");
        }
    }
}
