using TicTacToe.CommandsExecutor;
using TicTacToe.CommandsExecutor.Interfaces;
using TicTacToe.Controllers;
using TicTacToe.Models.Commands;
using TicTacToe.Models.Commands.GameCommands;
using TicTacToe.Models.Commands.MainMenuCommands;
using TicTacToe.Models.Contexts.GameContext;
using TicTacToe.Models.Enums;
using TicTacToe.Services;
using TicTacToe.View;

var view = Console.Out;
var reader = Console.In;

var gameContext = new GameContext();
var applicationView = new ApplicationView(view, reader);

var commandCreator = new CommandCreator(gameContext, applicationView);
var executorCreator = new CommandExecutorCreator(gameContext, applicationView);

var mainMenuExecutor = executorCreator.CreateExecutor<MainMenuExecutor>("mainMenu", ApplicationState.mainMenu);
var gameMenuExecutor = executorCreator.CreateExecutor<CommandsExecutor>("gameMenu", ApplicationState.gameMenu);
var gameExecutor = executorCreator.CreateExecutor<GameExecutor>("game", ApplicationState.game);
var emptyExecutor = executorCreator.CreateExecutor<CommandsExecutor>("empty", ApplicationState.empty);

mainMenuExecutor.Register(commandCreator.CreateCommand<StartGameCommand>("s", ApplicationState.game));
mainMenuExecutor.Register(commandCreator.CreateCommand<ExitCommand>("e", ApplicationState.empty));
mainMenuExecutor.Register(commandCreator.CreateCommand<CommandNavigation>("c", ApplicationState.game));

gameExecutor.Register(commandCreator.CreateCommand<CommandExitInGameMenu>("e", ApplicationState.gameMenu));
gameExecutor.Register(commandCreator.CreateCommand<CommandGameMove>("n", ApplicationState.game));

gameMenuExecutor.Register(commandCreator.CreateCommand<CommandNavigation>("e", ApplicationState.mainMenu));
gameMenuExecutor.Register(commandCreator.CreateCommand<CommandNavigation>("c", ApplicationState.game));

var executors = new List<ICommandsExecutor>() { mainMenuExecutor, gameMenuExecutor, gameExecutor, emptyExecutor };
var applicationExecutorService = new ExecutorsService(executors, mainMenuExecutor);
var handler = new Handler(gameContext, applicationView, applicationExecutorService);
var userLauncher = new Launcher(applicationView, handler);

userLauncher.Run();