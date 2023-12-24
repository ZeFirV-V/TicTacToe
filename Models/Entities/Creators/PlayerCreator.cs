using TicTacToe.Entities;
using TicTacToe.Enums;
using TicTacToe.Helpers;

namespace TicTacToe.Entities.Creators
{
    public static class PlayerCreator
    {
        private static int playerNumber = 1;
        private static List<Symbols> busySymbols = new List<Symbols>();

        public static Symbols ReadPlayerSymbol(TextWriter writer, TextReader reader)
        {
            Symbols playerSymbol;
            bool symbolChosen;
            do
            {
                writer.WriteLine($"Введите обозначение (O или X) для {playerNumber}-го игрока:");
                string playerSymbolString = reader.ReadLine().ToLower();
                symbolChosen = SymbolsConvertor.TryConvertStringToSymbol(playerSymbolString, out playerSymbol);
                if (symbolChosen && !CheckFreeSymbol(playerSymbol))
                {
                    writer.WriteLine($"{playerSymbolString} уже занят");
                    symbolChosen = false;
                }
            }
            while (!symbolChosen);
            return playerSymbol;
        }

        public static string ReadPlayerName(TextWriter writer, TextReader reader)
        {
            writer.WriteLine($"Введите имя {playerNumber}-го игрока:");
            return reader.ReadLine();
        }

        public static Player CreatePlayer(TextWriter writer, TextReader reader)
        {
            var playerName = ReadPlayerName(writer, reader);
            var playerSymbol = ReadPlayerSymbol(writer, reader);
            var player = new Player(playerName, playerSymbol);
            playerNumber++;
            busySymbols.Add(playerSymbol);
            return player;
        }

        private static bool CheckFreeSymbol(Symbols symbol)
        {
            return !busySymbols.Contains(symbol);
        }
    }
}