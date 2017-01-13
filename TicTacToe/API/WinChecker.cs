﻿namespace API
{
    public class WinChecker
    {
        public bool HasWon(Moves[] input)
        {
            return HorizantalWin(input) || VerticalWin(input) || DiagonalWin(input);
        }

        private bool DiagonalWin(Moves[] input)
        {
            bool notBlank = input[4] != Moves.Blank;
            bool xEqualsMinusYWin = notBlank && input[0] == input[4] && input[4] == input[8];
            bool xEqualsYWin = notBlank && input[2] == input[4] && input[4] == input[6];
            return xEqualsMinusYWin || xEqualsYWin;
        }

        private bool VerticalWin(Moves[] input)
        {
            for (int index = 0; index < 3; index++)
            {
                if (CheckVertical(input, index)) return true;
            }
            return false;
        }

        private bool CheckVertical(Moves[] input, int index)
        {
            if (input[index] == input[index + 3] && input[index + 3] == input[index + 6] && input[index] != Moves.Blank)
            {
                return true;
            }
            return false;
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
            if (input[index] == input[index + 1] && input[index + 1] == input[index + 2] && input[index] != Moves.Blank)
            {
                return true;
            }
            return false;
        }
    }
}