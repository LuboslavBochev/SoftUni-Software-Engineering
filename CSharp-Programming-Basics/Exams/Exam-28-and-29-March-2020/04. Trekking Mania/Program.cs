using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2:35 min ot predi


            int nGroups = int.Parse(Console.ReadLine());
            int sumOfPeople = 0;

            int musala = 0;
            int monblan = 0;
            int kaliman = 0;
            int k2 = 0;
            int everest = 0;

            for (int i = 1; i <= nGroups; i++)
            {
                int numOfPeople = int.Parse(Console.ReadLine());

                sumOfPeople += numOfPeople;

                if (numOfPeople <= 5)
                {
                    musala += numOfPeople;
                }

                else if (numOfPeople > 5 && numOfPeople <= 12)
                {
                    monblan += numOfPeople;
                }

                else if (numOfPeople >= 13 && numOfPeople <= 25)
                {
                    kaliman += numOfPeople;
                }

                else if (numOfPeople >= 26 && numOfPeople <= 40)
                {
                    k2 += numOfPeople;
                }

                else if (numOfPeople >= 41)
                {
                    everest += numOfPeople;
                }

            }
            Console.WriteLine($"{(1.0 * musala / sumOfPeople * 100):f2}%");
            Console.WriteLine($"{(1.0 * monblan / sumOfPeople * 100):f2}%");
            Console.WriteLine($"{(1.0 * kaliman / sumOfPeople * 100):f2}%");
            Console.WriteLine($"{(1.0 * k2 / sumOfPeople * 100):f2}%");
            Console.WriteLine($"{(1.0 * everest / sumOfPeople * 100):f2}%");
        }
    }
}
