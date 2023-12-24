using TicTacToe.Models.Commands.MainMenuCommands.BaseMenuCommand;
using TicTacToe.View;

namespace TicTacToe.Models.Commands.MainMenuCommands
{
    public class StartGameCommand : BaseMainMenuCommand
    {
        public StartGameCommand(string name) : base(name)
        { }

        public override event EventHandler OnHappened;

        public override void Execute(string[] args)
        {
            OnHappened(this, EventArgs.Empty);
            //("Старт игры крестики-нолики");
            //var boardSize = 3;
            //var firstPlayer = PlayerCreator.CreatePlayer();
            //var secondPlayer = PlayerCreator.CreatePlayer();
            //var board = new Board(boardSize);
            //var match = new Match(board, firstPlayer, secondPlayer);
            //ViewBoard.PrintBoard(writer, board.GetMap());
        }
    }
}