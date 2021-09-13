using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthStr = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> isEnoughLength = str => str.Length <= lengthStr;

            MySelect(names, isEnoughLength);
        }
        static void MySelect(List<string> names, Predicate<string> checker)
        {
            foreach (var name in names)
            {
                if (checker(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}