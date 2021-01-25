using System;

namespace while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationMoney = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());
            double value = 0;

            bool going = false;
            bool save = false;

            int counter = 0, spendCounter = 0;

            string action = "";


            while (true)
            {
                action = Console.ReadLine();
                value = double.Parse(Console.ReadLine());

                counter++;

                if (action == "spend")
                {
                    balance -= value;
                    spendCounter++;

                    if (balance < 0)
                    {
                        balance = 0;
                    }

                    if (spendCounter == 5)
                    {
                        save = true;
                        break;
                    }
                }

                if (action == "save")
                {
                    balance += value;
                    spendCounter = 0;

                    if (balance >= vacationMoney)
                    {
                        going = true;
                        break;
                    }
                }
            }
            if (save)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(counter);
            }

            if (going)
            {
                Console.WriteLine($"You saved the money for {counter} days.");
            }
        }
    }
}
