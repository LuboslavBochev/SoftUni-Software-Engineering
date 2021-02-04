using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegualarEx_3
{
    class Program
    {
        static void Main(string[] args)
        {

            int numMessages = int.Parse(Console.ReadLine());
            string pattern = @"@(?<planetName>[A-Za-z]+)[^@\-!:>]*:(?<pupolation>\d+)[^@\-!:>]*![^@\-!:>]*(?<type>[A|D])[^@\-!:>]*![^@\-!:>]*->(?<soldierCount>\d+)";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numMessages; i++)
            {
                string encryptedMessage = Console.ReadLine();
                int key = GetKey(encryptedMessage);

                string decryptedMessage = DecryptMessage(key, encryptedMessage);

                Match matchMessage = Regex.Match(decryptedMessage, pattern);

                if (matchMessage.Success)
                {
                    string type = matchMessage.Groups[3].Value;
                    string planetName = matchMessage.Groups[1].Value;

                    if (type == "A") attackedPlanets.Add(planetName);
                    else destroyedPlanets.Add(planetName);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count > 0)
            {
                foreach (var item in attackedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {item}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count > 0)
            {
                foreach (var item in destroyedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {item}");
                }
            }
        }

        static string DecryptMessage(int key, string encryptedMessage)
        {
            string newMessage = string.Empty;

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                char currentPossition = (char)(encryptedMessage[i] - key);
                newMessage += currentPossition;
            }
            return newMessage;
        }

        static int GetKey(string encryptedMessage)
        {
            string patern = @"[starSTAR]";

            MatchCollection message = Regex.Matches(encryptedMessage, patern);

            return message.Count;
        }
    }
}