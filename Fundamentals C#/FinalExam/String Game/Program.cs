using System;

namespace String_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            while (true)
            {
                string[] cmd = Console.ReadLine().Split();

                if (cmd[0] == "Done")
                {
                    break;
                }
                else if (cmd[0] == "Change")
                {
                    str = str.Replace(char.Parse(cmd[1]), char.Parse(cmd[2]));
                    Console.WriteLine(str);
                }
                else if (cmd[0] == "Includes")
                {
                    if (str.Contains(cmd[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (cmd[0] == "End")
                {
                    if(str.EndsWith(cmd[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
                else if (cmd[0] == "Uppercase")
                {
                    str = str.ToUpper();
                    Console.WriteLine(str);
                }
                else if (cmd[0] == "FindIndex")
                {
                    Console.WriteLine(str.IndexOf(char.Parse(cmd[1])));
                }
                else if (cmd[0] == "Cut")
                {
                    str = str.Substring(int.Parse(cmd[1]), int.Parse(cmd[2]));
                    Console.WriteLine(str);
                }
            }
        }
    }
}
