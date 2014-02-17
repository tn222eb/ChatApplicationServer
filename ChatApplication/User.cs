using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApplication
{
    public class User
    {

        private string _ipAddress;
        public string IPAddress
        {
            get { return this._ipAddress; }
            set { this._ipAddress = value; }
        }

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

        private string _chatroom;
        public string Chatroom
        {
            get { return this._chatroom; }
            set { this._chatroom = value; }
        }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public User(TcpClient _client)
        {
            this._client = _client;
            this._ipAddress = _client.Client.RemoteEndPoint.ToString();
        }

        public User(string _ip)
        {
            this._ipAddress = _ip;
        }

        public void CloseUserConnection()
        {
            this._networkStream.Close();
            this._client.Close();
        }

        public bool Equals(User _user) //******
        {
            if (_user == null)
                return false;
            return this._ipAddress == _user.IPAddress;
        }

    }
}
