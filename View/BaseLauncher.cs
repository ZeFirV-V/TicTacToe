using TicTacToe.Controllers;
using TicTacToe.View.Interfaces;

namespace TicTacToe.View
{
    public abstract class BaseLauncher : IUserInterface
    {
        public IApplicationView ApplicationView { get; }
        protected BaseHandler handler;

        protected BaseLauncher(IApplicationView applicationView, BaseHandler handler)
        {
            ApplicationView = applicationView;
            this.handler = handler;
        }

        protected string GetUserInput()
        {
            var text = ApplicationView.InputText();
            if (text == null)
                throw new ArgumentNullException();
            return text;
        }

        protected void HandleUserInput(string userInput)
        {
            handler.ExecuteCommand(userInput);
        }

        protected bool CheckEndApplication()
        {
            return handler.CheckEndApplication();
        }

        protected bool CheckPlayView()
        {
            return handler.CheckIsPlay();
        }

        protected void ViewAllAvailableCommands()
        {
            handler.ViewAllAvailableCommands();
        }

        protected void ViewGameBoard()
        {
            handler.ViewGameBoard();
        }

        protected void ViewEndGame()
        {
            handler.ViewEndGame();
        }

        protected bool CheckContinueGame()
        {
            return handler.CheckContinueGame();
        }

        protected bool CheckEndGame()
        {
            return handler.CheckEndGame();
        }

        public abstract void Run();
    }
}
