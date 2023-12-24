using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.CustomsEventArgs
{
    public class CommandEventArgs : EventArgs
    {
        public string ExecutorName { get; }
    }
}
