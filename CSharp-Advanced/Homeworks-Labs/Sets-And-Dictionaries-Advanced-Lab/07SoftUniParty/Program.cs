using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (true)
            {
                string reservationNums = Console.ReadLine();

                if (reservationNums == "PARTY") break;

                int length = reservationNums.Length;
                char firstLet = reservationNums.First();

                if (char.IsDigit(firstLet) && length == 8)
                {
                    vip.Add(reservationNums);
                }

                else if (length == 8 && char.IsLetter(firstLet))
                {
                    regular.Add(reservationNums);
                }
            }

            HashSet<string> cameInParty = new HashSet<string>();

            while (true)
            {
                string reservationNum = Console.ReadLine();

                if (reservationNum == "END") break;

                cameInParty.Add(reservationNum);
            }

            foreach (var item in cameInParty)
            {
                if (vip.Contains(item))
                {
                    vip.Remove(item);
                }

                if (regular.Contains(item))
                {
                    regular.Remove(item);
                }
            }
            Console.WriteLine(vip.Count + regular.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}