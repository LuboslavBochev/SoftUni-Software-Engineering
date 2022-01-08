using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList(new List<string>() { "eho", "zdr", "da", "ne", "dobre"});

            Console.WriteLine(list.RandomString());
        }
    }
}
