using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2:35 min ot predi

            int quantityFood = int.Parse(Console.ReadLine());
            string eatedFood = "";

            int sum = 0;
            bool isAdopted = false;

            while (eatedFood != "Adopted")
            {
                eatedFood = Console.ReadLine();
                if (eatedFood == "Adopted")
                {
                    isAdopted = true;
                    break;
                }

                int eatedGrams = int.Parse(eatedFood);
                sum += eatedGrams;
            }

            if (isAdopted)
            {
                int toGrams = quantityFood * 1000;

                if (toGrams >= sum)
                {
                    Console.WriteLine($"Food is enough! Leftovers: {toGrams - sum} grams.");
                }
                else
                {
                    Console.WriteLine($"Food is not enough. You need {sum - toGrams} grams more.");
                }
            }

        }
    }
}
