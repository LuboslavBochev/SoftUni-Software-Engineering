using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int initialEnergy = int.Parse(Console.ReadLine());

            string command = null;
            int count = 0;

            bool noEnergy = false;

            while ((command = Console.ReadLine()) != "End of battle")
            {

                int distance = int.Parse(command);

                if (initialEnergy < distance)
                {
                    noEnergy = true;
                    break;
                }

                initialEnergy -= distance;
                count++;

                if (count % 3 == 0 && count != 0)
                {
                    initialEnergy += count;
                }
            }

            if (noEnergy)
            {
                Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {initialEnergy} energy");
            }

            else
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {initialEnergy}");
            }
        }
    }
}