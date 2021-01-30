using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunak = int.Parse(Console.ReadLine());
            int eggs = int.Parse(Console.ReadLine());
            int biscuits = int.Parse(Console.ReadLine());

            double sumKozunak = kozunak * 3.2;
            double sumEggs = eggs * 4.35;
            double sumBiscuits = biscuits * 5.4;

            double pricePaint = 0.15 * eggs * 12;

            double amount = sumBiscuits + sumEggs + sumKozunak + pricePaint;

            Console.WriteLine($"{amount:f2}");

        }
    }
}
