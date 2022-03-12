using System.Reflection;
using System.Linq;
using System;

namespace CommandPattern
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType)
        {
            var type = Assembly.GetCallingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name.Contains(commandType));

            ICommand command = (ICommand)Activator.CreateInstance(type);

            return command;
        }
    }
}
