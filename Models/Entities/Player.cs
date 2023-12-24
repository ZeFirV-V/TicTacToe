using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    public class Player
    {
        public string Name { get; }
        public Symbols GameSymbol { get; }

        public Player(string name, Symbols gameSymbol)
        {
            Name = name;
            GameSymbol = gameSymbol;
        }
    }
}
