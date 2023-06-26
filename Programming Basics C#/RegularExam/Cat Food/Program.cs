namespace Cat_Food
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int cn = int.Parse(Console.ReadLine());
            int g1 = 0;
            int g2 = 0;
            int g3 = 0;
            double kgf = 0;

            for (int i = 0; i < cn; i++)
            {
                double f = double.Parse(Console.ReadLine());
                if (f >= 100 && f < 200)
                    g1++;
                else if (f >= 200 && f < 300)
                    g2++;
                else if (f >= 300 && f < 400)
                    g3++;

                kgf = kgf + f;
            }
            Console.WriteLine($"Group 1: {g1} cats.");
            Console.WriteLine($"Group 2: {g2} cats.");
            Console.WriteLine($"Group 3: {g3} cats.");
            Console.WriteLine($"Price for food per day: {Math.Round(((kgf/1000)*12.45),2)} lv.");
        }
    }
}
