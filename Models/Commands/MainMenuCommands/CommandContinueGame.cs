using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Commands.MainMenuCommands.BaseMenuCommand;

namespace TicTacToe.Models.Commands.MainMenuCommands
{
    public class CommandContinueGame : BaseMainMenuCommand
    {
        public CommandContinueGame(string name) : base(name)
        {
        }

        public override event EventHandler<CommandEventArgs> OnHappened;

        public override void Execute(string[] args)
        {
            OnHappened(this, new CommandEventArgs());
            throw new NotImplementedException();
        }
    }
}
