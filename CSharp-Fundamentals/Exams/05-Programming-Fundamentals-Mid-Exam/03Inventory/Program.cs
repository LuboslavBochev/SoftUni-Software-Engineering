using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> items = Console.ReadLine().Split(", ").ToList();

            string commands = null;

            while ((commands = Console.ReadLine()) != "Craft!")
            {

                string[] tokens = commands.Split(" - ");

                string command = tokens[0];
                string item = null;

                switch (command)
                {

                    case "Collect":

                        item = tokens[1];

                        if (!(items.Contains(item)))
                        {
                            items.Add(item);
                        }

                        break;

                    case "Drop":

                        item = tokens[1];

                        if (items.Contains(item))
                        {
                            items.Remove(item);
                        }

                        break;

                    case "Combine Items":

                        string[] combineSplit = tokens[1].Split(":");

                        string oldItem = combineSplit[0];
                        string newItem = combineSplit[1];

                        if (items.Contains(oldItem))
                        {
                            int indexOldItem = items.IndexOf(oldItem);

                            items.Insert(indexOldItem + 1, newItem);
                        }

                        break;

                    case "Renew":

                        item = tokens[1];

                        if (items.Contains(item))
                        {
                            items.Remove(item);
                            items.Add(item);
                        }

                        break;
                }
            }
            for (int i = 0; i < items.Count; i++)
            {
                if (i + 1 == items.Count)
                {
                    Console.Write(items[i]);
                }
                else Console.Write(items[i] + ", ");
            }
        }
    }
}