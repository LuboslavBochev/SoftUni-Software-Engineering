using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            List<int> sets = new List<int>();

            while (hats.Count != 0 && scarfs.Count != 0)
            {
                int hatValue = hats.Peek();
                int scarfValue = scarfs.Peek();

                if (hatValue > scarfValue)
                {
                    hats.Pop();
                    scarfs.Dequeue();
                    sets.Add(hatValue + scarfValue);
                }
                else if (scarfValue > hatValue)
                {
                    hats.Pop();
                }
                else // equal
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(++hatValue);
                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}