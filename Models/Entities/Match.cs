using System.Drawing;

namespace TicTacToe.Entities
{
    public class Match
    {
        public Board GameBoard { get; }
        public Player FirstPlayer { get; }
        public Player SecondPlayer { get; }

        private Player CurrentPlayer;

        public Match(Board board, Player firstPlayer, Player secondPlayer)
        {
            GameBoard = board;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            CurrentPlayer = FirstPlayer;
        }

        public void MakeMove(Point mapPoint)
        {
            if (!GameBoard.CheckMapPoint(mapPoint))
                throw new ArgumentException("Точка вне доски");
            if (GameBoard.SetCell(mapPoint, CurrentPlayer.GameSymbol))
            {
                CurrentPlayer = CurrentPlayer == FirstPlayer ? SecondPlayer : FirstPlayer;
            }
        }


        public string Tictactoe(int[][] moves)
        {
            if (moves.Length < 5)
                return "Pending";
            var grid = new int[3, 3];
            var player = 1;
            for (var i = 0; i < moves.Length; i++)
            {
                var row = moves[i][0];
                var col = moves[i][1];
                grid[row, col] = player;

                if (CheckWin(grid, player, GameBoard.Size))
                    return GetWinner(player);
                player *= -1;
            }

            return moves.Length == 9 ? "Draw" : "Pending";
        }

        public bool CheckWin(int[,] grid, int player, int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (grid[i, 0] == player && grid[i, 1] == player && grid[i, 2] == player)
                    return true;
                if (grid[0, i] == player && grid[1, i] == player && grid[2, i] == player)
                    return true;
            }

            if (grid[0, 0] == player && grid[1, 1] == player && grid[2, 2] == player)
                return true;
            if (grid[0, 2] == player && grid[1, 1] == player && grid[2, 0] == player)
                return true;
            return false;
        }

        public string GetWinner(int player)
        {
            return player == 1 ? "A" : "B";
        }

    }
}
