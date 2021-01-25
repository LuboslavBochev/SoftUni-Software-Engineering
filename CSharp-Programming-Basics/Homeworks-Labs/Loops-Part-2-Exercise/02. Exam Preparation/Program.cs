using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int cBadGrades = int.Parse(Console.ReadLine()), grades = 0, sum = 0, counter = 0, bCounter = 0;
            string nameTask = "";
            string lastProblem = "";
            bool badGrades = false;

            double average = 0;

            while (nameTask != "Enough")
            {
                nameTask = Console.ReadLine();
                if (nameTask == "Enough")
                {
                    break;
                }
                grades = int.Parse(Console.ReadLine());

                if (grades <= 4)
                {
                    bCounter++;
                    sum += grades;
                    counter++;
                }
                if (bCounter == cBadGrades)
                {
                    badGrades = true;
                    break;
                }


                else if (grades > 4)
                {
                    sum += grades;
                    counter++;
                }
                lastProblem = nameTask;

            }

            average = (double)sum / counter;

            if (badGrades)
            {
                Console.WriteLine($"You need a break, {bCounter} poor grades.");
            }

            else
            {
                Console.WriteLine($"Average score: {average:f2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}