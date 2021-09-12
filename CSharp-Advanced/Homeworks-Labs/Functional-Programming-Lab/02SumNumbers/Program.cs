using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSumAndCount(int.Parse,
                x => x.Length,
                x => x.Sum()
                );
        }
        static void PrintSumAndCount(Func<string, int> parser, Func<int[], int> length, Func<int[], int> sum)
        {
            int[] numArray = Console.ReadLine().
                Split(", ").
                Select(parser).
                ToArray();

            Console.WriteLine(length(numArray));
            Console.WriteLine(sum(numArray));
        }
    }
}
