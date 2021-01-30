using System;

namespace Loops1
{
    class Program
    {
        static void Main(string[] args)
        {

            int age = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            double priceOfToy = double.Parse(Console.ReadLine());

            double sum = 0;
            double total = 0;
            int cbr = 0;

            double soldToys = 0;
            int cToys = 0;


            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sum += 10;
                    total += sum;
                    cbr++;
                }
                else
                {
                    cToys++;
                }
            }
            soldToys = cToys * priceOfToy;

            total = total + soldToys - cbr;

            if (total >= machinePrice)
            {
                Console.WriteLine($"Yes! {total - machinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {machinePrice - total:f2}");
            }

        }

    }
}