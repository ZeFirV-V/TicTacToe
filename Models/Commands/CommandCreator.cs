using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.Models.Commands
{
    public class CommandCreator
    {
        private IApplicationView applicationView;
        private IGameContext _gameContextContext;

        public CommandCreator(IGameContext gameContext, IApplicationView view) 
        {
            applicationView = view;
            _gameContextContext = gameContext;
        }

        public TCommand CreateCommand<TCommand>(string name, ApplicationState nextExecutorType)
            where TCommand : BaseCommand
        {
            return (TCommand)Activator.CreateInstance(typeof(TCommand), new object[] { _gameContextContext, applicationView, name, nextExecutorType });
        }
    }
}
