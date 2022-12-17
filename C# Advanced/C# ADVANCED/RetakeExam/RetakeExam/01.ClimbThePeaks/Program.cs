namespace _01.ClimbThePeaks 
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> peaks = new Dictionary<string, int>
            {
                { "Vihren",80 },{"Kutelo", 90},{"Banski Suhodol",100},{"Polezhan",60},{"Kamenitza",70}
            };
            int[] dailyPortions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] dailyStamina = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> portions = new Stack<int>(dailyPortions);
            Queue<int> stamina = new Queue<int>(dailyStamina);

            List<string> output = new List<string>();
            int days = 0;

            while (portions.Count!=0&&stamina.Count!=0)
            {

                int sum = portions.Pop() + stamina.Dequeue();

                if (peaks.Count==0)
                {
                    break;
                }
                if(sum >= peaks.First().Value)
                {
                    output.Add(peaks.First().Key);
                    peaks.Remove(peaks.First().Key);
                }
                else
                {
                    days++;
                    if (days==7)
                    {
                        break;
                    }

                }
            }

            if (peaks.Count==0)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (output.Count!=0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Conquered peaks:");
                foreach (string peak in output)
                {
                    sb.AppendLine(peak);
                }
                Console.WriteLine(sb.ToString().Trim());
            }

        }
    }
}
