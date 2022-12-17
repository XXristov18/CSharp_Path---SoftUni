using System;

namespace SwimmingChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double pointsN = double.Parse(Console.ReadLine());
            int swimmersC = int.Parse(Console.ReadLine());
            double roomP = double.Parse(Console.ReadLine());
            double partFee = double.Parse(Console.ReadLine());
            double roomSum = roomP * swimmersC * days;
            double partSum = partFee * swimmersC;
            double totalSum = roomSum + partSum;
            double pointsE = 0;
            double currentP = 0;

            for (int i = 0; i < days; i++)
            {
                double pointsPD = double.Parse(Console.ReadLine());
                if(i>0)
                {
                    pointsPD = currentP * 0.05 + pointsPD;
                }
                currentP=pointsPD;
                pointsE += pointsPD;
            }

            if (pointsE>=pointsN)
            {
                Console.WriteLine($"Money left to pay: {totalSum-(totalSum*0.25):f2} BGN.\nThe championship was successful!");
            }
            else
            {
                Console.WriteLine($"Money left to pay: {totalSum - (totalSum * 0.10):f2} BGN.\nThe championship was not successful.");
            }
        }
    }
}
