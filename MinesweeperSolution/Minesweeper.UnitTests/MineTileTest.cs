namespace Minesweeper.UnitTests;

internal class MineTileTest
{
    private MineTile _tile = new();

    [SetUp]
    public void TestInit()
    {
        _tile = new MineTile();
    }


    [Test]
    public void DefaultTile_IsRevealed_InitializedCorrectly()
    {
        Assert.That(_tile.IsRevealed, Is.False, "By default, IsMine should be false");
    }

    [Test]
    public void SetIsRevealed_PropertyIsSetCorrectly()
    {
        _tile.IsRevealed = true;

        Assert.That(_tile.IsRevealed, Is.True, "IsRevealed property should be set to true.");
    }

    [Test]
    public void GetCellSymbol_ReturnBlank_WhenRevealFalse()
    {
        _tile.IsRevealed = false;
        var symbol = _tile.GetCellSymbol();

        Assert.That(symbol, Is.EqualTo('_'), "GetCellSymbol should return '_' when IsRevealed false");
    }

    [Test]
    public void GetCellSymbol_ReturnX_WhenRevealTrue()
    {
        _tile.IsRevealed = true;
        var symbol = _tile.GetCellSymbol();

        Assert.That(symbol, Is.EqualTo('X'), "GetCellSymbol should return 'X' when IsRevealed true");
    }
}