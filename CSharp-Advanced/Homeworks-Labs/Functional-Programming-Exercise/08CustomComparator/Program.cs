using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Func<int, bool> getEven = num => num % 2 == 0;
            Func<int, bool> getOdd = num => num % 2 != 0;

            List<int> evenNums = nums.Where(getEven).ToList();
            List<int> oddNums = nums.Where(getOdd).ToList();

            List<int> result = new List<int>();

            evenNums.Sort();
            oddNums.Sort();

            result.AddRange(evenNums);
            result.AddRange(oddNums);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
