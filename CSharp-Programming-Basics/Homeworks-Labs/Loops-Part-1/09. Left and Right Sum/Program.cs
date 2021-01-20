using System;

namespace Loops1
{
    class Program
    {
        static void Main(string[] args)
        {
            //input nums // var:sum
            // i < = nums * 2 //

            int n = int.Parse(Console.ReadLine());
            n *= 2;
            int sum1 = 0;
            int sum2 = 0;


            for (int i = 1; i <= n / 2; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                sum1 += nums;
            }

            for (int i = 1; i <= n / 2; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                sum2 += nums;
            }

            if (sum1 == sum2) Console.WriteLine("Yes, sum = {0}", sum1);
            else
            {
                int dif = 0;
                dif = sum1 - sum2;
                Console.WriteLine("No, diff = {0}", Math.Abs(dif));
            }
        }
    }

}