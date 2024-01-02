using System.Diagnostics.Metrics;
using System.Drawing;
using TicTacToe.Models.Entities;
using TicTacToe.Models.Enums;

namespace TicTacToe.Entities
{
    public class Competition
    {
        public Board GameBoard { get; }
        public Player FirstPlayer { get; }
        public Player SecondPlayer { get; }
        private Player currentPlayer;
        private Stack<GameAction> actions;

        public Competition(Board board, Player[] players)
        {
            GameBoard = board;
            if(players.Length != 2)
            {
                throw new ArgumentException();
            }
            FirstPlayer = players[0];
            SecondPlayer = players[1];
            currentPlayer = FirstPlayer;
            actions = new Stack<GameAction>();
        }

        public void MakeMove(Point mapPoint)
        {
            if (!GameBoard.CheckMapPoint(mapPoint))
            {
                throw new ArgumentException("Точка вне доски");
            }
            if (GameBoard.CheckFreeCell(mapPoint))
            {
                var action = new GameAction(currentPlayer, mapPoint);
                GameBoard.SetCell(action);
                actions.Push(action);
                if(GetGameState() == GameState.Game)
                {
                    currentPlayer = currentPlayer == FirstPlayer ? SecondPlayer : FirstPlayer;
                }
            }
        }

        public bool IsCanMove(Point mapPoint)
        {
            if (!GameBoard.CheckMapPoint(mapPoint))
            {
                return false;
            }

            if (!CheckFreeCell(mapPoint))
            {
                return false;
            }
            return true;
        }

        private bool CheckFreeCell(Point mapPoint)
        {
            return GameBoard.CheckFreeCell(mapPoint);
        }

        public GameState GetGameState()
        {
            var minActionsForWin = GameBoard.Size * 2 - 1;
            if (actions.Count < minActionsForWin)
                return GameState.Game;
            if (CheckWin())
                return GameState.EndGame;
            var maxActionsSize = GameBoard.Size * GameBoard.Size;
            return actions.Count == maxActionsSize ? GameState.EndGame : GameState.Game;
        }

        public string GetWinnerGamePlayerName()
        {
            if (CheckWin())
                return currentPlayer.Name;
            throw new Exception();
            //TODO: Подумать, нужна ли тут ошибка и нужно ли сделать по другому.
        }

        public bool CheckWin()
        {
            var playerChar = currentPlayer.GameIdentificationMark;
            var grid = GameBoard.GetMap();
            var len = GameBoard.Size;
            var win = true;
            for (var i = 0; i < len; i++)
            {
                if (grid[i, len - 1 - i] != playerChar)
                {
                    win = false;
                    break;
                }
            }
            if (win)
                return win;
            win = true;
            for (var i = 0; i < len; i++)
            {
                if (grid[i, i] != playerChar)
                {
                    win = false;
                    break;
                }
            }
            if (win)
                return win;
            win = true;
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < len; j++)
                {
                    if (grid[i, j] != playerChar)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                    return win;
                win = true;
                for (var j = 0; j < len; j++)
                {
                    if (grid[j, i] != playerChar)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                    return win;
                win = true;
            }
            return false;
        }
    }
}
