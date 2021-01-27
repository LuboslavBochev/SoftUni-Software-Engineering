using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            int coupon = int.Parse(Console.ReadLine()), buyMovie = 0, buyProduct = 0;

            string product = Console.ReadLine();


            while (product != "End")
            {
                int lenght = product.Length;

                if (lenght > 8)
                {
                    char letter1 = char.Parse(product[0].ToString());
                    char letter2 = char.Parse(product[1].ToString());

                    int sumTwoLetters = (int)letter1 + (int)letter2;

                    if (sumTwoLetters <= coupon)
                    {
                        buyMovie++;
                        coupon -= sumTwoLetters;
                    }

                    else
                    {
                        break;
                    }
                }

                else if (lenght <= 8)
                {
                    char letter1 = char.Parse(product[0].ToString());
                    int sumOneLetter = (int)letter1;

                    if (sumOneLetter <= coupon)
                    {
                        buyProduct++;
                        coupon -= sumOneLetter;
                    }

                    else
                    {
                        break;
                    }
                }

                product = Console.ReadLine();
            }
            Console.WriteLine($"{buyMovie}");
            Console.WriteLine($"{buyProduct}");
        }
    }
}