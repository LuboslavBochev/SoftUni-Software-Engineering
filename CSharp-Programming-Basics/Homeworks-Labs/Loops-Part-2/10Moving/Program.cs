using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string boxes = Console.ReadLine();

            int freeSpace = width * lenght * height;
            int sumBoxes = 0;


            while (boxes != "Done")
            {
                int cBoxes = int.Parse(boxes);

                sumBoxes += cBoxes;

                if (sumBoxes > freeSpace)
                {
                    Console.WriteLine($"No more free space! You need {sumBoxes - freeSpace} Cubic meters more.");
                    break;
                }

                boxes = Console.ReadLine();
            }
            if (freeSpace > sumBoxes)
            {
                Console.WriteLine($"{freeSpace - sumBoxes} Cubic meters left.");
            }
        }
    }
}