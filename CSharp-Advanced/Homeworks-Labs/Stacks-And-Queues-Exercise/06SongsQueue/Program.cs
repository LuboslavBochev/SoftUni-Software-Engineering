using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] playlist = Console.ReadLine().Split(", ");

            Queue<string> playlistQueue = new Queue<string>(playlist);

            while (playlistQueue.Any())
            {
                string[] command = Console.ReadLine().Split();
                string song = string.Empty;

                if (command.Length > 1)
                {
                    song = string.Join(" ", command.Skip(1));
                }

                if (command[0] == "Play")
                {
                    playlistQueue.Dequeue();
                }

                else if (command[0] == "Add")
                {
                    if (!playlistQueue.Contains(song))
                    {
                        playlistQueue.Enqueue(song);
                    }
                    else Console.WriteLine($"{song} is already contained!");
                }

                else
                {
                    Console.WriteLine(string.Join(", ", playlistQueue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}