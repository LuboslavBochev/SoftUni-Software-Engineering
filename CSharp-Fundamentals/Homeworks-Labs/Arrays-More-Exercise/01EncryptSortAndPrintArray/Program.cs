using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            string words = string.Empty;

            int[] code = new int[nums];

            for (int i = 0; i < nums; i++)
            {
                int result = 0;
                words = Console.ReadLine();
                char[] letters = words.ToCharArray();

                for (int j = 0; j < words.Length; j++)
                {
                    if (letters[j] == 'e' || letters[j] == 'o' || letters[j] == 'i' || letters[j] == 'a' || letters[j] == 'u'
                        || letters[j] == 'E' || letters[j] == 'O' || letters[j] == 'I' || letters[j] == 'A' || letters[j] == 'U')
                    {
                        result += (int)letters[j] * words.Length;
                    }

                    else
                    {
                        result += (int)letters[j] / words.Length;
                    }
                }

                code[i] = result;
            }

            Array.Sort(code);

            foreach (var element in code)
            {
                Console.WriteLine(element);
            }
        }
    }
}