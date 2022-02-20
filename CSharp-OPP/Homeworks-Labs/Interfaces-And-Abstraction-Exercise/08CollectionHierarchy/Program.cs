using System;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in input) // adding
            {
                Console.Write(addCollection.AddItem(element) + " ");
            }
            Console.WriteLine();
            foreach (var element in input)
            {
                Console.Write(addRemoveCollection.AddItem(element) + " ");
            }
            Console.WriteLine();
            foreach (var element in input)
            {
                Console.Write(myList.AddItem(element) + " ");
            }

            Console.WriteLine();
            int numberToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberToRemove; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < numberToRemove; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
        }
    }
}
