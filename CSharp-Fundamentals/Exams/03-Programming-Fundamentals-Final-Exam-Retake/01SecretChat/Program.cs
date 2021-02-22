using System;

namespace Final_Fund_Exam_More
{
    class Program
    {
        static void Main(string[] args)
        {

            string initialMessage = Console.ReadLine();

            string commands = string.Empty;

            while (true)
            {
                commands = Console.ReadLine();

                if (commands == "Reveal") break;

                string[] tokens = commands.Split(":|:");

                string command = tokens[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);

                    initialMessage = initialMessage.Insert(index, " ");
                    Console.WriteLine(initialMessage);
                }

                else if (command == "Reverse")
                {
                    string subStr = tokens[1];

                    if (initialMessage.Contains(subStr))
                    {
                        int startIndex = initialMessage.IndexOf(subStr);
                        int length = subStr.Length;

                        initialMessage = initialMessage.Remove(startIndex, length);

                        string reversedSubStr = string.Empty;

                        for (int i = subStr.Length - 1; i >= 0; i--)
                        {
                            reversedSubStr += subStr[i].ToString();
                        }

                        initialMessage = initialMessage.Insert(initialMessage.Length, reversedSubStr);
                        Console.WriteLine(initialMessage);
                    }
                    else Console.WriteLine("error");
                }

                else
                {
                    string subStr = tokens[1];
                    string replacement = tokens[2];

                    initialMessage = initialMessage.Replace(subStr, replacement);
                    Console.WriteLine(initialMessage);
                }
            }

            Console.WriteLine($"You have a new text message: {initialMessage}");
        }
    }
}