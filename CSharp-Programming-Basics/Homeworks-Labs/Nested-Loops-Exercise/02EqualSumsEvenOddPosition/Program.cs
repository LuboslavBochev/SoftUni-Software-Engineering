using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++) // 100000
            {
                string currnum = i.ToString();
                int oddSum = 0;
                int evenSum = 0;

                for (int j = 0; j < currnum.Length; j++)
                {
                    int digit = int.Parse(currnum[j].ToString());

                    if (j % 2 == 0)
                    {
                        evenSum += digit;
                    }

                    else
                    {
                        oddSum += digit;
                    }
                }
                if (evenSum == oddSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}