using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thridEmployee = int.Parse(Console.ReadLine());

            int people = int.Parse(Console.ReadLine());

            int answerPerHour = firstEmployee + secondEmployee + thridEmployee;

            int hours = 0;

            while (people > 0)
            {
                hours++;

                if (hours % 4 == 0 && hours != 0)
                {
                    continue;
                }
                people -= answerPerHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}