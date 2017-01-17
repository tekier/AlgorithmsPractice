using System;
using API;

namespace Application
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to this 2 player tictactoe game.\nMoves should be in the format[row][coloumn][X / O]\n");
            Console.WriteLine("Enter move in format [row < 3][column < 3][X/O] e.g. 0 2 X to place X in top righthand corner.\n");
            Game.PrintGrid();

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
            Console.WriteLine("Enter move in format [row < 3][column < 3][X / O]\n");
            userInput = Console.ReadLine();
            while (Game.ValidateInput(userInput))
            {
                Console.WriteLine("\nReenter in correct format . . .\n");
                RetryGettingUserInput(ref userInput);
            }
        }
        private static void RetryGettingUserInput(ref string userInput)
        {
            if (userInput == null) throw new ArgumentNullException(nameof(userInput));
            userInput = Console.ReadLine();
        }
    }
}
