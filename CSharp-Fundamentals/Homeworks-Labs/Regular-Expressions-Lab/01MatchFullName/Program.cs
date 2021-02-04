using System;
using System.Text.RegularExpressions;

namespace Regular_Ex
{
    class Program
    {
        static void Main(string[] args)
        {

            string patern = @"\b(?<firstWord>[A-Z][a-z]+)\s(?<secondWord>[A-Z][a-z]+)\b";
            string text = Console.ReadLine();

            Regex regex = new Regex(patern);

            MatchCollection matchedNames = regex.Matches(text);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }
        }
    }
}