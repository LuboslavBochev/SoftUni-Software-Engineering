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

            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisble = num => num % n == 0;
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            nums = MySelect(nums, isDivisble);

            print(nums);
        }
        static List<int> MySelect(List<int> nums, Predicate<int> isDivisible)
        {
            List<int> newList = new List<int>();

            foreach (var num in nums)
            {
                if (!isDivisible(num))
                {
                    newList.Add(num);
                }
            }
            newList = Reverse(newList); // calling my Reverse function
            return newList;
        }
        static List<int> Reverse(List<int> nums)
        {
            List<int> newList = new List<int>();

            for (int i = nums.Count - 1; i >= 0; i--)
            {
                newList.Add(nums[i]);
            }
            return newList;
        }
    }
}