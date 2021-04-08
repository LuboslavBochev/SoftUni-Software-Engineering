using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPetrol = int.Parse(Console.ReadLine());

            Queue<string> petrolDistance = new Queue<string>();

            for (int i = 0; i < nPetrol; i++)
            {
                petrolDistance.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < nPetrol; i++)
            {
                bool notEnough = true;
                int currentPetrol = 0;

                for (int j = 0; j < nPetrol; j++)
                {
                    string parts = petrolDistance.Dequeue();
                    string[] toPush = parts.Split(" ").ToArray();
                    petrolDistance.Enqueue(parts);

                    int petrol = int.Parse(toPush[0]);
                    int distance = int.Parse(toPush[1]);

                    currentPetrol += petrol;
                    currentPetrol -= distance;

                    if (currentPetrol < 0)
                    {
                        notEnough = false;
                    }
                }

                if (notEnough)
                {
                    Console.WriteLine(i);
                    break;
                }

                string tempData = petrolDistance.Dequeue();
                petrolDistance.Enqueue(tempData);
            }
        }
    }
}