using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (task == taskToKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToKill}");
                    break;
                }
                else if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}