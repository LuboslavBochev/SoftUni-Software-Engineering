using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RegularExM_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string message = string.Empty;
            string pattern = @"(?<whole>\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*[^\@\-\!\:\>]\!(?<type>[N|G])\!)";

            while (true)
            {
                message = Console.ReadLine();

                if (message == "end") break;

                message = DecryptMessage(message, key);

                Match matchedMessages = Regex.Match(message, pattern);

                if (matchedMessages.Success)
                {
                    string name = matchedMessages.Groups["name"].Value;
                    string type = matchedMessages.Groups["type"].Value;

                    if (type == "G")
                    {
                        Console.WriteLine(name);
                    }
                }
            }

        }

        static string DecryptMessage(string message, int key)
        {
            string decryptedMessage = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                char currentLetter = (char)(message[i] - key);

                decryptedMessage += currentLetter;
            }
            return decryptedMessage;
        }
    }
}