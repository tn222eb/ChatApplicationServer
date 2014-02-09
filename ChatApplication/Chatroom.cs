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
        private string _roomName;
        public string RoomName
        {
            get { return this._roomName; }
            set { this._roomName = value; }
        }

        private List<User> _users;

        public Chatroom(string _roomName)
        {
            this._roomName = _roomName;
            _users = new List<User>();
        }

        public Chatroom()
        {

        }

        //Adding User
        public void AddUser(User _user)
        {
            //Checking if User is already in chatroom
            bool isInChatroom = SearchUser(_user) != -1;
            if (!isInChatroom)
                this._users.Add(_user);
        }

        //Returns index of user and -1 otherwise
        public int SearchUser(User _user)
        {
            for (int i = 0; i < _users.Count; ++i)
            {
                bool isInChatroom = this._users.ElementAt(i).Equals(_user);
                // Already in chatroom!
                if (isInChatroom)
                    return i;
            }
            return -1;
        }

        public int SearchUserWithName(string _name) //******
        {
            User user = new User(_name);
            return SearchUser(user);
        }

        //Removes User
        public void RemoveUser(User _user)
        {
            int index = SearchUser(_user);
            bool isInChatroom = index != -1;
            RemoveSearchedUser(isInChatroom, index);
        }

        public void RemoveUserWithName(string _name) //******
        {
            User user = new User(_name);
            int index = SearchUser(user);
            bool isInChatroom = index != -1;
            RemoveSearchedUser(isInChatroom, index);
        }

        private void RemoveSearchedUser(bool _isInChatroom, int _index)
        {
            if (_isInChatroom)
            {
                _users.ElementAt(_index).CloseUserConnection(); //Close the connection with server
                this._users.RemoveAt(_index);
            }
        }

        public User[] GetUsers()
        {
            return _users.ToArray();
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
