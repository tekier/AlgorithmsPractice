using System;
using API;

namespace Application
{
    class Program
    {
        private static readonly Validator _validator = new Validator();
        static void Main()
        {
            Console.WriteLine("Welcome to this 2 player tictactoe game.\nMoves should be in the format[row][coloumn][X / O]\n");
            Console.WriteLine("Enter move in format [row] [column] [X/O]\n");
            short numberOfMovesSoFar = 0;
            while (Game.HasNotBeenWon(numberOfMovesSoFar))
            {
                string userInput;
                GetUserInput(out userInput);
                Game.Apply(userInput);
                numberOfMovesSoFar++;
                Console.WriteLine($"\nNumber of moves made so far : {numberOfMovesSoFar}");
                Game.PrintGrid();
            }
            Console.WriteLine($"\nGame exhausted - {numberOfMovesSoFar} moves made");
            Console.Read();
        }

        private static void GetUserInput(out string userInput)
        {
            userInput = Console.ReadLine();
            while (!_validator.ValidateInput(userInput))
            {
                RetryGettingUserInput(ref userInput);
            }
        }

        private static void RetryGettingUserInput(ref string userInput)
        {
            Console.WriteLine("Reenter in correct format . . .\n");
            userInput = Console.ReadLine();
        }
    }
}
