using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;

        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactory();
        }

        public string Read(string args)
        {
            string[] arguments = args.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string commandType = arguments[0];

            ICommand command = this.commandFactory.CreateCommand(commandType);

            return command.Execute(arguments.Skip(1).ToArray());
        }
    }
}
