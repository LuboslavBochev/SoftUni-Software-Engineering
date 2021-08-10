using System;

namespace examTasks
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibo(n));
        }

        public static int Fibo(int number)
        {
            if (number <= 2)
            {
                return 1;
            }
            else
            {
                return Fibo(number - 2) + Fibo(number - 1);
            }
        }

    }
}