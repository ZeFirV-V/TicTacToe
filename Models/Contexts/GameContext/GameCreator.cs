using TicTacToe.Entities;
using TicTacToe.View;

namespace TicTacToe.Models.Contexts.GameContext
{
    public class GameCreator
    {
        private IApplicationView applicationView;

        public GameCreator(IApplicationView view)
        {
            applicationView = view;
        }

        private string GetName()
        {
            applicationView.ViewText("Введит имя игрока");
            return applicationView.InputText();
        }

        private char GetIdentificationMark()
        {
            applicationView.ViewText("Введите игровой символ");
            ///TODO: Проверить, что пришел только один символ и что он уже не занят у другого человека
            return applicationView.InputText()[0];
        }

        public Player CreatePlayer()
        {
            var name = GetName();
            var identificationMark = GetIdentificationMark();
            return new Player(name, identificationMark);
        }

        public Board CreateBoard()
        {
            var size = 3;
            return new Board(size);
        }

        public Competition CreateMatch(Board board, Player[] players)
        {
            return new Competition(board, players);
        }
    }
}
