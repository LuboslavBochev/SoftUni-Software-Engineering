using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string input = "Stop";
            input = Console.ReadLine();

            while (input != "Stop")
            {
                int nums = int.Parse(input);
                sum += nums;

                input = Console.ReadLine();
            }
            Console.WriteLine(sum);

        }
    }
}
