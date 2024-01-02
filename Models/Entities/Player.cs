namespace TicTacToe.Entities
{
    public class Player
    {
        public string Name { get; }
        public char GameIdentificationMark { get; }

        public Player(string name, char gameIdentificationMark)
        {
            Name = name;
            GameIdentificationMark = gameIdentificationMark;
        }
    }
}
