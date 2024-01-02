using System.Windows.Input;
using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.Models.Commands
{
    public abstract class BaseCommand
    {
        protected IApplicationView applicationView;
        protected IGameContext gameContext;
        protected ApplicationState nextExecutorName;
        public abstract event EventHandler<ExecutorEventArgs> OnHappened;

        protected BaseCommand(IGameContext gameContext, IApplicationView applicationView, string name, ApplicationState nextExecutorType)
        {
            this.gameContext = gameContext;
            this.applicationView = applicationView;
            Name = name;
            nextExecutorName = nextExecutorType;
        }

        public string Name { get; }
        public abstract void Execute(ICommandContext commandContext);
    }
}
