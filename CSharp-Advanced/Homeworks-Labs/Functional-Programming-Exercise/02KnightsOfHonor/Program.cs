using System;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] arr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> func = x => Console.WriteLine("Sir " + x);

            foreach (var word in arr)
            {
                func(word);
            }
        }
    }
}