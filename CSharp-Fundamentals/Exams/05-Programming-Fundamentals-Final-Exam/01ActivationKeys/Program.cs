using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputKey = Console.ReadLine();

            string commands = string.Empty;

            while (true)
            {
                commands = Console.ReadLine();

                if (commands == "Generate") break;

                string[] splittedData = commands.Split(">>>");

                if (splittedData[0] == "Contains")
                {
                    string substring = splittedData[1];

                    if (inputKey.Contains(substring))
                    {
                        Console.WriteLine($"{inputKey} contains {substring}");
                    }
                    else Console.WriteLine("Substring not found!");
                }

                else if (splittedData[0] == "Flip")
                {
                    string toChange = splittedData[1];
                    int startIndex = int.Parse(splittedData[2]);
                    int endIndex = int.Parse(splittedData[3]);

                    if (toChange == "Upper")
                    {
                        string extractedStr = string.Empty;

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            extractedStr += inputKey[i];
                        }

                        inputKey = inputKey.Remove(startIndex, endIndex - startIndex);

                        inputKey = inputKey.Insert(startIndex, extractedStr.ToUpper());

                        Console.WriteLine(inputKey);
                    }

                    else
                    {
                        string extractedStr = string.Empty;

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            extractedStr += inputKey[i];
                        }

                        inputKey = inputKey.Remove(startIndex, endIndex - startIndex);

                        inputKey = inputKey.Insert(startIndex, extractedStr.ToLower());

                        Console.WriteLine(inputKey);
                    }
                }

                else // to delete
                {
                    int startIndex = int.Parse(splittedData[1]);
                    int endIndex = int.Parse(splittedData[2]);

                    inputKey = inputKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(inputKey);
                }
            }
            Console.WriteLine($"Your activation key is: {inputKey}");
        }
    }
}
