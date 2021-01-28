using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            int rentHall = int.Parse(Console.ReadLine());

            double monuments = rentHall * 0.7;
            double ketaring = monuments * 0.85;
            double sounding = ketaring * 0.5;

            double amount = 1.0 * (monuments + ketaring + sounding + rentHall);

            Console.WriteLine($"{amount:f2}");
        }
    }
}

