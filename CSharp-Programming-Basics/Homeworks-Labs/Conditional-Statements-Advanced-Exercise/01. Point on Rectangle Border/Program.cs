using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            // input x1,y1,x2,y2,x,y
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool fCondition = (x == x1 || x == x2) && (y >= y1 && y <= y2);
            bool sCondition = (y == y1 || y == y2) && (x >= x1 && x <= x2);

            if (fCondition || sCondition)
            {
                Console.WriteLine("Border");
            }
            else Console.WriteLine("Inside / Outside");
        }

    }
}
