using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string cSteps = Console.ReadLine();
            int sum = 0, numSteps = 0;
            bool ghome = false;
            bool complete = false;

            while (true)
            {
                if (cSteps == "Going home")
                {
                    numSteps = int.Parse(Console.ReadLine());
                    sum += numSteps;
                    ghome = true;
                    break;
                }

                numSteps = int.Parse(cSteps);

                sum += numSteps;

                if (sum >= 10000)
                {
                    complete = true;
                    break;
                }
                cSteps = Console.ReadLine();
            }

            if (ghome)
            {
                if (sum >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                }
                else Console.WriteLine($"{10000 - sum} more steps to reach goal.");
            }

            if (complete)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
        }
    }
}