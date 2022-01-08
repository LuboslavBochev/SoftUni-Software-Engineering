using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string type = Console.ReadLine();

            while (type != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                try
                {
                    if (type == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (type == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (type == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    else if (type == "Kittens")
                    {
                        Kitten kittens = new Kitten(name, age);
                        animals.Add(kittens);
                    }
                    else // Tomcat
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                type = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
