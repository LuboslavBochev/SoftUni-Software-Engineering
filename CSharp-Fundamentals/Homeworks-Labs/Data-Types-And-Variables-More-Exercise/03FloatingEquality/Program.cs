using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double dif = 0;
            bool isEqual = false;

            if (a > b)
            {
                dif = a - b;
            }
            else dif = b - a;

            if (dif < eps)
            {
                isEqual = true;
            }


            Console.WriteLine(isEqual);
        }
    }
}