using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Commands;
using TicTacToe.Models.Contexts.ApplicationContext.Interfaces;
using TicTacToe.View;

namespace TicTacToe.CommandsExecutor
{
    public class MainMenuCommandsExecutor : BaseCommandsExecutor
    {
        public MainMenuCommandsExecutor(string nameExecutor, IApplicationContext applicationContext, IApplicationView applicationView) 
            : base(nameExecutor, applicationContext, applicationView)
        {
        }

        public override string[] GetAvailableCommandsName()
        {
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
                //Console.WriteLine("Please specify <command> as the first command line argument");
                return;
            }

            var commandName = args[0];
            var cmd = FindCommandByName(commandName);
            if (cmd == null)
            {
                //writer.WriteLine($"Sorry. Unknown command {commandName}");
            }
            else
                cmd.Execute(applicationContext, applicationView);
        }

        private BaseCommand? FindCommandByName(string name)
        {
            return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

