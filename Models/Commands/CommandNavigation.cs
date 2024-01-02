using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.Models.Commands
{
    public class CommandNavigation : BaseCommand
    {
        public CommandNavigation(IGameContext gameContext, IApplicationView applicationView, string name, ApplicationState nextExecutorType)
            : base(gameContext, applicationView, name, nextExecutorType)
        { }

        public override event EventHandler<ExecutorEventArgs> OnHappened;

        public override void Execute(ICommandContext commandContext)
        {
            OnHappened(this, new ExecutorEventArgs(nextExecutorName));
        }
    }
}