using System;

namespace Alghorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(num));
        }

        public static long Factorial(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            long result = num * Factorial(num - 1);
            return result;
        }
    }
}