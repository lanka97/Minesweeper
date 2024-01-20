using Moq;

namespace Minesweeper.UnitTests;

internal class TileGridTest
{
    [TestCase(5)]
    [TestCase(8)]
    public void GenerateBoard_ShouldCreateTileGridWithCorrectGridLength(int length)
    {
        var tileGrid = TileGrid.GenerateBoard(length);

        Assert.That(tileGrid.GridSize, Is.EqualTo(length));
    }

    [TestCase(5)]
    [TestCase(8)]
    public void GenerateBoard_ShouldCreateTileGridWithCorrectGrid(int length)
    {
        var tileGrid = TileGrid.GenerateBoard(length);

        Assert.That(tileGrid.Grid, Is.Not.Null);
    }

    [TestCase(5)]
    [TestCase(8)]
    public void GenerateBoard_ShouldCreateTileGridWithGridLength(int length)
    {
        var tileGrid = TileGrid.GenerateBoard(length);

        Assert.That(tileGrid.Grid.GetLength(1), Is.EqualTo(length));
    }

    [Test]
    public void DisplayGridString_ShouldReturnStringWithCorrectFormat()
    {
        const int length = 3;
        var tileGrid = TileGrid.GenerateBoard(length);

        var displayString = tileGrid.DisplayGridString();

        StringAssert.Contains("A", displayString);
        StringAssert.Contains("B", displayString);
        StringAssert.Contains("C", displayString);

        for (var i = 1; i <= length; i++) StringAssert.Contains(i.ToString(), displayString);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void SetAllRevealed_ShouldSetAllTilesToRevealed(bool input)
    {
        const int length = 4;
        var tileGrid = TileGrid.GenerateBoard(length);

        tileGrid.SetAllRevealed(input);

        for (var row = 0; row < length; row++)
        for (var col = 0; col < length; col++)
            Assert.That(tileGrid.Grid[row, col].IsRevealed, Is.True);
    }

    [Test]
    public void DisplayGridString_ShouldContainCorrectCellSymbols()
    {
        const int length = 2;
        var mockTile = new Mock<Tile>();
        mockTile.Setup(t => t.GetCellSymbol()).Returns('X');

        var tileGrid = TileGrid.GenerateBoard(length);
        tileGrid.Grid[0, 0] = mockTile.Object;
        tileGrid.Grid[0, 1] = mockTile.Object;
        tileGrid.Grid[1, 0] = mockTile.Object;
        tileGrid.Grid[1, 1] = mockTile.Object;

        var displayString = tileGrid.DisplayGridString();

        StringAssert.Contains("X", displayString);
    }
}