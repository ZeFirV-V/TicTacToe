using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Commands;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.CommandsExecutor.Interfaces
{
    public abstract class BaseCommandsExecutor : ICommandsExecutor
    {
        public string ExecutorName { get; }

        public ApplicationState ExecutorApplicationState { get; }

        public event EventHandler<ExecutorEventArgs> OnCommittedCommand;
        protected IApplicationView applicationView;
        protected IGameContext GameContext;
        protected readonly List<BaseCommand> commands;

        protected BaseCommandsExecutor(string nameExecutor, ApplicationState executorApplicationState, IGameContext gameContext, IApplicationView applicationView)
        {
            ExecutorName = nameExecutor;
            ExecutorApplicationState = executorApplicationState;
            this.GameContext = gameContext;
            this.applicationView = applicationView;
            commands = new List<BaseCommand>();
        }

        public abstract void Execute(string[] args);

        public abstract void Register(BaseCommand command);

        public abstract string[] GetAvailableCommandsName();

        protected void ReportCommandHappened(object sender, ExecutorEventArgs e)
        {
            OnCommittedCommand(this, e);
        }
    }
}
