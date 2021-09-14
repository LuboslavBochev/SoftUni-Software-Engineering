using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNum = int.Parse(Console.ReadLine());

            List<int> sequence = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> numbers = new List<int>();

            Func<int, List<int>> getNumbers = num =>
            {
                List<int> range = new List<int>();

                for (int i = 1; i <= num; i++)
                {
                    range.Add(i);
                }
                return range;
            };
            numbers = getNumbers(endNum);

            Predicate<int> condition = num =>
            {
                foreach (var currentNum in sequence)
                {
                    if (num % currentNum != 0) return false;
                }
                return true;
            };

            Console.WriteLine(string.Join(" ", MyWhere(numbers, condition)));
        }
        static List<int> MyWhere(List<int> nums, Predicate<int> condition)
        {
            List<int> modifyied = new List<int>();

            foreach (var num in nums)
            {
                if (condition(num))
                {
                    modifyied.Add(num);
                }
            }
            return modifyied;
        }
    }
}