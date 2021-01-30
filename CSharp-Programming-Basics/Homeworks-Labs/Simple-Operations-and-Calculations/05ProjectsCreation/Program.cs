using System;

namespace _05._Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numprojects = int.Parse(Console.ReadLine());

            int time = numprojects * 3;

            Console.WriteLine($"The architect {name} will need {time} hours to complete {numprojects} project/s.");
        }
    }
}
