using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.CustomsEventArgs;

namespace TicTacToe.Services
{
    public class ExecutorsService
    {
        public ICommandsExecutor CurrentCommandExecutor { get; set; }
        private List<ICommandsExecutor> commandsExecutors;

        public ExecutorsService(List<ICommandsExecutor> executors)
        {
            if(!CheckCorrectArgsExecutors(executors))
            {
                throw new ArgumentNullException();
            }
            commandsExecutors = executors;
        }

        private bool CheckCorrectArgsExecutors(List<ICommandsExecutor> executors)
        {
            if (executors == null)
            {
                return false;
            }
            return true;
            ///TODO: Доделать проверку, чтобы не было одинаковых!
        }

        private void ReactSubscriptionExecutorActions(object sender, ExecutorEventArgs e)
        {
            var nameNewExecutor = e.ExecutorName;
            if (!CheckCurentExecutor(nameNewExecutor))
                return;
            var newExecutor = FindCommandExecutor(nameNewExecutor);
            ChengeCurentExecutor(newExecutor);
        }

        private void SubscribeEvents(List<ICommandsExecutor> executors)
        {
            ///TODO: Сделать подписку к событияем.
        }

        public bool CheckCurentExecutor(string nameExecutor)
        {
            return commandsExecutors.FindAll(x => x.ExecutorName.Equals(nameExecutor)).Count() > 0;
        }

        public void ChengeCurentExecutor(ICommandsExecutor newExecutor)
        {
            CurrentCommandExecutor = newExecutor;
        }

        private ICommandsExecutor FindCommandExecutor(string nameExecutor)
        {
            var newExecutor = commandsExecutors.Find(x => x.ExecutorName.Equals(nameExecutor));
            if(newExecutor == null)
            {
                throw new Exception();
            }
            return newExecutor;
        }
    }
}
