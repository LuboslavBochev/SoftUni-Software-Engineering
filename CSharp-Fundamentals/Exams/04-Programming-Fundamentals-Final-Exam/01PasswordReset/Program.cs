using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            string initialText = Console.ReadLine();
            StringBuilder rawPass = new StringBuilder();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "Done") break;

                string[] tokens = commands.Split(" ");

                if (tokens[0] == "TakeOdd")
                {

                    for (int i = 1; i < initialText.Length; i += 2)
                    {
                        rawPass.Append(initialText[i]);
                    }

                    initialText = rawPass.ToString();

                    Console.WriteLine(initialText);
                }

                else if (tokens[0] == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);

                    initialText = initialText.Remove(index, length);
                    Console.WriteLine(initialText);
                }

                else // Substitute
                {
                    string subStringToReplace = tokens[1];

                    if (initialText.Contains(subStringToReplace))
                    {
                        string toReplace = tokens[2];

                        initialText = initialText.Replace(subStringToReplace, toReplace);
                        Console.WriteLine(initialText);
                    }

                    else Console.WriteLine("Nothing to replace!");
                }
            }
            Console.WriteLine($"Your password is: {initialText}");
        }
    }
}