using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2:35 min ot predi

            double capacity = double.Parse(Console.ReadLine());

            string volume = "";

            bool isEnd = false;
            bool isFull = false;
            int count = 0;

            while (true)
            {
                volume = Console.ReadLine();

                if (volume == "End")
                {
                    isEnd = true;
                    break;
                }

                double volumeSuitcase = double.Parse(volume);
                count++;
                if (count % 3 == 0)
                {
                    volumeSuitcase = volumeSuitcase + (volumeSuitcase * 0.1);
                }

                capacity -= volumeSuitcase;

                if (capacity <= 0)
                {
                    isFull = true;
                    break;
                }
            }

            if (isEnd)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
                Console.WriteLine($"Statistic: {count} suitcases loaded.");
            }

            else if (isFull)
            {
                Console.WriteLine("No more space!");
                Console.WriteLine($"Statistic: {count - 1} suitcases loaded.");
            }
        }
    }
}
