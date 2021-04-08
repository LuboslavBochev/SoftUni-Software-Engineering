using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locksArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArr);
            Queue<int> locks = new Queue<int>(locksArr);

            int bulletCount = 0;
            int clip = gunBarrel;

            bool bulletsRanOut = false;

            while (true)
            {
                if (clip == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    clip = gunBarrel;
                }

                if (bullets.Count == 0)
                {
                    bulletsRanOut = true;
                    break;
                }

                if (locks.Count == 0)
                {
                    break;
                }

                int currentBullet = bullets.Pop();
                bulletCount++;
                clip--;

                if (currentBullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }

                else
                {
                    Console.WriteLine("Ping!");
                }
            }

            int bulletCost = bulletPrice * bulletCount;

            if (bulletsRanOut)
            {
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - bulletCost}");
                }

                else Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

            else
            {
                bulletCost = bulletPrice * bulletCount;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - bulletCost}");
            }

        }
    }
}