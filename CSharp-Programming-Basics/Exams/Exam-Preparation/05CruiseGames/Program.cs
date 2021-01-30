using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            string playerName = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());

            int cVolley = 0;
            int cTennis = 0;
            int cBadminton = 0;

            double totalPoints = 0;
            double sumVolley = 0;
            double sumTennis = 0;
            double sumBadminton = 0;

            for (int i = 1; i <= playedGames; i++)
            {
                string nameGame = Console.ReadLine();
                int points = int.Parse(Console.ReadLine());
                double pointsIncreesed = 0;


                if (nameGame == "volleyball")
                {
                    pointsIncreesed = 1.0 * (points + (points * 0.07));
                    sumVolley += pointsIncreesed;
                    cVolley++;
                }

                else if (nameGame == "tennis")
                {
                    pointsIncreesed = 1.0 * (points + (points * 0.05));
                    sumTennis += pointsIncreesed;
                    cTennis++;
                }

                else if (nameGame == "badminton")
                {
                    pointsIncreesed = 1.0 * (points + (points * 0.02));
                    sumBadminton += pointsIncreesed;
                    cBadminton++;
                }

                totalPoints += pointsIncreesed;
            }

            double averageVolley = Math.Floor(sumVolley / cVolley);
            double averageTennis = Math.Floor(sumTennis / cTennis);
            double averageBadminton = Math.Floor(sumBadminton / cBadminton);

            if (averageVolley >= 75 && averageTennis >= 75 && averageBadminton >= 75)
            {
                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {Math.Floor(totalPoints)} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {Math.Floor(totalPoints)}.");
            }
        }
    }
}
