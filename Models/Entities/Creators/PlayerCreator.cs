namespace TicTacToe.Entities.Creators
{
    public class PlayerCreator
    {
        private int playerNumber;
        private List<char> busySymbols;

        public PlayerCreator()
        {
            busySymbols = new List<char>();
            playerNumber = 1;
        }

        public char ReadPlayerSymbol(TextWriter writer, TextReader reader)
        {
            writer.WriteLine($"Введите обозначение (O или X) для {playerNumber}-го игрока:");

            var playerSymbolString = reader.ReadLine().ToLower();
            return playerSymbolString[0];
        }

        public string ReadPlayerName(TextWriter writer, TextReader reader)
        {
            writer.WriteLine($"Введите имя {playerNumber}-го игрока:");
            return reader.ReadLine();
        }

        public Player CreatePlayer(TextWriter writer, TextReader reader)
        {
            var playerName = ReadPlayerName(writer, reader);
            var playerSymbol = ReadPlayerSymbol(writer, reader);
            var player = new Player(playerName, playerSymbol);
            playerNumber++;
            busySymbols.Add(playerSymbol);
            return player;
        }

        private bool CheckFreeSymbol(char symbol)
        {
            return !busySymbols.Contains(symbol);
        }
    }
}