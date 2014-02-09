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

        private static void ListenForClientConnection()
        {
            _listener.BeginAcceptTcpClient(new AsyncCallback(OnClientConnectionCallback), new object()); //Asynchronous way to handle incoming clients
        }

        private static void OnClientConnectionCallback(IAsyncResult _ar)
        {
            try
            {
                Console.WriteLine("Connected!");
                TcpClient clientSocket = default(TcpClient);
                clientSocket = _listener.EndAcceptTcpClient(_ar);
                Console.WriteLine("Connected!");
                ClientRequestHandler clientReq = new ClientRequestHandler(clientSocket); // Handle each connection
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
