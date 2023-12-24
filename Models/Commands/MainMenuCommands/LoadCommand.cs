using TicTacToe.Models.Commands.MainMenuCommands.BaseMenuCommand;

namespace TicTacToe.Models.Commands.MainMenuCommands
{
    public class LoadCommand : BaseMainMenuCommand
    {
        public LoadCommand(string name) : base(name)
        { }

        public override event EventHandler OnHappened;

        public override void Execute(string[] args)
        {
            OnHappened(this, EventArgs.Empty);
            //("Сохраненные игры крестики-нолики");
        }
    }
}
