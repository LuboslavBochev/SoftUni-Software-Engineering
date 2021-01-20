using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            //input 
            string product = Console.ReadLine();
            string type = "";
            //checking if it's fruit , vegetable or unknown
            if (product == "banana" || product == "apple" || product == "kiwi" || product == "cherry" || product == "lemon" || product == "grapes")
            {
                type = "fruit";
            }
            else if (product == "tomato" || product == "cucumber" || product == "pepper" || product == "carrot")
            {
                type = "vegetable";
            }
            else Console.WriteLine("unknown");
            Console.WriteLine(type);
        }

    }
}
