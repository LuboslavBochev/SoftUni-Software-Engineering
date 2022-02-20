using System;

namespace Phone
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urlAddreses = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var phone in phones)
            {
                try
                {
                    if (phone.Length == 10)
                    {
                        ICall smartPhone = new Smartphone();
                        Console.WriteLine(smartPhone.Calling(phone));
                    }
                    else if (phone.Length == 7)
                    {
                        ICall stationaryPhone = new StationaryPhone();
                        Console.WriteLine(stationaryPhone.Calling(phone));
                    }
                    else Console.WriteLine(Validator.INVALID_NUMBER);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var address in urlAddreses)
            {
                try
                {
                    IBrowse smartPhone = new Smartphone();
                    Console.WriteLine(smartPhone.Browsing(address));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
