using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = "";
            int primeSum = 0;
            int nonPrimeSum = 0;


            while (true)
            {
                bool isPrime = true;
                n = Console.ReadLine();
                if (n == "stop")
                {
                    break;
                }

                int nums = int.Parse(n);

                if (nums == 1)
                {
                    nonPrimeSum += nums;
                }

                if (nums < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                for (int i = 2; i <= nums / 2; i++)
                {
                    if (nums % i == 0)
                    {
                        nonPrimeSum += nums;
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeSum += nums;
                }

            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}