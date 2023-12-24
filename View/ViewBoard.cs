using TicTacToe.Helpers;
using TicTacToe.Models.Enums;

namespace TicTacToe.View
{
    public static class ViewBoard
    {
        public static void PrintBoard(TextWriter writer, Symbols[,] map)
        {
            var size0 = map.GetLength(0);
            var size1 = map.GetLength(1);
            if (size0 != size1)
                throw new Exception("карта не квадратная");
            var size = size0;
            var horizontalArrays = GetLinesSymbols(map, size);
            foreach (var item in horizontalArrays)
            {
                ViewTopBottom(writer, size);
                ViewBoardLine(writer, item);
            }
            ViewTopBottom(writer, size);
        }

        private static Symbols[][] GetLinesSymbols(Symbols[,] map, int size)
        {
            var horizontalArrays = new Symbols[size][];
            for (var i = 0; i < size; i++)
            {
                horizontalArrays[i] = new Symbols[size];
                for (var j = 0; j < size; j++)
                {
                    horizontalArrays[i][j] = map[i, j];
                }
            }
            return horizontalArrays;
        }

        private static void ViewBoardLine(TextWriter writer, Symbols[] lineSymbols)
        {
            foreach (var item in lineSymbols)
            {
                var symbol = "";
                if (SymbolsConvertor.TryConvertSymbolToString(item, out symbol))
                {
                    writer.Write("|");
                    writer.Write(symbol);
                }
                else
                {
                    throw new Exception("На игровой доске странный символ");
                }
            }
            writer.Write("|");
            writer.WriteLine();
        }

        private static void ViewTopBottom(TextWriter writer, int size)
        {
            for (var i = 0; i < size; i++)
            {
                writer.Write(" -");
            }
            writer.WriteLine();
        }
    }
}
