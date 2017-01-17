using System;
using System.Configuration;

namespace API
{
    internal static class GridUpdater
    {
        private static readonly Grid CurrentGrid = new Grid();

        public static Moves[] GetGrid()
        {
            return CurrentGrid.GameGrid;
        }

        public static void InsertIntoGrid(Tuple<short, short> positionOnGrid, Moves moveToAdd)
        {
            CurrentGrid.GameGrid[CalculatePosition(positionOnGrid.Item1, positionOnGrid.Item2)] = moveToAdd;
        }

        public static Moves GetValueAt(Tuple<short, short> positionOnGrid)
        {
            return CurrentGrid.GameGrid[CalculatePosition(positionOnGrid.Item1, positionOnGrid.Item2)];
        }

        private static int CalculatePosition(int row, int column)
        {
            var gridSizeAsString = ConfigurationManager.AppSettings["grid size"];
            short gridSize = short.Parse(gridSizeAsString);
            return column + row*(gridSize/short.Parse(ConfigurationManager.AppSettings["number of input elements"]));
        }

        public static void PrettyPrint()
        {
            var gridSizeAsString = ConfigurationManager.AppSettings["grid size"];
            var numberOfInputElementsAsStrings = ConfigurationManager.AppSettings["number of input elements"];
            short size = short.Parse(numberOfInputElementsAsStrings);
            for (short position = 0; position < short.Parse(gridSizeAsString); position++)
            {
                Console.Write(GetStringToPrint(size, position));
            }
        }

        private static string GetStringToPrint(short size, short position)
        {
            return CurrentGrid.GameGrid[position] == Moves.Blank
                ? "\t[ ]" + ((position + 1)%size == 0 ? "\n\n" : "")
                : $"\t[{CurrentGrid.GameGrid[position]}]" + ((position + 1)%size == 0 ? "\n\n" : "");
        }
    }
}