using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.Models.Commands.MainMenuCommands
{
    public class CommandContinueGame : BaseCommand
    {
        public CommandContinueGame(IGameContext gameContext, IApplicationView applicationView, string name, ApplicationState nextExecutorType) 
            : base(gameContext, applicationView, name, nextExecutorType)
        {
        }

        public override event EventHandler<ExecutorEventArgs> OnHappened;

        public override void Execute(ICommandContext commandContext)
        {
            OnHappened(this, new ExecutorEventArgs(nextExecutorName));
            throw new NotImplementedException();
        }
    }
}