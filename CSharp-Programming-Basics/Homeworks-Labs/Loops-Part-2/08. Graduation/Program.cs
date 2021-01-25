using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            double average = 0, counter = 1, sum = 0;

            while (counter <= 12)
            {
                double grades = double.Parse(Console.ReadLine());

                if (grades < 4.00)
                {
                    continue;
                }

                else
                {
                    sum += grades;
                    counter++;
                }

            }
            average = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:f2}");


        }
    }
}