using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num1 = 0;
            int num2 = 0;
            int greter = 0;
            bool orderNum2 = false;

            for (int i = 1; i <= n; i++)
            {

                string numbers = Console.ReadLine();

                for (int j = 0; j < numbers.Length; j++)
                {
                    char digits = char.Parse(numbers[j].ToString());

                    if (digits == 45) continue;

                    if (digits == 32)
                    {
                        orderNum2 = true;
                        continue;
                    }

                    else if (orderNum2)
                    {
                        int num2Digit = int.Parse(digits.ToString());
                        num2 += num2Digit;
                    }
                    else
                    {
                        int num1Digit = int.Parse(digits.ToString());
                        num1 += num1Digit;
                    }
                }

                greter = num2;

                if (greter < num1)
                {
                    greter = num1;
                }
                Console.WriteLine(greter);
                orderNum2 = false;
                num1 = 0;
                num2 = 0;
            }

        }
    }
}