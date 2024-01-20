using Minesweeper.Util.MinesPlacer;

namespace Minesweeper.IntegrationTests;

public class MineSweeperIntegrationTests
{
    [Test]
    public void PlayGameBordShouldHadleLostOnMineSelect()
    {
        const string input = "4";
        const string mines = "4";
        IRandomMinePlacer minePlacer = new RandomMinePlacer();
        var fakeReader = new MockReader(new[] { input, mines });
        var game = new Game(fakeReader, minePlacer);
        game.CreateBoard();
        var mineCordinates = GetFirstMineCoordination(game.TileGrid.Grid);
        var mineString = (char)('A' + mineCordinates[0]) + (mineCordinates[1] + 1).ToString();
        fakeReader.PushToQueue(mineString);

        game.Play();

        Assert.That(game.TileGrid.Status, Is.EqualTo(GameStatus.Lose), "Game Should be Lost");
    }

    [Test]
    public void PlayGameBordShouldHadleWinOnAllSafeRevelsSelect()
    {
        const string input = "2";
        const string mines = "1";
        IRandomMinePlacer minePlacer = new RandomMinePlacer();
        var fakeReader = new MockReader(new[] { input, mines });
        var game = new Game(fakeReader, minePlacer);
        game.CreateBoard();
        var mineCordinates = GetFirstMineCoordination(game.TileGrid.Grid);
        var minX = mineCordinates[0];
        var minY = mineCordinates[1];
        if (!(minX == 0 && minY == 0)) fakeReader.PushToQueue("A1");
        if (!(minX == 0 && minY == 1)) fakeReader.PushToQueue("A2");
        if (!(minX == 1 && minY == 0)) fakeReader.PushToQueue("B1");
        if (!(minX == 1 && minY == 1)) fakeReader.PushToQueue("B2");

        game.Play();

        Assert.That(game.TileGrid.Status, Is.EqualTo(GameStatus.Win), "Game Should be Won");
    }

    [Test]
    public void PlayGameBordShouldRevealOnLose()
    {
        const string input = "3";
        const string mines = "1";
        IRandomMinePlacer minePlacer = new RandomMinePlacer();
        var fakeReader = new MockReader(new[] { input, mines });
        var game = new Game(fakeReader, minePlacer);
        game.CreateBoard();
        var mineCordinates = GetFirstMineCoordination(game.TileGrid.Grid);
        var mineString = (char)('A' + mineCordinates[0]) + (mineCordinates[1] + 1).ToString();
        fakeReader.PushToQueue(mineString);

        game.Play();

        StringAssert.DoesNotContain("_", game.TileGrid.DisplayGridString());
    }

    [Test]
    public void PlayGameBordShouldRevealOnWin()
    {
        const string input = "2";
        const string mines = "1";
        IRandomMinePlacer minePlacer = new RandomMinePlacer();
        var fakeReader = new MockReader(new[] { input, mines });
        var game = new Game(fakeReader, minePlacer);
        game.CreateBoard();
        var mineCordinates = GetFirstMineCoordination(game.TileGrid.Grid);
        var minX = mineCordinates[0];
        var minY = mineCordinates[1];
        if (!(minX == 0 && minY == 0)) fakeReader.PushToQueue("A1");
        if (!(minX == 0 && minY == 1)) fakeReader.PushToQueue("A2");
        if (!(minX == 1 && minY == 0)) fakeReader.PushToQueue("B1");
        if (!(minX == 1 && minY == 1)) fakeReader.PushToQueue("B2");

        game.Play();

        StringAssert.DoesNotContain("_", game.TileGrid.DisplayGridString());
    }

    private static int[] GetFirstMineCoordination(Tile[,] grid) {
        for (var row = 0; row < grid.GetLength(0); row++)
            for (var col = 0; col < grid.GetLength(0); col++)
            {
                if (grid[row,col] is MineTile) return new int[] { row, col };
            }

        return new int[] { };
    }
}