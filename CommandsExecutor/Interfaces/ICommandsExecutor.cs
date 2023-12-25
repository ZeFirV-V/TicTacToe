using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Commands;
using TicTacToe.Models.Contexts.ApplicationContext.Interfaces;
using TicTacToe.View;

namespace TicTacToe.CommandsExecutor.Interfaces
{
    public interface ICommandsExecutor
    {
        public abstract event EventHandler<ExecutorEventArgs> OnCommittedCommand;
        public string ExecutorName { get; }
        public string[] GetAvailableCommandsName();
        public void Execute(string[] args);
        public void Register(BaseCommand command);
    }
}
