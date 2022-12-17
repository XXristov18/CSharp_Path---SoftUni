namespace Gold_Mine
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int lc = int.Parse(Console.ReadLine());
            for (int i = 0; i < lc; i++)
            {
                double adg = double.Parse(Console.ReadLine());
                int dc = int.Parse(Console.ReadLine());
                double tt = 0;

                for (int a = 0; a < dc; a++)
                {
                    double ge = double.Parse(Console.ReadLine());
                    tt = tt + ge;
                }

                if ((tt/dc)>=adg)
                {
                    Console.WriteLine($"Good job! Average gold per day: {(tt/dc):f2}.");
                }
                else
                    Console.WriteLine($"You need {(adg-(tt/dc)):f2} gold.");

            }
        }
    }
}
