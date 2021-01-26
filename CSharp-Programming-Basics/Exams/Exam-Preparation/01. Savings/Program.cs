using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            double personalMoney = double.Parse(Console.ReadLine());

            double costs = budget * 0.3;

            double sumForMonth = budget - (costs + personalMoney);

            double sumSaving = sumForMonth * month;

            double percentage = sumForMonth / budget * 100;


            Console.WriteLine($"She can save {percentage:f2}%");
            Console.WriteLine($"{sumSaving:f2}");

        }
    }
}