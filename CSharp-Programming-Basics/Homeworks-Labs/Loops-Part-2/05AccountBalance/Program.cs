using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()), cN = 0;
            double total = 0, addNum;

            while (cN < n)
            {
                addNum = double.Parse(Console.ReadLine());
                if (addNum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                total += addNum;
                cN++;
                Console.WriteLine($"Increase: {addNum:f2}");
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}