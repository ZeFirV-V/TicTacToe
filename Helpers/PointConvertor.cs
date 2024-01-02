using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Helpers
{
    public class PointConvertor
    {
        public int Size { get; }
        public PointConvertor(int size)
        {
            Size = size;
        }

        public Point NumberConvertPoint(int number)
        {
            var y = number % Size;
            var x = number / Size;
            return new Point(x, y);
        }
    }
}
