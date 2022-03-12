namespace CommandPattern
{
    public interface ICommandFactory
    {
        public ICommand CreateCommand(string commandType);
    }
}
