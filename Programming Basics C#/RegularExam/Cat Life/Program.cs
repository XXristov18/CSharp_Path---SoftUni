namespace Cat_Life
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
           string CT = Console.ReadLine();
            char g = char.Parse(Console.ReadLine());
            if (CT=="British Shorthair")
            {
                if (g == 'm')
                {
                    double l = (13 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
                else if (g == 'f')
                {
                    double l = (14 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
            }
            else if (CT == "Siamese")
            {
                if (g == 'm')
                {
                    double l = (15 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
                else if (g == 'f')
                {
                    double l = (16 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
            }
            else if (CT == "Persian")
            {
                if (g == 'm')
                {
                    double l = (14 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
                else if (g == 'f')
                {
                    double l = (15 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
            }
            else if (CT == "Ragdoll")
            {
                if (g == 'm')
                {
                    double l = (16 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
                else if (g == 'f')
                {
                    double l = (17 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
            }
            else if (CT == "American Shorthair")
            {
                if (g == 'm')
                {
                    double l = (12 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
                else if (g == 'f')
                {
                    double l = (13 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
            }
            else if (CT == "Siberian")
            {
                if (g == 'm')
                {
                    double l = (11 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
                else if (g == 'f')
                {
                    double l = (12 * 12) / 6;
                    Math.Floor(l);
                    Console.WriteLine($" {l} cat months");
                }
            }
            else
                Console.WriteLine($"{CT} is invalid cat!");

        }
    }
}
