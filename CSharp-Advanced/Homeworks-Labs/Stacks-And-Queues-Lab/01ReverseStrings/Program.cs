using System;
using System.Collections.Generic;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputStr = Console.ReadLine();

            Stack<char> reversedStr = new Stack<char>();

            for (int i = 0; i < inputStr.Length; i++)
            {
                reversedStr.Push(inputStr[i]);
            }
            Console.WriteLine(string.Join("", reversedStr));
        }
    }
}