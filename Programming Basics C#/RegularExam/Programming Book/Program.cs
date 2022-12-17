namespace Programming_Book
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            double PrP = double.Parse(Console.ReadLine());
            double PrC = double.Parse(Console.ReadLine()); 
            double PD = double.Parse(Console.ReadLine());
            double DP = double.Parse(Console.ReadLine());
            double MN = double.Parse(Console.ReadLine());

            double a = PrP * 899 + PrC * 2;
            double b = a - (a*(PD/100));
            double c = b + DP;
            double d = c - (c*(MN/100));
            double ff = d;

            Console.WriteLine($"Avtonom should pay {ff:f2} BGN.");

        }
    }
}
