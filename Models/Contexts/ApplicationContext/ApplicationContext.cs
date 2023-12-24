using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.Models.Contexts.ApplicationContext.Interfaces;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models.Contexts.ApplicationContext
{
    public class ApplicationContext : IApplicationContext
    {
        private ApplicationState applicationState;
        private ICommandsExecutor commandsExecutor;

        public ApplicationContext(ApplicationState applicationState)
        {
            this.applicationState = applicationState;
            //commandsExecutor =
        }

        public ApplicationState ApplicationState
        {
            get
            {
                return applicationState;
            }
            set
            {
                applicationState = value;
            }
        }
        public ICommandsExecutor CommandsExecutor
        {
            get
            {
                return commandsExecutor;
            }
            set
            {
                commandsExecutor = value;
            }
        }
    }
}
