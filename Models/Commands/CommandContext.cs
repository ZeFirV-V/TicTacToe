using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Commands
{
    public class CommandContext : ICommandContext
    {
        public string CommandName { get; }
        //public string CommandDescription { get; }

        public CommandContext(string commandName) 
        {
            CommandName = commandName;
            //CommandDescription = commandDescription;
        }
    }
}
