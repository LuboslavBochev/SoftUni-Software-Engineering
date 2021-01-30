using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {

            string town = Console.ReadLine();
            double volumeofsales = double.Parse(Console.ReadLine());


            double comision = 0.0;

            switch (town)
            {
                case "Sofia":
                    {
                        if (volumeofsales >= 0 && volumeofsales <= 500) comision = volumeofsales * 0.05;
                        else if (volumeofsales > 500 && volumeofsales <= 1000) comision = 0.07 * volumeofsales;
                        else if (volumeofsales > 1000 && volumeofsales <= 10000) comision = volumeofsales * 0.08;
                        else if (volumeofsales > 10000) comision = volumeofsales * 0.12;
                        if (comision == 0) Console.WriteLine("error");
                        else Console.WriteLine($"{comision:f2}");
                        break;
                    }

                case "Varna":
                    {
                        if (volumeofsales >= 0 && volumeofsales <= 500) comision = volumeofsales * 0.045;
                        else if (volumeofsales > 500 && volumeofsales <= 1000) comision = 0.075 * volumeofsales;
                        else if (volumeofsales > 1000 && volumeofsales <= 10000) comision = volumeofsales * 0.10;
                        else if (volumeofsales > 10000) comision = volumeofsales * 0.13;
                        if (comision == 0) Console.WriteLine("error");
                        else Console.WriteLine($"{comision:f2}");
                        break;
                    }
                case "Plovdiv":
                    {
                        if (volumeofsales >= 0 && volumeofsales <= 500) comision = volumeofsales * 0.055;
                        else if (volumeofsales > 500 && volumeofsales <= 1000) comision = 0.08 * volumeofsales;
                        else if (volumeofsales > 1000 && volumeofsales <= 10000) comision = volumeofsales * 0.12;
                        else if (volumeofsales > 10000) comision = volumeofsales * 0.145;
                        if (comision == 0) Console.WriteLine("error");
                        else Console.WriteLine($"{comision:f2}");
                        break;
                    }
                default:
                    Console.WriteLine("error");
                    break;
            }
        }

    }
}
