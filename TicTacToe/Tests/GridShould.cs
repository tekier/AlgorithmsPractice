using API;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GridShould
    {
        private Grid _testGrid;

        [SetUp]
        public void SetUp()
        {
            _testGrid = new Grid();
        }

        [TestCase(0, 0,new[] { Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank})]
        [TestCase(0, 1,
             new[]
             {
                 Moves.Blank, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(0, 2,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(1, 0,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(1, 1,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(1,2,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(2,0,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(2,1,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.X,
                 Moves.Blank
             })]
        [TestCase(2,2,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.X
             })]
        public void AddXToGridCorrectly(int row, int column, Moves[] expectedGrid)
        {
            _testGrid.InsertX(row, column);
            Assert.AreEqual(_testGrid.GetGrid(), expectedGrid);
        }

        [TestCase(1, 1,
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.O, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void AddOToGridCorrectly(int row, int column, Moves[] expectedGrid)
        {
            _testGrid.InsertO(row, column);
            Assert.AreEqual(_testGrid.GetGrid(), expectedGrid);
        }
    }
}
