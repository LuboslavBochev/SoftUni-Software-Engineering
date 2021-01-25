using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0, k = 1;

            Console.WriteLine(k);
            while (sum < n)
            {
                sum = 2 * k + 1;
                k = sum;
                if (sum > n)
                {
                    break;
                }
                Console.WriteLine(sum);
            }


        }
    }
}
