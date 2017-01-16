﻿using System;
using API;

namespace Application
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to this 2 player tictactoe game.\nMoves should be in the format[row][coloumn][X / O]\n");
            Console.WriteLine("Enter move in format [row] [column] [X/O]\n");

            while (Game.HasNotBeenWon() && Game.HasNotBeenDrawn())
            {
                string userInput;
                GetUserInput(out userInput);
                Game.Apply(userInput);
                int numberOfMovesSoFar = Game.GetNumberOfMoves();
                Console.WriteLine($"\nNumber of moves made so far : {numberOfMovesSoFar}");
                Game.PrintGrid();
            }

            Console.WriteLine($"\nGame exhausted - {Game.GetNumberOfMoves()} moves made");
            Console.Read();
        }

        private static void GetUserInput(out string userInput)
        {
            userInput = Console.ReadLine();
            while (MoveValidator.ValidateInput(userInput) == InvalidMove.IncorrectFormatError)
            {
                RetryGettingUserInput(ref userInput);
                Console.WriteLine("Reenter in correct format . . .\n");
            }
        }
        private static void RetryGettingUserInput(ref string userInput)
        {
            userInput = Console.ReadLine();
        }
    }
}
