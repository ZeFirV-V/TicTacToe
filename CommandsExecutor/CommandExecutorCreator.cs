using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.CommandsExecutor
{
    public class CommandExecutorCreator
    {
        private IApplicationView applicationView;
        private IGameContext gameContext;

        public CommandExecutorCreator(IGameContext game, IApplicationView view)
        {
            applicationView = view;
            gameContext = game;
        }

        public TCommandsExecutor CreateExecutor<TCommandsExecutor>(string nameExecutor, ApplicationState executorApplicationState)
            where TCommandsExecutor : BaseCommandsExecutor
        {
            return (TCommandsExecutor)Activator.CreateInstance(typeof(TCommandsExecutor), new object[] { nameExecutor, executorApplicationState, gameContext, applicationView });
        }
    }
}
