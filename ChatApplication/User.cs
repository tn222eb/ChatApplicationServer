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
            this.Client = _client;
        }

        public User(string _name)
        {
            this._name = _name;
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
            return this._name == _user.Name;
        }

    }
}
