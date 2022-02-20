using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End") break;

                IPerson person = new Citizen(input[0], input[1], int.Parse(input[2]));
                IResident resident = new Citizen(input[0], input[1], int.Parse(input[2]));

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
