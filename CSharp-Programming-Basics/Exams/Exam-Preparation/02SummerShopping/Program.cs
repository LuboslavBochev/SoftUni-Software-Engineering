using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double beachTowel = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());


            double umbrella = beachTowel * 0.6666666666666667;
            double mokasini = umbrella * 0.75;
            double beachBag = (mokasini + beachTowel) * 0.3333333333333333;


            double sum = beachTowel + umbrella + mokasini + beachBag;
            double sumDis = sum / 100 * discount;
            double total = sum - sumDis;


            if (budget >= total)
            {
                Console.WriteLine($"Annie's sum is {total:f2} lv. She has {budget - total:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {total:f2} lv. She needs {total - budget:f2} lv. more.");
            }
        }
    }
}