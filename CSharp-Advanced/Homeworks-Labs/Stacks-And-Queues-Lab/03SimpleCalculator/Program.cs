using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] numbers = Console.ReadLine().Split();

            Stack<string> sum = new Stack<string>(numbers.Reverse());

            while (sum.Count > 1)
            {
                int firstNum = int.Parse(sum.Pop());
                string sign = sum.Pop();
                int secondNum = int.Parse(sum.Pop());
                int result = 0;

                if (sign == "+")
                {
                    result = firstNum + secondNum;
                    sum.Push(result.ToString());
                }
                else
                {
                    result = firstNum - secondNum;
                    sum.Push(result.ToString());
                }
            }
            Console.WriteLine(sum.Pop());
        }
    }
}