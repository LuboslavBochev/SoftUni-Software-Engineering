using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }
            foreach (var item in usernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}