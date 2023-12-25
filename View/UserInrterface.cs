using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Controllers;

namespace TicTacToe.View
{
    public class UserInrterface : BaseUserInrterface
    {
        public UserInrterface(TextReader reader, TextWriter writer, BaseHandler handler) : base(reader, writer, handler)
        {
        }

        public override string GetUserInput()
        {
            return Reader.ReadLine();
        }

        public override void HandleUserInput(string userInput)
        {
            handler.ExecuteCommand(userInput);
        }

        public override void Run()
        {
            while (true)
            {
                var text = GetUserInput();
                HandleUserInput(text);
            }
        }
    }
}
