using System.Drawing;
using TicTacToe.Entities;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models.Contexts.GameContext.Interfaces
{
    public interface IGameContext
    {
        public GameState GameState { get; }

        public Competition MatchInfo { get; }
        public void StartGame(GameCreator gameCreator);
        public void StepGame(Point mapPoint);
    }
}
