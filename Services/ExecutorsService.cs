using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Enums;

namespace TicTacToe.Services
{
    public class ExecutorsService
    {
        public ICommandsExecutor CurrentCommandExecutor { get; private set; }
        private List<ICommandsExecutor> commandsExecutors;

        public ExecutorsService(List<ICommandsExecutor> executors, ICommandsExecutor currentCommandExecutor)
        {
            if(!CheckCorrectArgsExecutors(executors))
            {
                throw new ArgumentNullException();
            }
            ///TODO: Сделать проверку currentCommandExecutor
            commandsExecutors = executors;
            CurrentCommandExecutor = currentCommandExecutor;
            SubscribeExecutorsChanges(commandsExecutors);
        }

        public string[] GetCommandsNamesCurrentExecutor()
        {
            return CurrentCommandExecutor.GetAvailableCommandsName();
        }

        private void SubscribeExecutorsChanges(List<ICommandsExecutor> executors)
        {
            foreach(var executor in executors)
            {
                executor.OnCommittedCommand += ReactSubscriptionExecutorActions;
            }
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
            var typeNewExecutor = e.ExecutorType;
            if (!CheckCurentExecutor(typeNewExecutor))
            {
                throw new Exception("Нет такого Executor в списке, передаете не корректный следующий Executor");
            }
            CurrentCommandExecutor = FindCommandExecutor(typeNewExecutor);
        }

        public bool CheckCurentExecutor(ApplicationState typeNextExecutor)
        {
            return commandsExecutors.FindAll(x => x.ExecutorApplicationState.Equals(typeNextExecutor)).Count() > 0;
        }

        private ICommandsExecutor FindCommandExecutor(ApplicationState typeNextExecutor)
        {
            var newExecutor = commandsExecutors.Find(x => x.ExecutorApplicationState.Equals(typeNextExecutor));
            if(newExecutor == null)
            {
                throw new Exception();
            }
            return newExecutor;
        }
    }
}
