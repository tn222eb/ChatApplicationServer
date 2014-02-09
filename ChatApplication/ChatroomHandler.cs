using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkApplication
{
    public class Request
    {
        public bool disconnect;
        public string chatroom;
        public string username;
        public string message;
        public string[] users;
        
    }

    public class ChatroomHandler
    {
        private string _jsonMessage;
        public string JsonMessage
        {
            get { return this._jsonMessage; }
            set { this._jsonMessage = value; }
        }

        private static ChatroomHandler _instance = new ChatroomHandler();
        public static ChatroomHandler GetInstance
        {
            get { return _instance; }
        }

        private ApplicationChatrooms _chatrooms;

        private ChatroomHandler()
        {
            this._chatrooms = ApplicationChatrooms.GetInstance;
        }

        public void PerformChatroomTasksWithJson(User _user, string _json)
        {
            if (_json == null)
                throw new Exception("Json string is null.");

            Request request = JsonConvert.DeserializeObject<Request>(_json);
            Chatroom chatroom = this._chatrooms.SearchChatroomWithKey(request.chatroom);
            _user.Name = request.username;

            if (chatroom == null)
            {
                Console.WriteLine("Create a new chatroom!: " + request.chatroom);
                chatroom = new Chatroom(request.chatroom);
                chatroom.AddUser(_user);
                this._chatrooms.AddChatroomWithKey(request.chatroom, chatroom);
            }
            else
            {
                Console.WriteLine("Channel already exists! With the users: ");
                foreach (User user in chatroom.GetUsers())
                    Console.WriteLine(user.Name);
            }
            
            if(request.disconnect)
            {
                DisconnectUserFromChatroom(chatroom, request.username);
            }


            // TODO: Add stuff with messages and users
            SendMessageToUsers(chatroom, request);
            


        }

        private void DisconnectUserFromChatroom(Chatroom _chatroom, string _userName)
        {
            _chatroom.RemoveUserWithName(_userName);
            Console.WriteLine("User Removed!: " + _userName);
            User[] users = _chatroom.GetUsers();
            int numberOfUsers = users.Length;
            if (numberOfUsers == 0)
            {
                _chatrooms.RemoveChatroomWithKey(_chatroom.RoomName);
                Console.WriteLine("Chatroom Removed!: " + _chatroom.RoomName);
            }
        }

        private void SendMessageToUsers(Chatroom _chatroom, Request _request)
        {
            try
            {
                User[] users = _chatroom.GetUsers();
                int numberOfUsers = users.Length;
                if(numberOfUsers == 0)
                    return;
                string data = JsonConvert.SerializeObject(_request);
                foreach (User user in users)
                {
                    NetworkStream networkStream = user.NetworkStream;
                    WriteToUser(networkStream, data);
                }
            }
            catch (Exception e)
            {

            }
        }

        private void WriteToUser(NetworkStream _networkStream, string _message)
        {
            if (_networkStream != null)
            {
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(_message);
                _networkStream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", _message);
                
            }
        }


    }
}
