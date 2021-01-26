using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int countKozunak = int.Parse(Console.ReadLine());
            int result = 0;
            int numberOne = 0;
            int counterForOne = 0;
            int winnerResult = 0;

            string winner = "";

            for (int i = 1; i <= countKozunak; i++)
            {
                string name = Console.ReadLine();
                string assessment = Console.ReadLine();

                while (assessment != "Stop")
                {
                    int points = int.Parse(assessment);
                    result += points;
                    counterForOne++;
                    assessment = Console.ReadLine();
                }
                Console.WriteLine($"{name} has {result} points.");

                if (counterForOne == 1)
                {
                    winner = name;
                    Console.WriteLine($"{winner} is the new number 1!");
                }

                if (result > numberOne && counterForOne != 1)
                {
                    Console.WriteLine($"{name} is the new number 1!");
                    winnerResult = result;
                    winner = name;
                }
                numberOne = result;
                result = 0;
            }
            Console.WriteLine($"{winner} won competition with {winnerResult} points!");
        }
    }
}
