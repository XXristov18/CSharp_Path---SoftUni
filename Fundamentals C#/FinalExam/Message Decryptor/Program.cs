using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Message_Decryptor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex redx = new Regex(@"^(\$|%)([A-Z][a-z]{2,})\1: \[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$");

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string cmd = Console.ReadLine();

                Match match = redx.Match(cmd);

                if (match.Length > 0)
                {
                    string tag = match.Groups[2].Value;

                    char first = (char)int.Parse(match.Groups[3].Value);
                    char second = (char)int.Parse(match.Groups[4].Value);
                    char third = (char)int.Parse(match.Groups[5].Value);

                    StringBuilder decrypted = new StringBuilder();

                    decrypted.Append(first);
                    decrypted.Append(second);
                    decrypted.Append(third);

                    Console.WriteLine($"{tag}: {decrypted}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
