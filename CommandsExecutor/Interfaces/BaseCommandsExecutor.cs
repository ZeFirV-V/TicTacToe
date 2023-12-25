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
    public abstract class BaseCommandsExecutor : ICommandsExecutor
    {
        public string ExecutorName { get; }
        public event EventHandler<ExecutorEventArgs> OnCommittedCommand;
        protected IApplicationView applicationView;
        protected IApplicationContext applicationContext;
        protected readonly List<BaseCommand> commands;

        protected BaseCommandsExecutor(string nameExecutor, IApplicationContext applicationContext, IApplicationView applicationView)
        {
            ExecutorName = nameExecutor;
            this.applicationContext = applicationContext;
            this.applicationView = applicationView;
            commands = new List<BaseCommand>();
        }

        public abstract void Execute(string[] args);

        public abstract void Register(BaseCommand command);

        public abstract string[] GetAvailableCommandsName();

        protected void ReportCommandHappened(object sender, ExecutorEventArgs e)
        {
            OnCommittedCommand(this, e);
        }
    }
}
