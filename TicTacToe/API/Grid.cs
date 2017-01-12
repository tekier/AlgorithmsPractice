using System.Configuration;

namespace API
{
    public class Grid
    {
        public Moves[] GameGrid { get; set; }
        private static readonly short GridSize = short.Parse(ConfigurationManager.AppSettings["grid size"]);

        public Grid()
        {
            GameGrid = new[]
            {
                Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                Moves.Blank
            };
        }

        private int CalculatePosition(int row, int column)
        {
            return column + row*(GridSize/3);
        }

        private void Add(int position, Moves move)
        {
            GameGrid[position] = move;
        }

        public void InsertX(int row, int column)
        {
            int position = CalculatePosition(row, column);
            Add(position, Moves.X);
        }

        public void InsertO(int row, int column)
        {
            int position = CalculatePosition(row, column);
            Add(position, Moves.O);
        }
    }
}
