using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeroom = Console.ReadLine();
            string raiting = Console.ReadLine();


            double total = 0.0;
            double amount = 0.0;
            double discount = 0.0;
            if (typeroom == "room for one person")
            {
                amount = (days - 1) * 18.00;

                if (raiting == "positive")
                {
                    discount = (amount * 0.25);
                    total = amount + discount;
                }
                else if (raiting == "negative")
                {
                    discount = amount * 0.1;
                    total = amount - discount;
                }
            }
            else if (typeroom == "apartment")
            {
                if (days <= 10)
                {
                    amount = (days - 1) * 25.00; //without discount
                    discount = amount * 0.3; //with discount
                    total = amount - discount;
                    discount = 0.0;
                    if (raiting == "positive")
                    {
                        discount = total * 0.25;
                        total = total + discount;
                    }
                    else if (raiting == "negative")
                    {
                        discount = total * 0.1;
                        total = total - discount;
                    }
                }
                else if (days > 10 && days <= 15)
                {
                    amount = (days - 1) * 25.00; //without discount
                    discount = amount * 0.35; //with discount
                    total = amount - discount;
                    discount = 0.0;
                    if (raiting == "positive")
                    {
                        discount = total * 0.25;
                        total = total + discount;
                    }
                    else if (raiting == "negative")
                    {
                        discount = total * 0.1;
                        total = total - discount;
                    }
                }
                else if (days > 15)
                {
                    amount = (days - 1) * 25.00; //without discount
                    discount = amount * 0.5; //with discount
                    total = amount - discount;
                    discount = 0.0;
                    if (raiting == "positive")
                    {
                        discount = total * 0.25;
                        total = total + discount;
                    }
                    else if (raiting == "negative")
                    {
                        discount = total * 0.1;
                        total = total - discount;
                    }
                }
            }
            else if (typeroom == "president apartment")
            {
                if (days <= 10)
                {
                    amount = (days - 1) * 35.00; //without discount
                    discount = amount * 0.1; //with discount
                    total = amount - discount;
                    discount = 0.0;
                    if (raiting == "positive")
                    {
                        discount = total * 0.25;
                        total = total + discount;
                    }
                    else if (raiting == "negative")
                    {
                        discount = total * 0.1;
                        total = total - discount;
                    }
                }
                else if (days > 10 && days <= 15)
                {
                    amount = (days - 1) * 35.00; //without discount
                    discount = amount * 0.15; //with discount
                    total = amount - discount;
                    discount = 0.0;
                    if (raiting == "positive")
                    {
                        discount = total * 0.25;
                        total = total + discount;
                    }
                    else if (raiting == "negative")
                    {
                        discount = total * 0.1;
                        total = total - discount;
                    }
                }
                else if (days > 15)
                {
                    amount = (days - 1) * 35.00; //without discount
                    discount = amount * 0.2; //with discount
                    total = amount - discount;
                    discount = 0.0;
                    if (raiting == "positive")
                    {
                        discount = total * 0.25;
                        total = total + discount;
                    }
                    else if (raiting == "negative")
                    {
                        discount = total * 0.1;
                        total = total - discount;
                    }
                }

            }
            Console.WriteLine($"{total:f2}");
        }

    }
}
