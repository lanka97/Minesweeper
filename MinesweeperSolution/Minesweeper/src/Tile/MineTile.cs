namespace Minesweeper;

public class MineTile : Tile
{
    public override char GetCellSymbol()
    {
        return IsRevealed ? 'X' : '_';
    }
}