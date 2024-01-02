using System.Reflection.PortableExecutable;

namespace TicTacToe.View
{
    public interface IApplicationView
    {
        public void ViewText(string text);
        public string InputText();
        public void ViewGame(char[,] map);
    }
}
