using TicTacToe.Controllers;

namespace TicTacToe.View
{
    public class Launcher : BaseLauncher
    {
        public Launcher(IApplicationView applicationView, BaseHandler handler) : base(applicationView, handler)
        {
        }

        public override void Run()
        {
            while (true)
            {
                if (CheckPlayView())
                {
                    ViewGameBoard();
                    if (CheckEndGame())
                    {
                        ViewEndGame();
                    }
                }
                ViewAllAvailableCommands();
                var text = GetUserInput();
                HandleUserInput(text);
                if (CheckEndApplication())
                    break;
            }
        }
    }
}