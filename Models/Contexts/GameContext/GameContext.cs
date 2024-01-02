using System.Drawing;
using TicTacToe.Entities;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models.Contexts.GameContext
{
    public class GameContext : IGameContext
    {
        public Competition MatchInfo { get; private set; }
        public GameState GameState { get; private set; }

        public GameContext()
        {
            GameState = GameState.NotStart;
        }

        public void StartGame(GameCreator gameCreator)
        {
            var firstPlayer = gameCreator.CreatePlayer();
            var secondPlayer = gameCreator.CreatePlayer();
            var players = new [] { firstPlayer, secondPlayer };
            var mathBoard = gameCreator.CreateBoard();
            MatchInfo = gameCreator.CreateMatch(mathBoard, players);
            GameState = GameState.Game;
        }


        public void StepGame(Point mapPoint)
        {
            MatchInfo.MakeMove(mapPoint);
            ChangeGameState();
        }

        private void ChangeGameState()
        {
            GameState = MatchInfo.GetGameState();
        }
    }
}
