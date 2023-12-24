using TicTacToe.Models.Enums;

namespace TicTacToe.Helpers
{
    public static class SymbolsConvertor
    {
        public static bool TryConvertStringToSymbol(string playerSymbolString, out Symbols convertedSymbol)
        {
            if (playerSymbolString == "o")
            {
                convertedSymbol = Symbols.circle;
                return true;
            }
            else if (playerSymbolString == "x")
            {
                convertedSymbol = Symbols.cross;
                return true;
            }
            else
            {
                convertedSymbol = Symbols.empty;
                return false;
            }
        }

        public static bool TryConvertSymbolToString(Symbols playerSymbol, out string viewSymbolString)
        {
            if (playerSymbol == Symbols.circle)
            {
                viewSymbolString = "o";
                return true;
            }
            else if (playerSymbol == Symbols.cross)
            {
                viewSymbolString = "x";
                return true;
            }
            else if (playerSymbol == Symbols.empty)
            {
                viewSymbolString = " ";
                return true;
            }
            else
            {
                viewSymbolString = "";
                return false;
            }
        }
    }
}
