namespace Minesweeper.Util.Validators;

/*
 * The CellValidator class provides utility methods for validating cell positions on the game board.
 * The IsValidCell method checks if a given row and column are within the bounds of the specified grid length.
 */
public static class CellValidator
{
    // Method to check if a cell position is valid within the game board
    public static bool IsValidCell(int row, int column, int gridLength)
    {
        return gridLength > 0 && row >= 0 && row < gridLength && column >= 0 && column < gridLength;
    }
}