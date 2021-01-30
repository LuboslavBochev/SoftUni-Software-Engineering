using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayer = int.Parse(Console.ReadLine());
            int secondPlayer = int.Parse(Console.ReadLine());

            string result = "";

            while (result != "End of battle" && firstPlayer > 0 && secondPlayer > 0)
            {
                result = Console.ReadLine();

                if (result == "one")
                {
                    secondPlayer--;
                }

                else if (result == "two")
                {
                    firstPlayer--;
                }

            }

            if (firstPlayer == 0)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {secondPlayer} eggs left.");
            }

            else if (secondPlayer == 0)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayer} eggs left.");
            }

            else if (result == "End of battle")
            {
                Console.WriteLine($"Player one has {firstPlayer} eggs left.");
                Console.WriteLine($"Player two has {secondPlayer} eggs left.");
            }
        }
    }
}