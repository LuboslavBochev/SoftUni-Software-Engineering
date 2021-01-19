using System;

namespace _05._Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());

            double areahall = (lenght * 100) * (width * 100);
            double wardrobe = (A * 100) * (A * 100);
            double peika = areahall / 10;
            double freespace = areahall - wardrobe - peika;

            double brdancers = freespace / (7000 + 40);


            Console.WriteLine(Math.Floor(brdancers));
        }
    }
}
