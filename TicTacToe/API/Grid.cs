using System;
using System.Configuration;

namespace API
{
    public class Grid
    {
        private readonly Moves[] _gameGrid;

        public Grid()
        {
            _gameGrid = new[]
            {
                Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                Moves.Blank
            };
        }

        private int CalculatePosition(int row, int column)
        {
            short gridSize = short.Parse(ConfigurationManager.AppSettings["grid size"]);
            return column + row*(gridSize/3);
        }

        private void Add(int position, Moves move)
        {
            _gameGrid[position] = move;
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

        public Moves[] GetGrid()
        {
            return _gameGrid;
        }

        public void PrettyPrint()
        {
            for (short position = 0; position < short.Parse(ConfigurationManager.AppSettings["grid size"]); position++)
            {
                string valueToPrint = _gameGrid[position] == Moves.Blank
                    ? "\t[ ]" + ((position + 1)%3 == 0 ? "\n\n" : "")
                    : $"\t[{_gameGrid[position]}]" + ((position + 1)%3 == 0 ? "\n\n" : "");
                Console.Write(valueToPrint);
            }
        }
    }
}
