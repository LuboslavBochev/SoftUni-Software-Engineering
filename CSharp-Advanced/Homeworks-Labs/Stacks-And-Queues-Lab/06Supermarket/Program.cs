using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<string> customers = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                    customers.Clear();
                }

                else
                {
                    customers.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}