namespace TicTacToe.Models.Commands
{
    public abstract class BaseCommand
    {
        protected BaseCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public abstract void Execute(string[] args);
    }
}
