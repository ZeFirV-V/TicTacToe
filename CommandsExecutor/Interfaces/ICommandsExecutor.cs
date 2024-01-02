using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Commands;
using TicTacToe.Models.Enums;

namespace TicTacToe.CommandsExecutor.Interfaces
{
    public interface ICommandsExecutor
    {
        public abstract event EventHandler<ExecutorEventArgs> OnCommittedCommand;
        public string ExecutorName { get; }
        public ApplicationState ExecutorApplicationState { get; }
        public string[] GetAvailableCommandsName();
        public void Execute(string[] args);
        public void Register(BaseCommand command);
    }
}
