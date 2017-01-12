namespace API
{
    public class Game
    {
        private Grid _gameGrid;
        private WinChecker _winChecker;

        public Game()
        {
            _gameGrid = new Grid();
        }


        public static bool HasNotBeenWon(int numberOfMoves)
        {
            if (numberOfMoves > 9)
                return false;
            throw new System.NotImplementedException();
        }

        public static void Apply(string userInput)
        {
            throw new System.NotImplementedException();
        }

        public static void PrintGrid()
        {
            
        }
    }
}
