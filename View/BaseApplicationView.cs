using System.Drawing;
using System.Reflection.PortableExecutable;
using TicTacToe.Helpers;

namespace TicTacToe.View
{
    public abstract class BaseApplicationView : IApplicationView
    {
        private TextWriter writer { get; }
        private TextReader reader { get; }

        protected BaseApplicationView(TextWriter writer, TextReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void ViewText(string text)
        {
            writer.WriteLine(text);
        }

        public string InputText()
        {
            return reader.ReadLine();
        }

        public void ViewGame(char[,] map)
        {
            var size0 = map.GetLength(0);
            var size1 = map.GetLength(1);
            if (size0 != size1)
                throw new Exception("карта не квадратная");
            var size = size0;
            var horizontalArrays = GetLinesSymbols(map, size);
            var startIndex = 1;
            foreach (var item in horizontalArrays)
            {
                ViewTopBottom(size);
                ViewBoardLine(item, startIndex);
                startIndex += size;
            }
            ViewTopBottom(size);
        }

        private char[][] GetLinesSymbols(char[,] map, int size)
        {
            var horizontalArrays = new char[size][];
            for (var i = 0; i < size; i++)
            {
                horizontalArrays[i] = new char[size];
                for (var j = 0; j < size; j++)
                {
                    horizontalArrays[i][j] = map[i, j];
                }
            }
            return horizontalArrays;
        }

        private void ViewBoardLine(char[] lineSymbols, int startIndex)
        {
            var index = startIndex;
            foreach (var item in lineSymbols)
            {
                writer.Write("|");
                writer.Write(item == '\0' ? index.ToString()[0] : item);
                index++;
            }
            writer.Write("|");
            writer.WriteLine();
        }

        private void ViewTopBottom(int size)
        {
            for (var i = 0; i < size; i++)
            {
                writer.Write(" -");
            }
            writer.WriteLine();
        }
    }
}
