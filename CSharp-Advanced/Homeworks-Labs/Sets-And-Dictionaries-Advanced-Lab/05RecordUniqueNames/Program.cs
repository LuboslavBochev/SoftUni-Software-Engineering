using System;
using System.Collections.Generic;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (var item in uniqueNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}