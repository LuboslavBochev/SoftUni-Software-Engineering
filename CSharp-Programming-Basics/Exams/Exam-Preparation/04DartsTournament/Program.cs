using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());

            int count = 0;
            int sumScore = 0;
            bool won = false;
            bool lose = false;
            bool center = false;

            while (true)
            {
                string sector = Console.ReadLine();

                if (sector == "bullseye")
                {
                    center = true;
                    count++;
                    break;
                }
                int score = int.Parse(Console.ReadLine());

                switch (sector)
                {

                    case "number section":

                        sumScore += score;
                        count++;

                        break;

                    case "double ring":

                        sumScore += score * 2;
                        count++;

                        break;

                    case "triple ring":

                        sumScore += score * 3;
                        count++;

                        break;

                }
                points -= sumScore;

                sumScore = 0;

                if (center)
                {
                    break;
                }
                if (points == 0)
                {
                    won = true;
                    break;
                }
                if (points < 0)
                {
                    lose = true;
                    break;
                }

            }

            if (center)
            {
                Console.WriteLine($"Congratulations! You won the game with a bullseye in {count} moves!");
            }

            if (won)
            {
                Console.WriteLine($"Congratulations! You won the game in {count} moves!");
            }

            if (lose)
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(points)}.");
            }

        }
    }
}