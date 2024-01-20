using Minesweeper.Util.MinesPlacer;

namespace Minesweeper.UnitTests;

internal class RamdomMinePlacerTest
{
    [Test]
    public void SetMines_ShouldPlaceCorrectNumberOfMines()
    {
        var tileGrid = TileGrid.GenerateBoard(4);
        var randomMinePlacer = new RandomMinePlacer();

        randomMinePlacer.SetMines(4, tileGrid.Grid);

        var mineCount = 0;
        for (var row = 0; row < 4; row++)
        for (var col = 0; col < 4; col++)
            if (tileGrid.Grid[row, col] is MineTile)
                mineCount++;

        Assert.That(mineCount, Is.EqualTo(4));
    }

    [Test]
    public void SetMines_ShouldPlaceCorrectNumberOfNormalTiles()
    {
        var tileGrid = TileGrid.GenerateBoard(4);
        var randomMinePlacer = new RandomMinePlacer();
        randomMinePlacer.SetMines(4, tileGrid.Grid);

        var normalCount = 0;
        for (var row = 0; row < 4; row++)
        for (var col = 0; col < 4; col++)
            if (tileGrid.Grid[row, col] is NormalTile)
                normalCount++;

        Assert.That(normalCount, Is.EqualTo(12));
    }

    [Test]
    public void CalculateNearbyMines_NoAdjacentMines_CountShouldBeZero()
    {
        Tile[,] tileGrid = new Tile[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                tileGrid[i, j] = new NormalTile();
        var randomMinePlacer = new RandomMinePlacer();

        randomMinePlacer.CalculateNearbyMines(tileGrid);

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Assert.That(((NormalTile)tileGrid[i, j]).AdjacentMinesCount, Is.EqualTo(0),
                    $"Adjacent mines count for tile at ({i}, {j}) should be 0.");
    }

    [TestCase(3, 0, 0, 0, 1, 1)]
    [TestCase(3, 1, 0, 0, 1, 1)]
    [TestCase(4, 2, 0, 2, 1, 1)]
    [TestCase(4, 0, 0, 0, 1, 1)]
    [TestCase(4, 0, 0, 0, 2, 0)]
    public void CalculateNearbyMines_AdjacentMinesCountIsCorrect(
       int gridSize, int mineRow, int mineCol, int testRow, int testCol, int expectedAdjacentMinesCount)
    {
        Tile[,] tileGrid = new Tile[gridSize, gridSize];
        var randomMinePlacer = new RandomMinePlacer();

        for (int i = 0; i < gridSize; i++)
            for (int j = 0; j < gridSize; j++)
                tileGrid[i, j] = (i == mineRow && j == mineCol) ? new MineTile() : new NormalTile();

        randomMinePlacer.CalculateNearbyMines(tileGrid);

        Assert.That(((NormalTile)tileGrid[testRow, testCol]).AdjacentMinesCount, Is.EqualTo(expectedAdjacentMinesCount),
            $"Adjacent mines count for tile at ({testRow}, {testCol}) should be {expectedAdjacentMinesCount}.");
    }

    [TestCase(0, 0, 1)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 1, 1)]
    [TestCase(2, 0, 2)]
    [TestCase(2, 1, 2)]
    [TestCase(3, 1, 1)]
    [TestCase(3, 3, 0)]
    [TestCase(0, 2, 0)]
    [TestCase(0, 3, 0)]
    public void CalculateNearbyMines_AdjacentMinesCountIsCorrect_withMuliplrMines(int testRow, int testCol, int expectedAdjacentMinesCount)
    {
        int gridSize = 4;
        Tile[,] tileGrid = new Tile[gridSize, gridSize];
        var randomMinePlacer = new RandomMinePlacer();
        for (int i = 0; i < gridSize; i++)
            for (int j = 0; j < gridSize; j++)
                tileGrid[i, j] = new NormalTile();
        /* 1 1 0 0 
         * X 1 0 0 
         * 2 2 0 0 
         * X 1 0 0 
        */
        tileGrid[1, 0] = new MineTile();
        tileGrid[3, 0] = new MineTile();

        randomMinePlacer.CalculateNearbyMines(tileGrid);

        Assert.That(((NormalTile)tileGrid[testRow, testCol]).AdjacentMinesCount, Is.EqualTo(expectedAdjacentMinesCount),
            $"Adjacent mines count for tile at ({testRow}, {testCol}) should be {expectedAdjacentMinesCount}.");
    }
}