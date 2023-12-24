using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    public class Board
    {
        public int Size { get; }
        private Symbols[,] map;
        public Board(int size)
        {
            Size = size;
            map = new Symbols[Size, Size];
        }

        public Symbols[,] GetMap()
        {
            return (Symbols[,])map.Clone();
        }

        public Symbols GetCell(Point point)
        {
            return map[point.X, point.Y];
        }

        public bool SetCell(Point point, Symbols symbol)
        {
            if (GetCell(point) != Symbols.empty)
                return false;
            map[point.X, point.Y] = symbol;
            return true;
        }

        public bool CheckMapPoint(Point point)
        {
            return 0 <= point.X && point.X < Size
                && 0 <= point.Y && point.Y < Size;
        }
    }
}
