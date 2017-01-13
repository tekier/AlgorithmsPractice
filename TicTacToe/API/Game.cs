using System;

namespace API
{
    public static class Game
    {
        private static readonly Grid GameGrid;

        static Game()
        {
            GameGrid = new Grid();
        }

        public static bool HasNotBeenWon()
        {
            var gridToCheckWin = GameGrid.GetGrid();
            return !WinChecker.HasWon(gridToCheckWin);
        }

        public static void Apply(string userInput)
        {
            Moves moveToAdd = MoveParser.ExtractMove(userInput);
            Tuple<short,short> positionOnGrid = MoveParser.GetCoordinates(userInput);
            InsertToGrid(positionOnGrid, moveToAdd);
        }

        private static void InsertToGrid(Tuple<short, short> positionOnGrid, Moves moveToAdd)
        {
            if(moveToAdd == Moves.X)
                GameGrid.InsertX(positionOnGrid.Item1, positionOnGrid.Item2);
            if(moveToAdd == Moves.O)
                GameGrid.InsertO(positionOnGrid.Item1, positionOnGrid.Item2);
        }

        public static void PrintGrid()
        {
            GameGrid.PrettyPrint();
        }
    }
}
