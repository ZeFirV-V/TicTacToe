using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.Models.Contexts.ApplicationContext.Interfaces;

namespace TicTacToe.Controllers
{
    public abstract class BaseHandler
    {
        private IApplicationContext applicationContext;

        protected BaseHandler(IApplicationContext applicationContext) 
        {
            this.applicationContext = applicationContext;
        }

        protected abstract void CreateGame();
        protected abstract void UpdateGame();
        protected abstract void ContinueGame();
        protected abstract void LoadGame();
        protected abstract void SaveGame();
        protected abstract void StopGame();
        protected abstract void ExitApplication();

    }
}
