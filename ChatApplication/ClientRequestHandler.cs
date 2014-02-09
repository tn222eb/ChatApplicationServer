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
        User _user;

        public ClientRequestHandler(User _clientConnected)
        {
            this._user = _clientConnected;
        }
        public void StartClient()
        {
            WaitForRequest();
        }

        public void WaitForRequest()
        {
            int bufferSize = _user.Client.ReceiveBufferSize;
            byte[] buffer = new byte[bufferSize];
            Console.WriteLine("Waiting for request");
            _user.NetworkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
        }

        private void ReadCallback(IAsyncResult _result)
        {
            NetworkStream networkStream = _user.NetworkStream;
            try
            {
                int read = networkStream.EndRead(_result);
                if (read == 0)
                {
                    _user.CloseUserConnection();
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
            _user.CloseUserConnection();
        }
    }
}
