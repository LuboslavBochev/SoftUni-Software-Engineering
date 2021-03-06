﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numCollection = new Stack<int>();

            int numToPush = commands[0];
            int numToPop = commands[1];
            int wantedNum = commands[2];

            for (int i = 0; i < numToPush; i++) // push to stack
            {
                numCollection.Push(numbers[i]);
            }

            for (int i = 0; i < numToPop; i++)
            {
                numCollection.Pop();
            }

            if (numCollection.Count > 0)
            {
                if (numCollection.Contains(wantedNum))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numCollection.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}