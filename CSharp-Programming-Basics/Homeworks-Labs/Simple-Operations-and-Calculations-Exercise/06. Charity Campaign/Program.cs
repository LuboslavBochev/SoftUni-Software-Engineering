using System;

namespace _06._Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int brdni = int.Parse(Console.ReadLine());
            int brsladkari = int.Parse(Console.ReadLine());
            int brtorti = int.Parse(Console.ReadLine());
            int brgofreti = int.Parse(Console.ReadLine());
            int brpalachinki = int.Parse(Console.ReadLine());

            double sumoftorti = brtorti * 45;
            double sumofgofreti = brgofreti * 5.80;
            double sumofpancakes = brpalachinki * 3.20;

            double amountforday = (sumofgofreti + sumofpancakes + sumoftorti) * brsladkari;
            double campanysum = amountforday * brdni;
            double sumrazodi = campanysum - (campanysum * 0.125);


            Console.WriteLine($"{sumrazodi:f2}");
        }
    }
}
