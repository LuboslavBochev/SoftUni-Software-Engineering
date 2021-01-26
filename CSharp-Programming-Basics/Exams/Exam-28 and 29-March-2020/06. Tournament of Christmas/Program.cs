using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2:35 min ot predi

            int tournametDays = int.Parse(Console.ReadLine());
            double totalMoney = 0;
            double total = 0;
            int winGames = 0;
            int loseGames = 0;
            int wins = 0;
            int loses = 0;


            for (int i = 1; i <= tournametDays; i++)
            {
                string sport = Console.ReadLine();
                string result = Console.ReadLine();

                total += totalMoney;
                totalMoney = 0;
                wins = 0;
                loses = 0;

                while (sport != "Finish")
                {

                    if (result == "win")
                    {
                        wins++;
                        winGames++;
                        totalMoney += 20;
                    }

                    else if (result == "lose")
                    {
                        loses++;
                        loseGames++;
                        totalMoney += 0;
                    }

                    sport = Console.ReadLine();

                    if (wins > loses && sport == "Finish")
                    {
                        totalMoney = totalMoney + (totalMoney * 0.1);
                    }

                    if (sport == "Finish")
                    {
                        break;
                    }
                    result = Console.ReadLine();
                }

            }
            total += totalMoney;

            if (winGames > loseGames)
            {
                total = total + (total * 0.2);
                Console.WriteLine($"You won the tournament! Total raised money: {total:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {total:f2}");
            }
        }
    }
}
