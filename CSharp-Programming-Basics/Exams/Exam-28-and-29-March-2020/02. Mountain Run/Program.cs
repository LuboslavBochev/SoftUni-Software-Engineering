using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {

            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());

            double newRecord = distance * timeForOneMeter;

            double delay = Math.Floor(distance / 50) * 30;

            double totalSec = newRecord + delay;

            if (totalSec < record)
            {
                Console.WriteLine($"Yes! The new record is {totalSec:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(record - totalSec):f2} seconds slower.");
            }
        }
    }
}
