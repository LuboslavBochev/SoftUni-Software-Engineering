﻿using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string result = this.commandInterpreter.Read(input);

                if(result == null)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(result);
            }
        }
    }
}
