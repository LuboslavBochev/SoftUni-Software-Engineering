using System;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] arr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> func = Print;

            foreach (var word in arr)
            {
                func(word);
            }
        }
        static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
