using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;
            string check = string.Empty;

            int openBracket = 0;
            int closeBraket = 0;

            for (int i = 1; i <= n; i++)
            {
                string symbol = Console.ReadLine();

                if (check == symbol)
                {
                    if (symbol == "(") break;
                    continue;
                }

                if (symbol == "(" || symbol == ")")
                {
                    if (symbol == "(")
                    {
                        openBracket++;
                        check = symbol;
                    }
                    else
                    {
                        closeBraket++;
                        check = symbol;
                    }
                }
            }

            if (openBracket == closeBraket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}