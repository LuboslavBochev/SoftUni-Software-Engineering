using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            string initialText = Console.ReadLine();

            string commands = string.Empty;

            while (true)
            {
                commands = Console.ReadLine();

                if (commands == "Travel") break;

                string[] tokens = commands.Split(":");

                if (tokens[0] == "Add Stop")
                {
                    string strToInsert = tokens[2];
                    int indexToPut = int.Parse(tokens[1]);

                    if (indexToPut >= 0 && indexToPut < initialText.Length) // valid index
                    {
                        initialText = initialText.Insert(indexToPut, strToInsert);
                    }
                    Console.WriteLine(initialText);
                }

                else if (tokens[0] == "Remove Stop")
                {

                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if ((startIndex >= 0 && startIndex < initialText.Length) && (endIndex >= 0 && endIndex < initialText.Length))
                    {
                        initialText = initialText.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine(initialText);
                }

                else
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];

                    if (initialText.Contains(oldString))
                    {
                        initialText = initialText.Replace(oldString, newString);
                    }
                    Console.WriteLine(initialText);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {initialText}");
        }
    }
}