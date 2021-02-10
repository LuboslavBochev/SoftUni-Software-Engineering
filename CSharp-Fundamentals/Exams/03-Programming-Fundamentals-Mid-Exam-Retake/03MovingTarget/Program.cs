using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> targets = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {

                string[] tokens = command.Split(" ");

                int index = int.Parse(tokens[1]);

                switch (tokens[0])
                {

                    case "Shoot":

                        if (index < 0 || index >= targets.Count)
                        {
                            continue;
                        }

                        int power = int.Parse(tokens[2]);

                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }

                        break;

                    case "Add":

                        if (index < 0 || index >= targets.Count)
                        {
                            Console.WriteLine("Invalid placement!");
                            continue;
                        }

                        else
                        {
                            int value = int.Parse(tokens[2]);

                            targets.Insert(index, value);
                        }

                        break;

                    case "Strike":

                        bool strike = false;

                        if (index < 0 || index >= targets.Count)
                        {
                            Console.WriteLine("Strike missed!");
                            continue;
                        }

                        int radius = int.Parse(tokens[2]);

                        if (index >= radius)
                        {
                            strike = true;
                        }

                        if (strike)
                        {
                            int lowerIndex = index - radius;
                            int higherIndex = index + radius;

                            // int count = 0;

                            targets.RemoveRange(index - radius, radius * 2 + 1);
                            //for (int i = lowerIndex; count < higherIndex; i++)
                            //{
                            //    targets.RemoveAt(i);
                            //    count++;
                            //    i--;
                            //}
                        }

                        else Console.WriteLine("Strike missed!");

                        break;
                }
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}