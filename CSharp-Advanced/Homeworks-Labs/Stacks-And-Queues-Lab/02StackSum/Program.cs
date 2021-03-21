using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> nums = new Stack<int>(numbers);

            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "end") break;

                string[] commands = command.Split();

                string type = commands[0].ToLower();

                if (type == "add")
                {
                    int firstNum = int.Parse(commands[1]);
                    int secondNum = int.Parse(commands[2]);

                    nums.Push(firstNum);
                    nums.Push(secondNum);
                }
                else
                {
                    int n = int.Parse(commands[1]);

                    if (n <= nums.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            nums.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}