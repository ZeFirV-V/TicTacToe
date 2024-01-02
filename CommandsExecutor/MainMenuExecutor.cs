using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.Models.Commands;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.CommandsExecutor
{
    public class MainMenuExecutor : BaseCommandsExecutor
    {
        public MainMenuExecutor(string nameExecutor, ApplicationState executorApplicationState, IGameContext gameContext, IApplicationView applicationView)
            : base(nameExecutor, executorApplicationState, gameContext, applicationView)
        {
        }

        public override string[] GetAvailableCommandsName()
        {
            if (GameContext.GameState == GameState.NotStart)
            {
                return commands.Where(command => !string.Equals(command.Name, "c", StringComparison.OrdinalIgnoreCase)).Select(c => c.Name).ToArray();
            }
            return commands.Select(c => c.Name).ToArray();
        }

        public override void Register(BaseCommand command)
        {
            command.OnHappened += ReportCommandHappened;
            commands.Add(command);
        }

        public override void Execute(string[] args)
        {
            if (args[0].Length == 0)
            {
                applicationView.ViewText("Please specify <command> as the first command line argument");
                return;
            }

            var commandName = args[0];
            var cmd = FindCommandByName(commandName);
            if (cmd == null)
            {
                applicationView.ViewText($"Sorry. Unknown command {commandName}");
            }
            else
            {
                cmd.Execute(new CommandContext(commandName));
            }
        }

        private BaseCommand? FindCommandByName(string name)
        {
            if(GameContext.GameState == GameState.NotStart && name == "c")
            {
                return null;
            }
            return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}