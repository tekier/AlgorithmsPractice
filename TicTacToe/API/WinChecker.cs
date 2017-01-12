namespace API
{
    public class WinChecker
    {
        public bool HasWon(Moves[] input)
        {
            return HorizantalWin(input);
        }

        private bool HorizantalWin(Moves[] input)
        {
            for (int index = 0; index < 7; index += 3)
            {
                if (CheckHorizantal(input, index)) return true;
            }
            return false;
        }

        private bool CheckHorizantal(Moves[] input, int index)
        {
            if (input[index] == input[index + 1] && input[index + 1] == input[index + 2] &&
                input[index] != Moves.Blank)
            {
                return true;
            }
            return false;
        }
    }
}