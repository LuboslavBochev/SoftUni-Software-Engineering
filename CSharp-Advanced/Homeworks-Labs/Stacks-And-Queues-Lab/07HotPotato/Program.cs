using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputChildren = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> children = new Queue<string>(inputChildren);

            int counter = 0;

            while (children.Count > 1)
            {
                counter++;

                if (counter == n)
                {
                    Console.WriteLine($"Removed {children.Dequeue()}");
                    counter = 0;
                }
                else
                {
                    string name = children.Dequeue();

                    children.Enqueue(name);
                }
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}