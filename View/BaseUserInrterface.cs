using TicTacToe.Controllers;
using TicTacToe.View.Interfaces;

namespace TicTacToe.View
{
    public abstract class BaseUserInrterface : IUserInterface
    {
        public TextWriter Writer { get; }
        public TextReader Reader { get; }
        private BaseHandler handler;

        protected BaseUserInrterface(TextReader reader, TextWriter writer, BaseHandler handler)
        {
            Writer = writer;
            Reader = reader;
            this.handler = handler;
        }

        public abstract void ViewMessage(string text);

        protected abstract string GetCommandsNames();

        public abstract void ViewAllAvailableCommands();

        public abstract void HandleUserInput(string userInput);

        public abstract string GetUserInput();
    }
}
