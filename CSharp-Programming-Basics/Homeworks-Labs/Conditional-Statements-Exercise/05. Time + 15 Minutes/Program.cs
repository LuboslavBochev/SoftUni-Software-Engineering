using System;

namespace _05._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (hours < 24 && minutes < 60)
            {
                minutes = minutes + 15;

                if (minutes >= 60)
                {
                    hours = hours + 1;
                    minutes = 60 - minutes;
                    if (hours > 23) hours = 0;

                }
                if (Math.Abs(minutes) < 10) Console.WriteLine($"{hours}:0{Math.Abs(minutes)}");
                else Console.WriteLine($"{hours}:{Math.Abs(minutes)}");
            }
        }
    }
}
