using System;

namespace Loops1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                sum += nums;
            }
            Console.WriteLine(sum);

        }
    }

}