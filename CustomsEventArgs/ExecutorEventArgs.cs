using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.CustomsEventArgs
{
    public class ExecutorEventArgs : EventArgs
    {
        public string ExecutorName { get; }
        public ExecutorEventArgs(string name)
        {
            ExecutorName = name;
        }
    }
}
