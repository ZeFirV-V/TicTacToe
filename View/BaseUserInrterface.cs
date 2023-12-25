using TicTacToe.Controllers;
using TicTacToe.View.Interfaces;

namespace TicTacToe.View
{
    public abstract class BaseUserInrterface : IUserInterface
    {
        public TextWriter Writer { get; }
        public TextReader Reader { get; }
        protected BaseHandler handler;

        protected BaseUserInrterface(TextReader reader, TextWriter writer, BaseHandler handler)
        {
            Writer = writer;
            Reader = reader;
            this.handler = handler;
        }

        public abstract void Run();

        public abstract void HandleUserInput(string userInput);

        public abstract string GetUserInput();
    }
}
