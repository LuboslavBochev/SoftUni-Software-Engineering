using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());


            for (int num1 = 1; num1 <= n; num1++)
            {
                for (int num2 = 1; num2 <= n; num2++)
                {
                    for (int letter = 97; letter < 97 + l; letter++)
                    {
                        for (int letter2 = 97; letter2 < 97 + l; letter2++)
                        {
                            for (int num3 = 1; num3 <= n; num3++)
                            {
                                if (num3 > num1 && num3 > num2)
                                {
                                    Console.Write($"{num1}{num2}{(char)letter}{(char)letter2}{num3}" + " ");
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}