using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()), counter = 0;
            bool isFound = false;

            for (int i = 1111; i <= 9999; i++)
            {
                string currentNum = i.ToString();


                for (int j = 0; j < currentNum.Length; j++)
                {
                    int digit = int.Parse(currentNum[j].ToString());

                    if (digit == 0)
                    {
                        continue;
                    }

                    if (n % digit == 0)
                    {
                        counter++;

                        if (counter == 4)
                        {
                            isFound = true;
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (isFound)
                {
                    Console.Write(i + " ");
                }
                counter = 0;
                isFound = false;

            }
        }
    }
}