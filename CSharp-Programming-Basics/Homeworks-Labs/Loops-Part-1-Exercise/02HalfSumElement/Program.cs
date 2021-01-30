using System;

namespace loops2
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = 0;

            for (int i = 1; i <= n; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                sum += nums;

                if (nums > max) max = nums;
            }

            if ((sum - max) == (max))
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}", max);
            }
            else
            {
                int diff = Math.Abs((sum - max) - max);
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}", diff);
            }
        }
    }
}
