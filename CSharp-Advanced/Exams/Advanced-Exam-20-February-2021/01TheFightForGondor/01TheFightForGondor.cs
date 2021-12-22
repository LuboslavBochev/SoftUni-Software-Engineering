using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                int[] newOrcs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (plates.Count == 0) break;

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                if (plates.Count != 0)
                    orcs = AddOrcs(newOrcs);

                while (plates.Count != 0 && orcs.Count != 0)
                {
                    int plateValue = plates.Peek();
                    int warriorValue = orcs.Peek();

                    if (plateValue > warriorValue)
                    {
                        orcs.Pop();
                        plates.Dequeue();

                        int plateHelth = plateValue - warriorValue;

                        plates = RefactorateQueue(plateHelth, plates);
                    }
                    else if (warriorValue > plateValue)
                    {
                        plates.Dequeue();
                        orcs.Pop();

                        orcs.Push(warriorValue - plateValue);
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                }
            }
            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine("Orcs left: " + string.Join(", ", orcs));
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", plates));
            }
        }

        private static Stack<int> AddOrcs(int[] newOrcs)
        {
            Stack<int> orcs = new Stack<int>();

            foreach (var item in newOrcs)
            {
                orcs.Push(item);
            }
            return orcs;
        }

        private static Queue<int> RefactorateQueue(int plateHelth, Queue<int> plates)
        {
            Queue<int> newPlate = new Queue<int>();

            newPlate.Enqueue(plateHelth);
            foreach (var plate in plates)
            {
                newPlate.Enqueue(plate);
            }
            return newPlate;
        }
    }
}