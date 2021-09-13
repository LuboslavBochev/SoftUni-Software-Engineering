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

            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end") break;

                if (command == "print") print(nums);

                nums = MySelect(nums, Criteria(command));
            }
        }
        static List<int> MySelect(List<int> nums, Func<int, int> criteria)
        {
            List<int> newList = new List<int>();

            foreach (var num in nums)
            {
                newList.Add(criteria(num));
            }
            return newList;
        }
        static Func<int, int> Criteria(string command)
        {
            switch (command)
            {
                case "add": return num => num + 1;
                case "multiply": return num => num * 2;
                case "subtract": return num => num - 1;
                default: return num => num;
            }
        }
    }
}