using System.Configuration;

namespace API
{
    public class Grid
    {
        private static Moves[] _gameGrid;

        public Moves[] GameGrid
        {
            get { return _gameGrid; }
            set { _gameGrid = value; }
        }

        public Grid()
        {
            short size = short.Parse(ConfigurationManager.AppSettings["grid size"]);
            _gameGrid = new Moves[size];
            for (int index = 0; index < size; index++)
            {
                _gameGrid[index] = Moves.Blank;
            }
        }
    }
}
