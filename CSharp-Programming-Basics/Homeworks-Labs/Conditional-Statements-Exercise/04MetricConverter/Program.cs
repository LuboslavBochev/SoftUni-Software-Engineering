using System;

namespace _04._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double result = 0.0;

            string input = Console.ReadLine();
            string output = Console.ReadLine();

            //mm , m , sm

            if (input == "mm" && output == "cm") // --> sm -->m
            {
                result = number / 10;
            }
            else if (input == "mm" && output == "m") result = number / 1000;

            else if (input == "cm" && output == "mm") result = number * 10;
            else if (input == "cm" && output == "m") result = number / 100;

            else if (input == "m" && output == "cm") result = number * 100;
            else if (input == "m" && output == "mm") result = number * 1000;


            Console.WriteLine($"{result:f3}");
        }
    }
}
