using System;
using System.Collections.Generic;
using System.Linq;

namespace Message_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, MessageProperties> messagesByUser = new Dictionary<string, MessageProperties>();
            int capacity = int.Parse(Console.ReadLine());

            string[] cmd = Console.ReadLine().Split("=");

            while (cmd[0] != "Statistics")
            {
                string cUser = cmd[1];

                switch (cmd[0])
                {
                    case "Add":
                        if (!messagesByUser.ContainsKey(cUser))
                        {
                            int sMessages = int.Parse(cmd[2]);
                            int rMessages = int.Parse(cmd[3]);
                            messagesByUser.Add(cUser, new MessageProperties(sMessages, rMessages));
                        }
                        break;
                    case "Message":
                        string receiver = cmd[2];
                        if (messagesByUser.ContainsKey(cUser) && messagesByUser.ContainsKey(receiver))
                        {
                            messagesByUser[cUser].Sent++;
                            messagesByUser[receiver].Received++;

                            if (messagesByUser[cUser].TotalMessages == capacity)
                            {
                                messagesByUser.Remove(cUser);
                                Console.WriteLine($"{cUser} reached the capacity!");
                            }

                            if (messagesByUser[receiver].TotalMessages == capacity)
                            {
                                messagesByUser.Remove(receiver);
                                Console.WriteLine($"{receiver} reached the capacity!");
                            }
                        }
                        break;
                    case "Empty":
                        if (cUser == "All")
                        {
                            messagesByUser.Clear();
                        }
                        else if (messagesByUser.ContainsKey(cUser))
                        {
                            messagesByUser.Remove(cUser);
                        }
                        break;
                }

                cmd = Console.ReadLine().Split("=");
            }

            Console.WriteLine($"Users count: {messagesByUser.Count}");
            foreach (var item in messagesByUser)
            {
                Console.WriteLine($"{item.Key} - {item.Value.TotalMessages}");
            }
        }
    }

    class MessageProperties
    {
        public MessageProperties(int sent, int received)
        {
            this.Sent = sent;
            this.Received = received;
        }
        public int Sent { get; set; }
        public int Received { get; set; }

        public int TotalMessages => this.Sent + this.Received;
    }
}
