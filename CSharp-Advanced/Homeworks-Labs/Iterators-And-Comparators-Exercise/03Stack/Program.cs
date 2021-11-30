using System;
using System.Linq;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(new string[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Push":
                        stack.Push(tokens.Skip(1).ToArray());
                        break;

                    case "Pop":
                        stack.Pop();
                        break;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
