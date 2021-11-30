using System;
using System.Linq;

namespace Alghorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(ArraySum(numbers, 0));
        }

        public static int ArraySum(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                return 0;
            }
            return numbers[index] + ArraySum(numbers, ++index);
        }
    }
}