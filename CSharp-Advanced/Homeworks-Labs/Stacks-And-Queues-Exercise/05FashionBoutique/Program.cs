using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(clothesBox);

            int sum = 0;
            int racks = 1;
            int cloth = 0;

            while (box.Count > 0)
            {
                cloth = box.Peek();

                if (cloth + sum <= capacity)
                {
                    box.Pop();
                    sum += cloth;
                }

                else
                {
                    if (box.Count > 0)
                    {
                        racks++;
                        sum = 0;
                    }
                }
            }
            Console.WriteLine(racks);
        }
    }
}