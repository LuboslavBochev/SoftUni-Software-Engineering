using System;

namespace _07._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double kvm = double.Parse(Console.ReadLine());
            double discount = 0.18;
            double sum = kvm * 7.61;

            double discountsum = discount * sum;

            double result = sum - discountsum;

            Console.WriteLine($"The final price is: {result:f2} lv.");
            Console.WriteLine($"The discount is: {discountsum:f2} lv.");
        }
    }
}
