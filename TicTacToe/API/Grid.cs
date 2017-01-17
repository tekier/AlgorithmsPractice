using System.Configuration;

namespace API
{
    internal class Grid
    {
        private static Moves[] _gameGrid;
        private static readonly string GridSizeAsString = ConfigurationManager.AppSettings["grid size"];

        public Moves[] GameGrid => _gameGrid;

        public Grid()
        {
            short size = short.Parse(GridSizeAsString);
            _gameGrid = new Moves[size];
            for (int index = 0; index < size; index++)
            {
                _gameGrid[index] = Moves.Blank;
            }
        }
    }
}
