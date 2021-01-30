using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine()), counter = 0;
            bool isCorrect = false;

            while (counter < capacity)
            {
                string searchBook = Console.ReadLine();
                counter++;

                if (searchBook == book)
                {
                    Console.WriteLine($"You checked {counter - 1} books and found it.");
                    isCorrect = false;
                    break;
                }
                else
                {
                    isCorrect = true;
                    continue;
                }
            }
            if (isCorrect)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }

        }
    }
}
