namespace Minesweeper;

// class Representing a single Normal cell in the grid
public class NormalTile : Tile
{
    public int AdjacentMinesCount { get; set; } = 0;

    public override char GetCellSymbol()
    {
        return IsRevealed ? AdjacentMinesCount.ToString()[0] : '_';
    }
}