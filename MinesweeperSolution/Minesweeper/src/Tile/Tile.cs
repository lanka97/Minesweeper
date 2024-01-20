namespace Minesweeper;

// class Representing a single cell in the grid
public abstract class Tile
{
    public bool IsRevealed { get; set; } = false;

    public abstract char GetCellSymbol();
}