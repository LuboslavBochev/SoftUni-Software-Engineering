using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeforonemeter = double.Parse(Console.ReadLine());

            double timeforfinish = distance * timeforonemeter;
            double delay = Math.Floor(distance / 15) * 12.5;

            double alltime = timeforfinish + delay;

            if (alltime >= record)
            {
                double lefttime = alltime - record;
                Console.WriteLine($"No, he failed! He was {lefttime:f2} seconds slower.");
            }
            else Console.WriteLine($"Yes, he succeeded! The new world record is {alltime:f2} seconds.");
        }
    }
}
