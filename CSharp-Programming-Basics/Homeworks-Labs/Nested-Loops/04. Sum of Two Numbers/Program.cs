using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int fNum = int.Parse(Console.ReadLine());
            int sNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int counter = 0;
            bool isFound = false;

            for (int i = fNum; i <= sNum; i++)
            {
                for (int j = fNum; j <= sNum; j++)
                {
                    counter++;
                    if (i + j == magicNum)
                    {
                        isFound = true;
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNum})");
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}