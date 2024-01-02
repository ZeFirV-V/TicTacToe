using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.CommandsExecutor.Interfaces;

namespace TicTacToe.View.Interfaces
{
    public interface IUserInterface
    {
        public IApplicationView ApplicationView { get; }
    }
}
