﻿using System;
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
            HandleClientConnections();
        }

        private static void HandleClientConnections()
        {
            new Task(() =>
            {
                try
                {
                    while (_isListening)
                    {
                        Console.WriteLine("Waiting on connection");

                        TcpClient client = _listener.AcceptTcpClient();
                        Console.WriteLine("Connected!");
                        ReadClientData(client);
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
            }).Start();
        }

        private static void ReadClientData(TcpClient client)
        {
            new Task(() =>
            {
                try
                {
                    User user = new User(client);
                    NetworkStream networkStream = user.NetworkStream;
                    int i;
                    Byte[] bytes = new Byte[256];
                    String data = null;
                    while ((i = networkStream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        networkStream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }
                    // Shutdown and end connection
                    client.Close();
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }

            }).Start();
        }

        public static void StopListener()
        {
            _listener.Stop();
        }

    }
}
