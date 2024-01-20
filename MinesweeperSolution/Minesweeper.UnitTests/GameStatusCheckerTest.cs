using Minesweeper.Util.GameStatusCheck;

namespace Minesweeper.UnitTests;

internal class GameStatusCheckerTest
{
    [Test]
    public void CheckWin_ReturnsTrue_whenAllNormalTilesRevealed()
    {
        var tileGrid = TileGrid.GenerateBoard(2);
        var fakeRandomMinePlacer = new MockRandomMinePlacer();
        fakeRandomMinePlacer.SetMines(1, tileGrid.Grid);

        tileGrid.Grid[0, 1].IsRevealed = true;
        tileGrid.Grid[1, 0].IsRevealed = true;
        tileGrid.Grid[1, 1].IsRevealed = true;
        var result = GameStatusChecker.CheckWin(tileGrid.Grid);

        Assert.That(result, Is.True, "Should return true when all the normal tiles selected");
    }

    [Test]
    public void CheckWin_ReturnsFalse_whenSomeNormalTilesRevealed()
    {
        var tileGrid = TileGrid.GenerateBoard(2);
        var fakeRandomMinePlacer = new MockRandomMinePlacer();
        fakeRandomMinePlacer.SetMines(0, tileGrid.Grid);

        tileGrid.Grid[0, 1].IsRevealed = true;
        tileGrid.Grid[1, 0].IsRevealed = true;
        var result = GameStatusChecker.CheckWin(tileGrid.Grid);

        Assert.That(result, Is.False, "Should return false when some of the normal tiles selected");
    }

    [Test]
    public void CheckLose_ReturnsTrue_whenMineRevealed()
    {
        var tileGrid = TileGrid.GenerateBoard(2);
        var fakeRandomMinePlacer = new MockRandomMinePlacer();
        fakeRandomMinePlacer.SetMines(1, tileGrid.Grid);

        var result = GameStatusChecker.CheckLose(tileGrid.Grid[0, 0]);

        Assert.That(result, Is.True, "Should return true when Mine tile passed");
    }

    [Test]
    public void CheckLose_ReturnsFalse_whenNormalTileRevealed()
    {
        var tileGrid = TileGrid.GenerateBoard(2);
        var fakeRandomMinePlacer = new MockRandomMinePlacer();
        fakeRandomMinePlacer.SetMines(0, tileGrid.Grid);

        var result = GameStatusChecker.CheckLose(tileGrid.Grid[0, 1]);

        Assert.That(result, Is.False, "Should return false when normal tile passed");
    }
}