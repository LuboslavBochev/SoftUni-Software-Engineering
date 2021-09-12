using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filtered = text => char.IsUpper(text[0]);

            string text = Console.ReadLine();

            string[] word = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            word = word.Where(filtered).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, word));
        }
    }
}
