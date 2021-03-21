﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNums = new Queue<int>();

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    evenNums.Enqueue(item);
                }
            }
            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
