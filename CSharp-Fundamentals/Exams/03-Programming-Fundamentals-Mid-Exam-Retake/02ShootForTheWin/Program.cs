using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> initialNums = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string command = string.Empty;

            bool shooted = false;
            int shootedTargets = 0;

            while ((command = Console.ReadLine()) != "End")
            {

                int inputIndex = int.Parse(command);

                if (inputIndex < 0 || inputIndex >= initialNums.Count)
                {
                    continue;
                }

                else
                {

                    if (initialNums[inputIndex] == -1)
                    {
                        shooted = true;
                    }

                    if (!shooted)
                    {
                        ShotThatTarget(initialNums, inputIndex);
                        shootedTargets++;
                    }
                }
            }

            Console.Write($"Shot targets: {shootedTargets} -> ");

            foreach (var item in initialNums)
            {
                Console.Write(item + " ");
            }
        }

        static void ShotThatTarget(List<int> initialNums, int inputIndex)
        {

            int value = initialNums[inputIndex];

            initialNums[inputIndex] = -1;

            for (int i = 0; i < initialNums.Count; i++)
            {
                if (i == inputIndex || initialNums[i] == -1)
                {
                    continue;
                }

                else if (initialNums[i] > value)
                {
                    initialNums[i] -= value;
                }

                else
                {
                    initialNums[i] += value;
                }
            }
        }
    }
}