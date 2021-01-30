using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int sumPieces = 0;
            int size = width * lenght;

            string addPiece = Console.ReadLine();

            while (addPiece != "STOP")
            {
                int numPiece = int.Parse(addPiece);

                sumPieces += numPiece;

                if (sumPieces > size)
                {
                    Console.WriteLine($"No more cake left! You need {sumPieces - size} pieces more.");
                    break;
                }

                addPiece = Console.ReadLine();
            }

            if (addPiece == "STOP")
            {
                Console.WriteLine($"{size - sumPieces} pieces are left.");
            }
        }
    }
}