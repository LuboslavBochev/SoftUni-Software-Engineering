using System;
using System.Collections.Generic;
using System.Linq;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int index = 0;

            List<Animal> animals = new List<Animal>();
            Animal animal = null;

            while (true)
            {
                string[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputs[0] == "End") break;

                if (index % 2 == 0) // animal
                {
                    string animalType = inputs[0];

                    if (animalType == nameof(Hen))
                    {
                        animal = new Hen(inputs[1], double.Parse(inputs[2]), double.Parse(inputs[3]));
                    }
                    else if (animalType == nameof(Owl))
                    {
                        animal = new Owl(inputs[1], double.Parse(inputs[2]), double.Parse(inputs[3]));
                    }
                    else if (animalType == nameof(Mouse))
                    {
                        animal = new Mouse(inputs[1], double.Parse(inputs[2]), inputs[3]);
                    }
                    else if (animalType == nameof(Cat))
                    {
                        animal = new Cat(inputs[1], double.Parse(inputs[2]), inputs[3], inputs[4]);
                    }
                    else if (animalType == nameof(Dog))
                    {
                        animal = new Dog(inputs[1], double.Parse(inputs[2]), inputs[3]);
                    }
                    else // Tiger
                    {
                        animal = new Tiger(inputs[1], double.Parse(inputs[2]), inputs[3], inputs[4]);
                    }
                    animals.Add(animal);
                }
                else // food
                {
                    string food = inputs[0];
                    int quantity = int.Parse(inputs[1]);

                    try
                    {
                        animal.ProduceSound(food, quantity);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                index++;
            }
            animals.ForEach(Console.WriteLine);
        }
    }
}
