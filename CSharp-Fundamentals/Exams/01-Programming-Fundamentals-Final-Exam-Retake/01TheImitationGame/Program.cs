using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fund_Exam_More
{
    class Program
    {
        static void Main(string[] args)
        {

            string message = Console.ReadLine();

            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "Decode") break;

                string[] commands = command.Split("|");

                string type = commands[0];

                if (type == "Move")
                {
                    int numLetters = int.Parse(commands[1]);

                    string strToMove = message.Substring(0, numLetters);
                    message = message.Remove(0, numLetters);

                    int length = message.Length;
                    message = message.Insert(length, strToMove);
                }

                else if (type == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    string toInsert = commands[2];

                    message = message.Insert(index, toInsert);
                }

                else
                {
                    string str = commands[1];
                    string strToReplace = commands[2];

                    if (message.Contains(str))
                    {
                        message = message.Replace(str, strToReplace);
                    }
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}