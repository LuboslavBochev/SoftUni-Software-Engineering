using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numsToSort = Console.ReadLine()
                .Split(", ")
                .Select(x => int.Parse(x))
                .Where(x =>
                {
                    return x % 2 == 0;
                })
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", numsToSort));
        }
    }
}
