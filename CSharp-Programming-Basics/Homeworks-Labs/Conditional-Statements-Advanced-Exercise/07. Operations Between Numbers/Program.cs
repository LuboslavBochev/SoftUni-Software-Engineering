using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string opSign = Console.ReadLine();

            double total = 0;
            bool iszero = false;
            string evenOdd = "";

            if (num2 == 0)
            {
                iszero = true;
            }

            switch (opSign)
            {
                case "+":
                    total = num1 + num2;

                    break;

                case "-":
                    total = num1 - num2;

                    break;

                case "*":
                    total = num1 * num2;

                    break;

                case "/":
                    total = (double)num1 / num2;

                    break;

                case "%":
                    total = (double)num1 % num2;

                    break;

                default:
                    break;
            }


            if (opSign == "+")
            {
                if (total % 2 == 0)
                {
                    evenOdd = "even";
                    Console.WriteLine($"{num1} {opSign} {num2} = {total} - {evenOdd}");
                }
                else
                {
                    evenOdd = "odd";
                    Console.WriteLine($"{num1} {opSign} {num2} = {total} - {evenOdd}");
                }

            }

            else if (opSign == "-")
            {
                if (total % 2 == 0)
                {
                    evenOdd = "even";
                    Console.WriteLine($"{num1} {opSign} {num2} = {total} - {evenOdd}");
                }
                else
                {
                    evenOdd = "odd";
                    Console.WriteLine($"{num1} {opSign} {num2} = {total} - {evenOdd}");
                }

            }

            else if (opSign == "*")
            {
                if (total % 2 == 0)
                {
                    evenOdd = "even";
                    Console.WriteLine($"{num1} {opSign} {num2} = {total} - {evenOdd}");
                }
                else
                {
                    evenOdd = "odd";
                    Console.WriteLine($"{num1} {opSign} {num2} = {total} - {evenOdd}");
                }

            }


            else if (opSign == "/")
            {
                if (iszero)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} / {num2} = {total:f2}");
                }

            }

            else if (opSign == "%")
            {
                if (iszero)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} % {num2} = {total}");
                }

            }


        }

    }
}
