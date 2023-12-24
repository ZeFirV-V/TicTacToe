using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.CustomsEventArgs;
using TicTacToe.Models.Commands.MainMenuCommands.BaseMenuCommand;

namespace TicTacToe.CommandsExecutor
{
    public class MainMenuCommandsExecutor : ICommandsExecutor
    {
        private readonly List<BaseMainMenuCommand> commands;
        public string ExecutorName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public event EventHandler<ExecutorEventArgs> OnCommittedCommand;
        public event EventHandler<CommandEventArgs> OnRunCommand;

        public MainMenuCommandsExecutor(string name)
        {
            ExecutorName = name;
            commands = new List<BaseMainMenuCommand>();
        }

        private void ReportCommandHappened(object sender, CommandEventArgs e)
        {
            OnCommittedCommand(this, new ExecutorEventArgs(e.ExecutorName));
            OnRunCommand(this, e);
        }

        public void Register(BaseMainMenuCommand command)
        {
            command.OnHappened += ReportCommandHappened;
            commands.Add(command);
        }

        public string[] GetAvailableCommandName()
        {
            return commands.Select(c => c.Name).ToArray();
        }

        public BaseMainMenuCommand? FindCommandByName(string name)
        {
            return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public void Execute(string[] args)
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
                cmd.Execute(args);
        }
    }
}

