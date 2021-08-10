using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int letters = int.Parse(Console.ReadLine());
            string decrypt = string.Empty;

            for (int i = 1; i <= letters; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                letter += (char)key;

                decrypt += letter;
            }
            Console.WriteLine(decrypt);
        }
    }
}