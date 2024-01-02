using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Enums;

namespace TicTacToe.CustomsEventArgs
{
    public class ExecutorEventArgs : EventArgs
    {
        public ApplicationState ExecutorType { get; }
        public ExecutorEventArgs(ApplicationState typeNextExecutor)
        {
            ExecutorType = typeNextExecutor;
        }
    }
}
