using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()), cN = 0, minValue = int.MaxValue;

            while (cN < n)
            {
                int nums = int.Parse(Console.ReadLine());
                cN++;

                if (nums < minValue)
                {
                    minValue = nums;
                }
            }
            Console.WriteLine(minValue);

        }
    }
}