using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Models.Entities
{
    public class GameAction
    {
        public Point GamePoint { get; }
        public Player Player { get; }

        public GameAction(Player player, Point point)
        {
            Player = player;
            GamePoint = point;
        }
    }
}
