using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int collectedItems = 0;

            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Peek();

                if ((firstItem + secondItem) % 2 == 0)
                {
                    collectedItems += firstItem + secondItem;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    secondBox.Pop();
                    firstBox.Enqueue(secondItem);
                }
            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (collectedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectedItems}");
            }
        }
    }
}