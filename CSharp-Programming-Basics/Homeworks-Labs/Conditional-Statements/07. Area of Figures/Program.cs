using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = Console.ReadLine();
            double area = 0;

            if (choice == "square")
            {
                double lenght = double.Parse(Console.ReadLine());
                area = lenght * lenght;
                Console.WriteLine($"{area:f3}");
            }
            else if (choice == "rectangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                area = lenght * width;
                Console.WriteLine($"{area:f3}");
            }
            else if (choice == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = (radius * radius) * Math.PI;
                Console.WriteLine($"{area:f3}");
            }
            else if (choice == "triangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                area = lenght * (height / 2);
                Console.WriteLine($"{area:f3}");
            }
        }
    }
}
