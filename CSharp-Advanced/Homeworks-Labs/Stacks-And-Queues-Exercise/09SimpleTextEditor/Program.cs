using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());


            string result = string.Empty;
            Stack<string> stack = new Stack<string>();

            for (int i = 1; i <= numberOfOperations; i++)
            {
                string[] currentCommand = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currentCommand[0] == "1")
                {
                    stack.Push(result);
                    string stringToAppend = string.Join("", currentCommand.Skip(1));
                    result += stringToAppend;
                }

                else if (currentCommand[0] == "2")
                {
                    stack.Push(result);

                    int count = int.Parse(currentCommand[1]);

                    result = result.Substring(0, result.Length - count);
                }

                else if (currentCommand[0] == "3")
                {
                    int index = int.Parse(currentCommand[1]);

                    Console.WriteLine(result[index - 1]);
                }

                else if (currentCommand[0] == "4")
                {
                    if (stack.Count > 0)
                    {
                        result = stack.Pop();
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
            }
        }
    }
}