using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.CommandsExecutor.Interfaces
{
    public interface ICommandsExecutor
    {
        public string ExecutorName { get; set; }
        string[] GetAvailableCommandName();
        void Execute(string[] args);
    }
}
