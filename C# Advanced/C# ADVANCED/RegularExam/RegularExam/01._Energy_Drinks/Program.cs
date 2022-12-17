namespace _01._Energy_Drinks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] mlCaffeine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] energyDrinks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> mlCaf = new Stack<int>(mlCaffeine);
            Queue<int> enDrin = new Queue<int>(energyDrinks);

            int totalCaffeine = 0;
            int maxCaffeine = 300;
            while (mlCaf.Count != 0 && enDrin.Count != 0)
            { 
                int currentDrank = mlCaf.Peek() * enDrin.Peek();
                if(currentDrank + totalCaffeine <= maxCaffeine)
                {
                    mlCaf.Pop();
                    enDrin.Dequeue();
                    totalCaffeine += currentDrank;
                    continue;
                }
                else if(currentDrank + totalCaffeine > maxCaffeine)
                {
                    mlCaf.Pop();
                    enDrin.Enqueue(enDrin.Dequeue());
                    totalCaffeine -= 30;
                    if (totalCaffeine <0)
                    {
                        totalCaffeine = 0;
                    }
                    continue;
                }
            }

            if (enDrin.Count!=0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", enDrin)}");
            }
            else if(enDrin.Count==0)
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }
                Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");
        }
    }
}
