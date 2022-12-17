using System;
using System.Collections.Generic;
using System.Linq;

namespace Magic_Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> deckOfCards = Console.ReadLine().Split(':').ToList();
            List<string> newDeckOfCards = new List<string>();

            while (true)
            {
                string[] cmd = Console.ReadLine().Split().ToArray();

                if (cmd[0] == "Ready")
                {
                    break;
                }
                else if (cmd[0] == "Add")
                {
                    if (deckOfCards.Contains(cmd[1]))
                    {
                        newDeckOfCards.Add(cmd[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (cmd[0] == "Insert")
                {
                    if (deckOfCards.Contains(cmd[1]) && int.Parse(cmd[2]) >= 0 && int.Parse(cmd[2]) < newDeckOfCards.Count())
                    {
                        newDeckOfCards.Insert(int.Parse(cmd[2]), cmd[1]);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (cmd[0] == "Remove")
                {
                    if (newDeckOfCards.Contains(cmd[1]))
                    {
                        newDeckOfCards.Remove(cmd[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (cmd[0] == "Swap")
                {
                    int a = newDeckOfCards.IndexOf(cmd[1]);
                    int b = newDeckOfCards.IndexOf(cmd[2]);
                    string temp = newDeckOfCards[a];
                    newDeckOfCards[a] = newDeckOfCards[b];
                    newDeckOfCards[b] = temp;
                }
                else if(cmd[0] == "Shuffle" && cmd[1] == "deck")
                {
                    newDeckOfCards.Reverse();
                }

            }
                    Console.WriteLine(String.Join(" ",newDeckOfCards));
        }
    }
}
