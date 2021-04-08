using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            Stack<string> parentheses = new Stack<string>();

            bool isCorrect = true;

            for (int i = 0; i < sequence.Length; i++)
            {
                string current = sequence[i].ToString();

                switch (current)
                {
                    case "{":

                        parentheses.Push("}");

                        break;

                    case "[":

                        parentheses.Push("]");

                        break;

                    case "(":

                        parentheses.Push(")");

                        break;

                    case "}":
                    case "]":
                    case ")":

                        if (parentheses.Count == 0)
                        {
                            isCorrect = false;
                            break;
                        }

                        if (parentheses.Pop() != current)
                        {
                            isCorrect = false;
                        }

                        break;
                }
                if (!isCorrect)
                {
                    break;
                }
            }

            if (isCorrect) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}