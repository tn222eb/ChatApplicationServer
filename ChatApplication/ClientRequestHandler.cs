using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApplication
{
    public class ClientRequestHandler
    {
        TcpClient _clientSocket;
        NetworkStream _networkStream = null;

        public ClientRequestHandler(TcpClient _clientConnected)
        {
            this._clientSocket = _clientConnected;
        }
        public void StartClient()
        {
            _networkStream = _clientSocket.GetStream();
            WaitForRequest();
        }

        public void WaitForRequest()
        {
            int bufferSize = _clientSocket.ReceiveBufferSize;
            byte[] buffer = new byte[bufferSize];
            Console.WriteLine("Waiting for request");
            _networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
        }

        private void ReadCallback(IAsyncResult _result)
        {
            NetworkStream networkStream = _clientSocket.GetStream();
            try
            {
                int read = networkStream.EndRead(_result);
                if (read == 0)
                {
                    _networkStream.Close();
                    _clientSocket.Close();
                    return;
                }

                byte[] buffer = _result.AsyncState as byte[];
                string data = Encoding.Default.GetString(buffer, 0, read);
                Console.WriteLine(data);
                //do the job with the data here
                //send the data back to client.
                Byte[] sendBytes = Encoding.ASCII.GetBytes("Processed " + data);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();
            }
            catch (Exception e)
            {
                throw e;
            }

            this.WaitForRequest();
        }
    }
}
