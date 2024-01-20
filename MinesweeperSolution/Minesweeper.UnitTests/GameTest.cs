namespace Minesweeper.UnitTests;

internal class GameTest
{
    [Test]
    public void CreateGrid_Create4by4Bored_whenGridSizeIs4()
    {
        const string input = "4";
        const string mines = "4";
        var reader = new MockReader(new[] { input, mines });
        var mineGenarator = new MockRandomMinePlacer();
        var game = new Game(reader, mineGenarator);

        game.CreateBoard();

        Assert.That(game.TileGrid.Grid.GetLength(0), Is.EqualTo(4), "Grid should created with correct length");
    }

    [Test]
    public void CreateGrid_CreateBoardWith4mines_whenCountIs4()
    {
        const string input = "4";
        const string mines = "4";
        var reader = new MockReader(new[] { input, mines });
        var mineGenarator = new MockRandomMinePlacer();
        var game = new Game(reader, mineGenarator);

        game.CreateBoard();

        Assert.That(game.TileGrid.MinesCount, Is.EqualTo(4), "Grid should created with correct length");
    }

    [Test]
    public void CreateGrid_Create4by4Bored_whenGridSize4EnterdAfterInvalidInput()
    {
        const string invalidInput = "1";
        const string validInput = "4";
        const string mines = "4";
        var reader = new MockReader(new[] { invalidInput, validInput, mines });
        var mineGenarator = new MockRandomMinePlacer();
        var game = new Game(reader, mineGenarator);

        game.CreateBoard();

        Assert.That(game.TileGrid.Grid.GetLength(0), Is.EqualTo(4), "Grid should created with correct values");
    }

    [Test]
    public void CreateGrid_Create4by4BoredWith4Mins_whenGridMineSize4EnterdAfterInvalidInput()
    {
        const string validInput = "4";
        const string invalidInput = "100";
        const string mines = "4";
        var reader = new MockReader(new[] { invalidInput, validInput, mines });
        var mineGenarator = new MockRandomMinePlacer();
        var game = new Game(reader, mineGenarator);

        game.CreateBoard();

        Assert.That(game.TileGrid.MinesCount, Is.EqualTo(4), "Grid should created with correct values");
    }

    [Test]
    public void Play_RevealTile_whenUserInputTileLocetion()
    {
        const string gridSize = "4";
        const string mines = "4";
        const string tile = "A1";
        var reader = new MockReader(new[] { gridSize, mines, tile });
        var mineGenarator = new MockRandomMinePlacer();
        var game = new Game(reader, mineGenarator);

        game.CreateBoard();
        game.Play();

        Assert.That(game.TileGrid.Grid[0, 0].IsRevealed, Is.True, "Should reveal enterd tile");
    }

    [Test]
    public void Play_RevealTileShouldWaitForValidCell_whenUserInputTileLocetionAfterInvalid()
    {
        const string gridSize = "4";
        const string mines = "4";
        const string tile = "AA1";
        const string invalidTile = "A1";
        var reader = new MockReader(new[] { gridSize, mines, invalidTile, tile });
        var mineGenerator = new MockRandomMinePlacer();
        var game = new Game(reader, mineGenerator);

        game.CreateBoard();
        game.Play();

        Assert.That(game.TileGrid.Grid[0, 0].IsRevealed, Is.True, "Should reveal valid tile");
    }
}