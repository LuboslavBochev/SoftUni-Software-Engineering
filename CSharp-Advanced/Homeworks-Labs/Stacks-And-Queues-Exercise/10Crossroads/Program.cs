using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationGreenLight = int.Parse(Console.ReadLine());
            int durationFreeWindow = int.Parse(Console.ReadLine());

            Queue<string> carsToPass = new Queue<string>();
            Stack<string> carsPassed = new Stack<string>();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "END") break;

                else if (commands == "green")
                {
                    int greenLight = durationGreenLight;
                    int freeWindow = durationFreeWindow;

                    while (carsToPass.Any())
                    {
                        string car = carsToPass.Peek();

                        if (car.Length <= greenLight)
                        {
                            greenLight -= car.Length;
                            carsPassed.Push(carsToPass.Dequeue()); // passed

                            if (greenLight <= 0) break;
                        }

                        else if (car.Length > greenLight)
                        {
                            int leftTime = greenLight + freeWindow;

                            if (car.Length <= leftTime)
                            {
                                carsPassed.Push(carsToPass.Dequeue());
                                leftTime -= car.Length;
                                greenLight = 0;
                                freeWindow = 0;
                            }

                            else if (car.Length > leftTime)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[leftTime]}.");
                                return;
                            }
                        }
                    }
                }

                else // car entry
                {
                    string car = commands;

                    carsToPass.Enqueue(car);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed.Count} total cars passed the crossroads.");
        }
    }
}