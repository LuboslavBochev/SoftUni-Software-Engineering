using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeProjection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double value = 0.0;

            if (typeProjection == "Premiere")
            {
                value = rows * columns * 12.00;
            }
            else if (typeProjection == "Normal")
            {
                value = rows * columns * 7.50;
            }
            else
            {
                value = rows * columns * 5.00;
            }
            Console.WriteLine($"{value:f2} leva");
        }

    }
}
