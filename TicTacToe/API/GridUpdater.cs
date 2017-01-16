using System;
using System.Configuration;

namespace API
{
    public static class GridUpdater
    {
        private static readonly Grid CurrentGrid = new Grid();

        public static Moves[] GetGrid()
        {
            return CurrentGrid.GameGrid;
        }
        
        public static void SetGrid(Moves[] testMoves)
        {
            CurrentGrid.GameGrid = testMoves;
        }

        public static void InsertIntoGrid(Tuple<short, short> positionOnGrid, Moves moveToAdd)
        {
            int positionToAddTo = CalculatePosition(positionOnGrid.Item1, positionOnGrid.Item2);
            if (moveToAdd == Moves.X)
                CurrentGrid.GameGrid[positionToAddTo] = moveToAdd;
            if (moveToAdd == Moves.O)
                CurrentGrid.GameGrid[positionToAddTo] = moveToAdd;
        }
        public static Moves GetValueAt(Tuple<short, short> positionOnGrid)
        {
            int positionToRetrieveFrom = CalculatePosition(positionOnGrid.Item1, positionOnGrid.Item2);
            return CurrentGrid.GameGrid[positionToRetrieveFrom];
        }
        private static int CalculatePosition(int row, int column)
        {
            short gridSize = short.Parse(ConfigurationManager.AppSettings["grid size"]);
            return column + row * (gridSize / short.Parse(ConfigurationManager.AppSettings["number of input elements"]));
        }

        public static void PrettyPrint()
        {
            short size = short.Parse(ConfigurationManager.AppSettings["number of input elements"]);
            for (short position = 0; position < short.Parse(ConfigurationManager.AppSettings["grid size"]); position++)
            {
                string valueToPrint = CurrentGrid.GameGrid[position] == Moves.Blank
                    ? "\t[ ]" + ((position + 1) % size == 0 ? "\n\n" : "")
                    : $"\t[{CurrentGrid.GameGrid[position]}]" + ((position + 1) % size == 0 ? "\n\n" : "");
                Console.Write(valueToPrint);
            }
        }
    }
}
