using System;
using System.Linq;

namespace Jeweler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteGold = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] yellowGold = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double pairsDone = 0;
            double storedGold = 0;

            for (int i = 0; i < whiteGold.Length; i++)
            {
                if(whiteGold[i] + yellowGold[i]==10)
                {
                    pairsDone++;
                }
                else if(whiteGold[i] + yellowGold[i]>10)
                {
                    int n = whiteGold[i] + yellowGold[i];
                    for (int j = n; j >= 11; j -= 2)
                    {
                        yellowGold[i] -= 2;
                    }

                    if (whiteGold[i] + yellowGold[i] == 10)
                    {
                        pairsDone++;
                    }
                    else if (whiteGold[i] + yellowGold[i] < 10)
                    {
                        storedGold += whiteGold[i] + yellowGold[i];
                    }
                }
                else if (whiteGold[i] + yellowGold[i]<10)
                {
                    storedGold += whiteGold[i] + yellowGold[i];
                }
            }
            double totalPairs = pairsDone + Math.Floor(storedGold/10);

            if (totalPairs>=7)
            {
                Console.WriteLine($"Great success, you created {totalPairs} earrings.");
            }
            else
            {
                Console.WriteLine($"Keep trying, you need {7-totalPairs} more earrings.");
            }
        }
    }
}
