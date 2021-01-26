using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {


            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double lCleaner = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double total = 0;
            double dis = 0;

            double sumPens = pens * 5.8;
            double sumMarkers = markers * 7.2;
            double sumCleners = lCleaner * 1.2;

            total = sumCleners + sumMarkers + sumPens;

            dis = total / 100 * discount;

            total = total - dis;

            Console.WriteLine($"{total:f3}");
        }
    }
}
