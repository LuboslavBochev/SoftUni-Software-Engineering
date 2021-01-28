using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            int cMovies = int.Parse(Console.ReadLine());

            string theBestMovie = "";
            string poorMovie = "";
            string nameMovie = "";
            double raiting = 0;
            double highestRaiting = 1;
            double lowestRaiting = 11;
            double sum = 0;

            for (int i = 1; i <= cMovies; i++)
            {
                nameMovie = Console.ReadLine();
                raiting = double.Parse(Console.ReadLine());
                sum += raiting;

                if (raiting > highestRaiting)
                {
                    highestRaiting = raiting;
                    theBestMovie = nameMovie;
                }

                if (raiting < lowestRaiting)
                {
                    lowestRaiting = raiting;
                    poorMovie = nameMovie;
                }
            }

            double averageRaiting = sum / cMovies;

            Console.WriteLine($"{theBestMovie} is with highest rating: {highestRaiting:f1}");
            Console.WriteLine($"{poorMovie} is with lowest rating: {lowestRaiting:f1}");
            Console.WriteLine($"Average rating: {averageRaiting:f1}");
        }
    }
}