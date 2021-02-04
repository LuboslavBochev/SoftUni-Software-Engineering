using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Regular_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneString = Console.ReadLine();
            string patern = @"\+359(\s|-)2\1\d{3}\1\d{4}\b";

            MatchCollection phoneCollection = Regex.Matches(phoneString, patern);

            var phoneList = phoneCollection.Cast<Match>().Select(value => value.Value.Trim()).ToList();

            Console.WriteLine(string.Join(", ", phoneList));
        }
    }
}