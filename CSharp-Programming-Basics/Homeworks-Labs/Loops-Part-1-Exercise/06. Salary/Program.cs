using System;

namespace loops2
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int fine = 0;
            int total = 0;
            bool salaryOff = false;

            for (int i = 1; i <= openTabs; i++)
            {

                if (salaryOff)
                {
                    continue;
                }
                string websites = Console.ReadLine();

                switch (websites)
                {

                    case "Facebook":

                        fine += 150;
                        total = salary - fine;

                        if (total <= 0)
                        {
                            salaryOff = true;
                        }

                        break;

                    case "Instagram":

                        fine += 100;
                        total = salary - fine;

                        if (total <= 0)
                        {
                            salaryOff = true;
                        }
                        break;

                    case "Reddit":

                        fine += 50;
                        total = salary - fine;

                        if (total <= 0)
                        {
                            salaryOff = true;
                        }
                        break;
                }

            }

            if (salaryOff)
            {
                Console.WriteLine("You have lost your salary.");
            }

            else if (total == 0)
            {
                total = salary;
                Console.WriteLine(total);
            }
            else
            {
                Console.WriteLine(total);
            }
        }
    }
}