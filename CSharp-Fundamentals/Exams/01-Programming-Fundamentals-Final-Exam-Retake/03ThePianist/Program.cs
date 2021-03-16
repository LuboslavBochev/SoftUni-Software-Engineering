using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fund_Exam_More
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfPieces = int.Parse(Console.ReadLine());

            Dictionary<string, Pianist> favoritePieces = new Dictionary<string, Pianist>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] input = Console.ReadLine().Split("|");

                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                if (!favoritePieces.ContainsKey(piece))
                {
                    favoritePieces.Add(piece, new Pianist(composer, key));
                }
            }

            string commands = string.Empty;

            while (true)
            {
                commands = Console.ReadLine();

                if (commands == "Stop") break;

                string[] tokens = commands.Split("|");

                string commandType = tokens[0];
                string piece = tokens[1];

                if (commandType == "Add")
                {
                    string composer = tokens[2];
                    string key = tokens[3];

                    if (!favoritePieces.ContainsKey(piece))
                    {
                        favoritePieces.Add(piece, new Pianist(composer, key));

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }

                else if (commandType == "Remove")
                {
                    if (favoritePieces.ContainsKey(piece))
                    {
                        favoritePieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                else
                {
                    string newKey = tokens[2];

                    if (favoritePieces.ContainsKey(piece))
                    {
                        foreach (var item in favoritePieces)
                        {
                            if (item.Key == piece)
                            {
                                item.Value.Key = newKey;
                                break;
                            }
                        }
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var item in favoritePieces.OrderBy(name => name.Key).ThenBy(composer => composer.Value.ComposerName))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.ComposerName}, Key: {item.Value.Key}");
            }
        }
    }

    public class Pianist
    {

        public Pianist(string composerName, string key)
        {
            this.ComposerName = composerName;

            this.Key = key;
        }

        public string ComposerName { get; set; }

        public string Key { get; set; }
    }
}