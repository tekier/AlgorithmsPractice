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

        public static void InsertIntoGrid(Tuple<ushort, ushort> positionOnGrid, Moves moveToAdd)
        {
            CurrentGrid.GameGrid[CalculatePosition(positionOnGrid.Item1, positionOnGrid.Item2)] = moveToAdd;
        }

        public static Moves GetValueAt(Tuple<ushort, ushort> positionOnGrid)
        {
            return CurrentGrid.GameGrid[CalculatePosition(positionOnGrid.Item1, positionOnGrid.Item2)];
        }

        private static int CalculatePosition(int row, int column)
        {
            var gridSizeAsString = ConfigurationManager.AppSettings["grid size"];
            ushort gridSize = ushort.Parse(gridSizeAsString);
            return column + row*(gridSize/short.Parse(ConfigurationManager.AppSettings["number of input elements"]));
        }

        public static void PrettyPrint()
        {
            var gridSizeAsString = ConfigurationManager.AppSettings["grid size"];
            var numberOfInputElementsAsStrings = ConfigurationManager.AppSettings["number of input elements"];
            ushort size = ushort.Parse(numberOfInputElementsAsStrings);
            for (ushort position = 0; position < ushort.Parse(gridSizeAsString); position++)
            {
                Console.Write(GetStringToPrint(size, position));
            }
        }

        private static string GetStringToPrint(ushort size, ushort position)
        {
            return CurrentGrid.GameGrid[position] == Moves.Blank
                ? "\t[ ]" + ((position + 1)%size == 0 ? "\n\n" : "")
                : $"\t[{CurrentGrid.GameGrid[position]}]" + ((position + 1)%size == 0 ? "\n\n" : "");
        }
    }
}