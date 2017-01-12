using System;
using API;

namespace Application
{
    class Program
    {
        private static Validator _validator = new Validator();
        static void Main()
        {
            Welcome();
            string userInput = Console.ReadLine();
            while (!_validator.ValidateInput(userInput))
            {
                userInput = NewMethod();
            }
            while (Game.HasNotBeenWon(8))
            {
                Game.Apply(userInput);
                Game.PrintGrid();
            }
            Console.Read();
        }

        private static string NewMethod()
        {
            string userInput;
            ErrorMessage();
            userInput = Console.ReadLine();
            return userInput;
        }

        private static void ErrorMessage()
        {
            Console.WriteLine("Reenter in correct format . . .");
            Console.WriteLine();
        }

        private static void Welcome()
        {
            Console.WriteLine("Welcome to this 2 player tictactoe game.");
            Console.WriteLine("Moves should be in the format [row] [coloumn] [X/O]");
            Console.WriteLine();
            TurnPromptMessage();
        }

        private static void TurnPromptMessage()
        {
            Console.WriteLine("Enter move in format [row] [column] [X/O]");
            Console.WriteLine();
        }
    }
}
