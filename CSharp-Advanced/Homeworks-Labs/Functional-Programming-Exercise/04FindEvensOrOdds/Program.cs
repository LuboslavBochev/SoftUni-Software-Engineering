using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string type = Console.ReadLine();

            Predicate<int> checkNum = num => num % 2 == 0;

            List<int> numbers = new List<int>();

            for (int i = nums[0]; i <= nums[1]; i++)
            {
                if (checkNum(i) && type == "even")
                {
                    numbers.Add(i);
                }
                if (!checkNum(i) && type == "odd")
                {
                    numbers.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}