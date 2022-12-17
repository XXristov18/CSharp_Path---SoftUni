namespace Puppy_Care
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int kgf = int.Parse(Console.ReadLine());
            kgf = kgf * 1000;
            int kgn = 0;
            while (true)
            {
                string n = Console.ReadLine();
                if (n != "Adopted")
                {
                    int nn = int.Parse(n);
                    kgn = kgn + nn;
                }
                else if (n == "Adopted")
                {
                    break;
                }
            } 

            if (kgn<=kgf)
            {
                int n = kgf- kgn;
                Console.WriteLine($"Food is enough! Leftovers: {n} grams.");
            }
            else if (kgn>kgf)
            {
                int n = kgn - kgf;
                Console.WriteLine($"Food is not enough. You need {n} grams more.");
            }

        }
    }
}
