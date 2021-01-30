using System;

namespace _04._Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int brmasi = int.Parse(Console.ReadLine());
            double lenghtmasi = double.Parse(Console.ReadLine());
            double widthmasi = double.Parse(Console.ReadLine());

            double areapokrivki = brmasi * (lenghtmasi + 2 * 0.3) * (widthmasi + 2 * 0.3);
            double areakareta = brmasi * (lenghtmasi / 2) * (lenghtmasi / 2);

            double amountusd = areapokrivki * 7 + areakareta * 9;
            double amountbgn = amountusd * 1.85;

            Console.WriteLine($"{amountusd:f2} USD");
            Console.WriteLine($"{amountbgn:f2} BGN");
        }
    }
}
