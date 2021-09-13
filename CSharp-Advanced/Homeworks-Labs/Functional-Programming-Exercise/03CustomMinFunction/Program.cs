using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int minNumber = nums[0];

            Func<int, bool> checkMinValue = num => num < minNumber;

            foreach (var item in nums)
            {
                if (checkMinValue(item))
                {
                    minNumber = item;
                }
            }
            Console.WriteLine(minNumber);
        }
    }
}