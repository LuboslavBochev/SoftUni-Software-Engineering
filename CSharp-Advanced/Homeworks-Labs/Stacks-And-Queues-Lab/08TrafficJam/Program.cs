using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsThatCanPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            string commands = string.Empty;

            int count = 0;

            while (true)
            {
                commands = Console.ReadLine();

                if (commands == "end") break;

                if (commands == "green")
                {
                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(commands);
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}