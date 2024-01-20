namespace Minesweeper.UnitTests;

public class NormalTileTest
{
    private NormalTile _tile = new();

    [SetUp]
    public void TestInit()
    {
        _tile = new NormalTile();
    }

    [Test]
    public void DefaultTile_AdjacentMinesCount_InitializedCorrectly()
    {
        const int initMinesCount = 0;

        Assert.That(_tile.AdjacentMinesCount, Is.EqualTo(initMinesCount), "By default, AdjacentMinesCount should be 0");
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
    public void SetAdjacentMinesCount_PropertyIsSetCorrectly()
    {
        _tile.AdjacentMinesCount = 1;

        Assert.That(_tile.AdjacentMinesCount, Is.EqualTo(1), "AdjacentMinesCount property should be set to 1");
    }

    [Test]
    public void GetCellSymbol_ReturnBlank_WhenRevealFalse()
    {
        _tile.IsRevealed = false;
        var symbol = _tile.GetCellSymbol();

        Assert.That(symbol, Is.EqualTo('_'), "GetCellSymbol should return '_' when IsRevealed false");
    }

    [Test]
    public void GetCellSymbol_ReturnAdjacentMinesCount_WhenRevealTrue()
    {
        _tile.AdjacentMinesCount = 1;
        _tile.IsRevealed = true;
        var symbol = _tile.GetCellSymbol();

        Assert.That(symbol, Is.EqualTo('1'), "GetCellSymbol should return 'AdjacentMinesCount' when IsRevealed true");
    }
}