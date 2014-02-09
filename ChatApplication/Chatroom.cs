using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApplication
{
    public class Chatroom
    {
        private Queue<User> _users;

        public Chatroom()
        {

        }


    }

    public class User
    {

        private TcpClient _client;
        public TcpClient Client
        {
            get { return this._client; }
            set { this._client = value; this._networkStream = this._client.GetStream(); }
        }

        private NetworkStream _networkStream;
        public NetworkStream NetworkStream
        {
            get { return this._networkStream; }
            set { this._networkStream = value; }
        }

        public User(TcpClient _client)
        {
            this.Client = _client;
        }

        public void CloseUserConnection()
        {
            this._networkStream.Close();
            this._client.Close();
        }

    }
}
