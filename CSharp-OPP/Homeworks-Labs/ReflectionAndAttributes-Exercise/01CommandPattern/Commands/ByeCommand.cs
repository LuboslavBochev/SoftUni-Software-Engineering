using System;

namespace CommandPattern.Commands
{
    public class ByeCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return "123";
        }
    }
}
