using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {

            int judgers = int.Parse(Console.ReadLine()), counter = 0, numbers = 0;
            string nameOfPresentation = "";
            double averagePresentation = 0;
            double averageTotal = 0;
            double sum = 0;
            bool isFinish = false;

            while (true)
            {
                averagePresentation = 0;
                sum = 0;
                counter = 0;

                nameOfPresentation = Console.ReadLine();

                if (nameOfPresentation == "Finish")
                {
                    isFinish = true;
                    break;
                }
                numbers++;

                for (int i = 1; i <= judgers; i++)
                {
                    double marks = double.Parse(Console.ReadLine());
                    sum += marks;
                    counter++;
                }

                averagePresentation = sum / counter;
                averageTotal += averagePresentation;
                Console.WriteLine($"{nameOfPresentation} - {averagePresentation:f2}.");

            }


            if (isFinish)
            {
                averageTotal = averageTotal / numbers;
                Console.WriteLine($"Student's final assessment is {averageTotal:f2}.");
            }
        }
    }
}