using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int numQueries = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numQueries; i++)
            {
                string[] commands = Console.ReadLine().Split();

                string type = commands[0];

                if (type == "1")
                {
                    int numToPush = int.Parse(commands[1]);

                    numbers.Push(numToPush);
                }

                else if (type == "2")
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }

                else if (type == "3")
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }

                else
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}