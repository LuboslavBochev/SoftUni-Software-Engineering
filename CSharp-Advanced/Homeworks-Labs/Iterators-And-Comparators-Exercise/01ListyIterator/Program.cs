using System;
using System.Linq;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split().Skip(1).ToArray();

            ListyIterator<string> listyIterator = new ListyIterator<string>(items);

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }

                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }

                //else if (command == "PrintAll")
                //{
                //    Console.WriteLine(string.Join(" ", listyIterator));
                //}

                else // print
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
