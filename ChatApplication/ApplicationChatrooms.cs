using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApplication
{
    public class ApplicationChatrooms
    {

        private static ApplicationChatrooms _instance = new ApplicationChatrooms();
        public static ApplicationChatrooms GetInstance
        {
            get { return _instance; }
        }

        private Dictionary<string, Chatroom> _chatrooms;

        private ApplicationChatrooms()
        {
            _chatrooms = new Dictionary<string, Chatroom>();
        }

        public void AddChatroomWithKey(string _name, Chatroom _chatroom)
        {
            _chatrooms.Add(_name, _chatroom);
        }

        public void RemoveChatroomWithKey(string _name)
        {
            _chatrooms.Remove(_name);
        }

        public Chatroom SearchChatroomWithKey(string _name)
        {
            for (int i = 0; i < _chatrooms.Count; ++i)
            {
                bool isAChatroom = _chatrooms.ElementAt(i).Key == _name;
                if (isAChatroom)
                    return _chatrooms.ElementAt(i).Value;
            }
            return null;
        }

        public Chatroom[] GetChatroomArray()
        {
            return this._chatrooms.Values.ToArray();
        }

        public string[] GetChatroomNamesArray()
        {
            Chatroom[] chatrooms = GetChatroomArray();
            int count = chatrooms.Length;
            string[] names = new string[count];
            for (int i = 0; i < count; ++i)
            {
                names[i] = chatrooms[i].RoomName;
            }
            return names;
        }


    }
}
