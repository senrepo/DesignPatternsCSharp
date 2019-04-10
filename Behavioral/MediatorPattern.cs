using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class MediatorPattern
    {
        public static void Test()
        {
            ChatServer server = new ChatServer();
            User jack = new User("Jack");
            User mark = new User("Mark");

            server.Register(jack);
            server.Register(mark);

            jack.Send("Mark", "Hi Mark");
            mark.Send("Jack", "Whats up buddy");
        }
    }

    //Mediator Pattern: Acting as Mediator between classes. For ex. Chat Program, all chat messages are routed through the Chat Server.

    class ChatServer
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        public void Register(User user)
        {
            if (!users.ContainsKey(user.Name))
            {
                users.Add(user.Name, user);
            }
            user.ChatServer = this;
        }
        public void Send(string from, string to, string message)
        {
            User user = users[to];
            if (user != null)
            {
                user.Receive(from, message);
            }
        }
    }

    class User
    {
        public string Name { get; set; }
        public ChatServer ChatServer { get; set; }
        public User(string name)
        {
            this.Name = name;
        }
        public void Send(string to, string message)
        {
            this.ChatServer.Send(this.Name, to, message);
        }
        public void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }
    }
}
