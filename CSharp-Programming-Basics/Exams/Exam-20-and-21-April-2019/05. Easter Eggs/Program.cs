using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            int paintEggs = int.Parse(Console.ReadLine()), red = 0, green = 0, orange = 0, blue = 0, max = 0;
            string color = "";
            string winnerColor = "";

            max = red;

            for (int i = 1; i <= paintEggs; i++)
            {
                color = Console.ReadLine();

                if (color == "red")
                {
                    red++;

                    if (max < red)
                    {
                        max = red;
                        winnerColor = color;
                    }
                }

                else if (color == "green")
                {
                    green++;

                    if (max < green)
                    {
                        max = green;
                        winnerColor = color;
                    }
                }

                else if (color == "orange")
                {
                    orange++;

                    if (max < orange)
                    {
                        max = orange;
                        winnerColor = color;
                    }
                }

                else if (color == "blue")
                {
                    blue++;

                    if (max < blue)
                    {
                        max = blue;
                        winnerColor = color;
                    }
                }
            }
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {max} -> {winnerColor}");
        }
    }
}
