using System;

namespace Loops1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            int br = 0;

            for (int i = 1; i <= n; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                if (br % 2 == 0)
                {
                    sum1 += nums;
                    br++;
                }
                else
                {
                    sum2 += nums;
                    br++;
                }

            }

            if (sum1 == sum2)
            {
                Console.WriteLine("Yes");
                Console.Write($"Sum = {sum1}");
            }
            else
            {
                Console.WriteLine("No");
                Console.Write($"Diff = {Math.Abs(sum1 - sum2)}");
            }

        }
    }

}