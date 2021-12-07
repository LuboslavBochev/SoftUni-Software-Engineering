using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> eatingCapacity = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int wastedFood = 0;

            while (plates.Count != 0 && eatingCapacity.Count != 0)
            {
                int eatingCapacityValue = eatingCapacity.Peek();
                int plateValue = plates.Peek();

                if (plateValue >= eatingCapacityValue)
                {
                    wastedFood += plates.Pop() - eatingCapacity.Dequeue();
                }

                else if (plateValue < eatingCapacityValue)
                {
                    while (eatingCapacityValue > 0 && plates.Count != 0)
                    {
                        eatingCapacityValue -= plates.Pop();
                    }
                    if (eatingCapacityValue <= 0)
                    {
                        eatingCapacity.Dequeue();
                        wastedFood += eatingCapacityValue * -1;
                    }
                    else break;
                }
            }

            if (eatingCapacity.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", eatingCapacity)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}