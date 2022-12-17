namespace Beer_and_Chips
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string FF = Console.ReadLine();
            double PB = double.Parse(Console.ReadLine());
            double NB = double.Parse(Console.ReadLine());
            double NP = double.Parse(Console.ReadLine());

            double BP = NB * 1.20;
            double OP = BP * 0.45;
            double PP = Math.Ceiling(OP * NP);

            if (PB>=BP+PP)
            {
                double ML = PB - (BP + PP);
                    
                Console.WriteLine($"{FF} bought a snack and has {ML:f2} leva left.");
            }
            else
            {
                double MN = (BP + PP) - PB;
                Console.WriteLine($"{FF} needs {MN:f2} more leva!");
            }
        }

    }
}
