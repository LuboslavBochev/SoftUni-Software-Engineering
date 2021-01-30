using System;

namespace _08._Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double semdohod = double.Parse(Console.ReadLine());
            double uspeh = double.Parse(Console.ReadLine());
            double minsalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(minsalary * 0.35);
            double scholarship = Math.Floor(uspeh * 25);

            if (uspeh >= 5.5)
            {
                if (scholarship >= socialScholarship || semdohod > minsalary)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
            }
            else if (uspeh > 4.5 && semdohod < minsalary)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
