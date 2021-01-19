using System;

namespace _07._Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double wiskeyprice = double.Parse(Console.ReadLine());
            double quantitybeer = double.Parse(Console.ReadLine());
            double quantitywine = double.Parse(Console.ReadLine());
            double quantityrakia = double.Parse(Console.ReadLine());
            double quantitywiskey = double.Parse(Console.ReadLine());

            double rakiaprice = wiskeyprice / 2;
            double wineprice = rakiaprice - (rakiaprice * 0.4);
            double beerprice = rakiaprice - (rakiaprice * 0.8);

            double sumforwiskey = wiskeyprice * quantitywiskey;
            double sumforwine = wineprice * quantitywine;
            double sumforrakia = rakiaprice * quantityrakia;
            double sumforbeer = beerprice * quantitybeer;

            double amount = sumforwiskey + sumforbeer + sumforrakia + sumforwine;

            Console.WriteLine($"{amount:f2}");
        }
    }
}
