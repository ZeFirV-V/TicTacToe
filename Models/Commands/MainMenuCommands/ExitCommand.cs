using TicTacToe.Models.Commands.MainMenuCommands.BaseMenuCommand;

namespace TicTacToe.Models.Commands.MainMenuCommands
{
    public class ExitCommand : BaseMainMenuCommand
    {
        public ExitCommand(string name) : base(name)
        {
        }

        public override event EventHandler OnHappened;

        public override void Execute(string[] args)
        {
            OnHappened(this, EventArgs.Empty);
            throw new NotImplementedException();
        }
    }
}
