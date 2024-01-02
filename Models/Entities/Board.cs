using System.Drawing;
using TicTacToe.Models.Entities;

namespace TicTacToe.Entities
{
    public class Board
    {
        public int Size { get; }
        private char[,] freeMap;
        public Board(int size)
        {
            Size = size;
            freeMap = new char[Size, Size];
        }

        public char[,] GetMap()
        {
            return (char[,])freeMap.Clone();
        }

        public bool CheckFreeCell(Point point)
        {
            return freeMap[point.X, point.Y] == '\0';
        }

        public void SetCell(GameAction action)
        {
            freeMap[action.GamePoint.X, action.GamePoint.Y] = action.Player.GameIdentificationMark;
        }

        public bool CheckMapPoint(Point point)
        {
            return 0 <= point.X && point.X < Size
                && 0 <= point.Y && point.Y < Size;
        }
    }
}
