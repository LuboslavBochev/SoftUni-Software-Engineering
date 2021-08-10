using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreEx_Associative_Arr_4
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> dwarfsCollection = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {

                string input = Console.ReadLine();

                if (input == "Once upon a time") break;

                string[] tokens = input.Split(" <:> ");

                string dwarfName = tokens[0];
                string dwarColor = tokens[1];
                int dwarfPhysics = int.Parse(tokens[2]);

                if (!dwarfsCollection.ContainsKey(dwarColor))
                {
                    dwarfsCollection.Add(dwarColor, new Dictionary<string, int>());
                    dwarfsCollection[dwarColor].Add(dwarfName, dwarfPhysics);
                }

                if (dwarfsCollection.ContainsKey(dwarColor) && dwarfsCollection[dwarColor].ContainsKey(dwarfName))
                {
                    int prePhysics = dwarfsCollection[dwarColor][dwarfName];

                    if (dwarfPhysics > prePhysics)
                    {
                        dwarfsCollection[dwarColor][dwarfName] = dwarfPhysics;
                    }
                }
                if (dwarfsCollection.ContainsKey(dwarColor) && !dwarfsCollection[dwarColor].ContainsKey(dwarfName))
                {
                    dwarfsCollection[dwarColor].Add(dwarfName, dwarfPhysics);
                }
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();
            foreach (var hatColor in dwarfsCollection.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }
    }
}