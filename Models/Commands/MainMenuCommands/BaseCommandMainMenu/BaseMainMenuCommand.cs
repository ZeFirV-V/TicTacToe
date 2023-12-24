using TicTacToe.CustomsEventArgs;

namespace TicTacToe.Models.Commands.MainMenuCommands.BaseMenuCommand
{
    public abstract class BaseMainMenuCommand : BaseCommand
    {
        public abstract event EventHandler<CommandEventArgs> OnHappened;

        protected BaseMainMenuCommand(string name) : base(name)
        {

        }
    }
}
