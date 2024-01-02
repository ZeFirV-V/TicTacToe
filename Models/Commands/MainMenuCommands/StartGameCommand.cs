using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Contexts.GameContext;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.Models.Commands.MainMenuCommands
{
    public class StartGameCommand : BaseCommand
    {
        public StartGameCommand(IGameContext gameContext, IApplicationView applicationView, string name, ApplicationState nextExecutorType) 
            : base(gameContext, applicationView, name, nextExecutorType)
        { }

        public override event EventHandler<ExecutorEventArgs> OnHappened;

        public override void Execute(ICommandContext commandContext)
        {
            OnHappened(this, new ExecutorEventArgs(nextExecutorName));
            applicationView.ViewText("Старт игры крестики-нолики");
            var gameCreator = new GameCreator(applicationView);
            gameContext.StartGame(gameCreator);
        }
    }
}