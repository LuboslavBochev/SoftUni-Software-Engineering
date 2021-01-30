using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string input = "";

            while (input != password)
            {
                input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine("Welcome " + username + "!");
                    break;
                }
            }

        }
    }
}
