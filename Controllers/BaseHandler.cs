using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.Services;
using TicTacToe.View;

namespace TicTacToe.Controllers
{
    public abstract class BaseHandler
    {
        private IGameContext gameContext;
        private IApplicationView applicationView;
        private ExecutorsService executorsService;

        protected BaseHandler(IGameContext gameContext, IApplicationView applicationView, ExecutorsService executorsService) 
        {
            this.gameContext = gameContext;
            this.applicationView = applicationView;
            this.executorsService = executorsService;
        }

        public void ExecuteCommand(string command)
        {
            var commandsArgs = new[] { command };
            executorsService.CurrentCommandExecutor.Execute(commandsArgs);
        }

        public bool CheckEndApplication()
        {
            return executorsService.CurrentCommandExecutor.ExecutorApplicationState == ApplicationState.empty;
        }

        public bool CheckIsPlay()
        {
            return executorsService.CurrentCommandExecutor.ExecutorApplicationState == ApplicationState.game;
        }

        public bool CheckContinueGame()
        {
            return gameContext.GameState == GameState.Game;
        }

        public bool CheckEndGame()
        {
            return gameContext.GameState == GameState.EndGame;
        }

        public void ViewAllAvailableCommands()
        {
            applicationView.ViewText("Доступные команды");
            executorsService.GetCommandsNamesCurrentExecutor().ToList().ForEach(s => applicationView.ViewText(s));
        }

        public void ViewGameBoard()
        {
            applicationView.ViewText("Игровая доска");
            applicationView.ViewGame(gameContext.MatchInfo.GameBoard.GetMap());
        }

        public void ViewEndGame()
        {
            applicationView.ViewText("Игра завершена");
            if(gameContext.MatchInfo.CheckWin())
                applicationView.ViewText($"Выйграл {gameContext.MatchInfo.GetWinnerGamePlayerName()}");
            else
            {
                applicationView.ViewText($"Ничья");
            }

        }
    }
}