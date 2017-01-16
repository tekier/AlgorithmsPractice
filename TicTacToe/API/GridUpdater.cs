using System;

namespace API
{
    public static class GridUpdater
    {
        private static readonly Grid GameGrid;

        static GridUpdater()
        {
            GameGrid = new Grid();
        }

        public static Moves[] GetGrid()
        {
            return GameGrid.GetGrid();
        }

        public static void InsertIntoGrid(Tuple<short, short> positionOnGrid, Moves moveToAdd)
        {
            if (moveToAdd == Moves.X)
                GameGrid.InsertX(positionOnGrid.Item1, positionOnGrid.Item2);
            if (moveToAdd == Moves.O)
                GameGrid.InsertO(positionOnGrid.Item1, positionOnGrid.Item2); ;
        }

        public static Moves GetValueAt(Tuple<short, short> positionOnGrid)
        {
            return GameGrid.GetValueAt(positionOnGrid.Item1, positionOnGrid.Item2);
        }
    }
}
