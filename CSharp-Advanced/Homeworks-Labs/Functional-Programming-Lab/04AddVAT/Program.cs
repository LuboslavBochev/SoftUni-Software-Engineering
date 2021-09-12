using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> doubleParser = x => double.Parse(x);
            Func<double, double> vatAdded = x => x * 1.2;

            double[] nums = Console.ReadLine().Split(", ").Select(doubleParser).ToArray();

            nums = nums.Select(vatAdded).ToArray();

            foreach (var num in nums)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}