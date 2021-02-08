using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> initialItems = Console.ReadLine().Split("!").ToList();

            string command = null;
            string item = string.Empty;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {

                string[] tokens = command.Split(" ");

                string commands = tokens[0];

                switch (commands)
                {

                    case "Urgent":

                        item = tokens[1];

                        if (!(initialItems.Contains(item)))
                        {
                            initialItems.Insert(0, item);
                        }

                        break;

                    case "Unnecessary":

                        item = tokens[1];

                        if (initialItems.Contains(item))
                        {
                            initialItems.Remove(item);
                        }

                        break;

                    case "Correct":

                        string oldItem = tokens[1];
                        string newItem = tokens[2];

                        if (initialItems.Contains(oldItem) && !(initialItems.Contains(newItem)))
                        {

                            int index = initialItems.IndexOf(oldItem);
                            initialItems.RemoveAt(index);

                            initialItems.Insert(index, newItem);
                        }

                        break;

                    case "Rearrange":

                        item = tokens[1];

                        if (initialItems.Contains(item))
                        {
                            initialItems.Remove(item);
                            initialItems.Add(item);
                        }

                        break;
                }
            }

            for (int i = 0; i < initialItems.Count; i++)
            {
                if (i + 1 == initialItems.Count)
                {
                    Console.Write(initialItems[i]);
                }
                else Console.Write(initialItems[i] + ", ");
            }
        }
    }
}