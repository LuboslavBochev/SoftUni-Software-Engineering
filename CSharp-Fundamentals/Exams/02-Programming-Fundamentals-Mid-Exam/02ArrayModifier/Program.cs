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


            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "end")
            {

                string[] tokens = commands.Split(" ");

                string command = tokens[0];

                if (command == "swap")
                {
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);

                    SwapItems(initialNums, firstIndex, secondIndex);
                }

                else if (command == "multiply")
                {
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);

                    Multiply(initialNums, firstIndex, secondIndex);
                }

                else
                {
                    for (int i = 0; i < initialNums.Count; i++)
                    {
                        initialNums[i]--;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", initialNums));

        }

        static void Multiply(List<int> initialNums, int firstIndex, int secondIndex)
        {
            int total = initialNums[firstIndex] * initialNums[secondIndex];

            initialNums[firstIndex] = total;
        }

        static void SwapItems(List<int> initialNums, int firstIndex, int secondIndex)
        {
            int firstValue = initialNums[firstIndex];

            initialNums[firstIndex] = initialNums[secondIndex];
            initialNums[secondIndex] = firstValue;
        }
    }
}