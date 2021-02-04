using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Regular_Ex
{
    class Program
    {
        static void Main(string[] args)
        {

            string patern = @">>(?<word>\w+)<<(?<number>(?:\d+(?:\.\d*)?|\.\d+))!(?<quantity>\d+)";
            double totalMoney = 0.0;

            List<string> nameOfFurniture = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase") break;

                Match furnitures = Regex.Match(input, patern);

                if (furnitures.Success)
                {
                    string name = furnitures.Groups[1].Value;
                    nameOfFurniture.Add(name.ToString());

                    double money = double.Parse(furnitures.Groups[2].Value);
                    double quantity = double.Parse(furnitures.Groups[3].Value);

                    totalMoney += money * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            if (nameOfFurniture.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine, nameOfFurniture));

            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}