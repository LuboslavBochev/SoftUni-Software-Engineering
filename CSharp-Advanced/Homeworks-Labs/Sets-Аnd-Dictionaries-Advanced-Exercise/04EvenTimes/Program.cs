using System;
using System.Collections.Generic;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<int, int> numCollection = new Dictionary<int, int>();

            for (int i = 0; i < num; i++)
            {
                int inputNum = int.Parse(Console.ReadLine());

                if (!numCollection.ContainsKey(inputNum))
                {
                    numCollection.Add(inputNum, 0);
                }
                numCollection[inputNum]++;
            }

            foreach (var item in numCollection)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}