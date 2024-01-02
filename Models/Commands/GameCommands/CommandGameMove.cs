using TicTacToe.CustomsEventArgs;
using TicTacToe.Helpers;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Models.Enums;
using TicTacToe.View;

namespace TicTacToe.Models.Commands.GameCommands
{
    public class CommandGameMove : BaseCommand
    {
        public CommandGameMove(IGameContext gameContext, IApplicationView applicationView, string name,
            ApplicationState nextExecutorType)
            : base(gameContext, applicationView, name, nextExecutorType)
        {
        }

        public override event EventHandler<ExecutorEventArgs> OnHappened;

        public override void Execute(ICommandContext commandContext)
        {
            int pointNumber;
            if (commandContext.CommandName == null || !int.TryParse(commandContext.CommandName, out pointNumber))
            {
                throw new Exception("Ожидалось число, но прошло что то другое");
            }

            var pointConvertor = new PointConvertor(gameContext.MatchInfo.GameBoard.Size);
            var gamePoint = pointConvertor.NumberConvertPoint(pointNumber - 1);
            if (gameContext.MatchInfo.IsCanMove(gamePoint))
            {
                gameContext.StepGame(gamePoint);
            }
            else
            {
                applicationView.ViewText("Точка занята");
            }
        }
    }
}
