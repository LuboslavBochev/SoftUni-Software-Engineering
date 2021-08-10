using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreEx_Associative_Arr_5
{
    class Program
    {
        static void Main(string[] args)
        {

            int dragonNum = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, List<int>>> dragonCollection = new Dictionary<string, SortedDictionary<string, List<int>>>();

            for (int i = 0; i < dragonNum; i++)
            {

                string[] tokens = Console.ReadLine().Split(" ");
                // {type} {name} {damage} {health} {armor}

                string type = tokens[0];
                string dragonName = tokens[1];
                string damage = tokens[2]; // ne e int zashtoto ako e null shte dade greshka 
                string health = tokens[3];
                string armor = tokens[4];

                int damageInt = 0;
                int healthInt = 0;
                int armorInt = 0;

                if (damage == "null" || health == "null" || armor == "null")
                {
                    if (damage == "null")
                    {
                        damageInt = 45;
                    }
                    else damageInt = int.Parse(damage);

                    if (health == "null")
                    {
                        healthInt = 250;
                    }

                    else healthInt = int.Parse(health);

                    if (armor == "null")
                    {
                        armorInt = 10;
                    }
                    else armorInt = int.Parse(armor);
                }

                else
                {
                    damageInt = int.Parse(damage);
                    healthInt = int.Parse(health);
                    armorInt = int.Parse(armor);
                }

                if (!dragonCollection.ContainsKey(type))
                {
                    dragonCollection.Add(type, new SortedDictionary<string, List<int>>());
                    dragonCollection[type].Add(dragonName, new List<int>()
                    {
                        damageInt,
                        healthInt,
                        armorInt
                    });
                }

                else // if there is this type update or add it
                {
                    if (dragonCollection[type].ContainsKey(dragonName)) // if the type and dragonName are same override them
                    {
                        for (int j = 0; j < dragonCollection[type][dragonName].Count; j++)
                        {
                            dragonCollection[type][dragonName][0] = damageInt;
                            dragonCollection[type][dragonName][1] = healthInt;
                            dragonCollection[type][dragonName][2] = armorInt;
                        }
                    }

                    else // if the dragonName is diff
                    {
                        dragonCollection[type].Add(dragonName, new List<int>()
                        {
                            damageInt,
                            healthInt,
                            armorInt
                        });
                    }
                }
            }


            foreach (var type in dragonCollection)
            {

                //double sumDamage = 0.0;
                //double sumHealth = 0.0;
                //double sumArmor = 0.0;

                //for (int i = 0; i < dragonCollection.Values.Count; i++)
                //{
                //    foreach (var item in type.Value.Values)
                //    {
                //        sumDamage += item[0];
                //        sumHealth += item[1];
                //        sumArmor += item[2];
                //    }
                //    break;
                //}

                Console.WriteLine($"{type.Key}::({type.Value.Select(val => val.Value[0]).Average():f2}/{type.Value.Select(val => val.Value[1]).Average():f2}/{type.Value.Select(val => val.Value[2]).Average():f2})");

                foreach (var stats in type.Value)
                {
                    Console.Write($"-{stats.Key} -> ");

                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine($"damage: {stats.Value[0]}, health: {stats.Value[1]}, armor: {stats.Value[2]}");
                    }
                }
            }

        }
    }
}