using System;

namespace _08._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            int volume = lenght * width * height;

            double totalliters = volume * 0.001;
            double totalpecentage = percentage * 0.01;

            double result = totalliters * (1 - totalpecentage);
            Console.WriteLine($"{result:f3}");
        }
    }
}
