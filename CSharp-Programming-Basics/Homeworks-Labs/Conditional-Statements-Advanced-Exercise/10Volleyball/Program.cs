using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {

            string year = Console.ReadLine();
            int cCelebrate = int.Parse(Console.ReadLine());
            int cWeekends = int.Parse(Console.ReadLine());


            int countWeekends = 48 - cWeekends;
            double weekendPlay = countWeekends * 0.75;

            double celebratePlay = cCelebrate * 0.6666666666666667;

            double totalPlays = 0;

            switch (year)
            {
                case "normal":

                    totalPlays = weekendPlay + celebratePlay + (48 - countWeekends);

                    break;

                case "leap":

                    totalPlays = weekendPlay + celebratePlay + (48 - countWeekends);

                    totalPlays = totalPlays + (totalPlays * 0.15);

                    break;


                default:
                    break;
            }

            if (year == "normal")
            {
                Console.WriteLine(Math.Floor(totalPlays));
            }

            else if (year == "leap")
            {
                Console.WriteLine(Math.Floor(totalPlays));
            }

        }
    }
}


