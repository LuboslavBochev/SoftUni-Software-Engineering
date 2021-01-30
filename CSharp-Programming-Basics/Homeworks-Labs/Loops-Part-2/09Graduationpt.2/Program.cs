using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            double average = 0, sum = 0;
            int counter = 1, cExcluded = 0;
            bool isExcluded = false;

            while (counter <= 12)
            {
                double grades = double.Parse(Console.ReadLine());

                if (grades < 4.00)
                {
                    cExcluded++;

                    if (cExcluded > 1)
                    {
                        isExcluded = true;
                        break;
                    }

                    else continue;
                }

                else
                {
                    sum += grades;
                    counter++;
                }

            }
            if (isExcluded)
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }
            else
            {
                average = sum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }
        }
    }
}