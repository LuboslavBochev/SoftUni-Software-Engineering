using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 0;

            int[] arrSave = new int[n];
            int[] arrPermament = new int[n];


            for (int i = 0; i < n; i++)
            {
                int[] arrUpdated = new int[n];

                for (int j = 0; j <= i; j++)
                {
                    if (i == 0 || i == 1 || i == j)
                    {
                        arrSave[j] = 1;
                    }

                    else if (j > 0)
                    {
                        arrSave[j] = arrPermament[j - 1] + arrPermament[j];
                    }

                }

                foreach (var item in arrSave) // arr for print
                {
                    if (item == 0)
                    {
                        break;
                    }
                    arrUpdated[k] = item;
                    Console.Write(arrUpdated[k] + " ");
                    k++;
                }

                k = 0;
                foreach (var item in arrSave) // arr for save previous values
                {
                    if (item == 0)
                    {
                        break;
                    }
                    arrPermament[k] = item;
                    k++;
                }
                Console.WriteLine();
                k = 0;
            }
        }
    }
}