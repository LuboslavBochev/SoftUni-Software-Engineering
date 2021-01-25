using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()), cN = 0, maxValue = int.MinValue;

            while (cN < n)
            {
                int nums = int.Parse(Console.ReadLine());
                cN++;

                if (nums > maxValue)
                {
                    maxValue = nums;
                }
            }
            Console.WriteLine(maxValue);

        }
    }
}