using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models.Contexts.ApplicationContext.Interfaces
{
    public interface IApplicationContext
    {
        public ApplicationState ApplicationState { get; set; }
        public ICommandsExecutor CommandsExecutor { get; set; }
        //protected IGameContext GameContext { get; set; }
        ///TODO: Сделать модель для уже сохраненных игр.
    }
}
