namespace Minesweeper.Util.GameStatusCheck;

/*
 * The GameStatusChecker class provides utility methods for
 * checking the game status of the mine field.
 */
public static class GameStatusChecker
{
    /// <summary>
    /// Method to check if the player has won the game
    /// </summary>
    /// <param name="tileGrid"></param>
    /// <returns>
    /// <c>true</c> if the player has won by revealing all non-mine tiles; otherwise, <c>false</c>.
    /// </returns>
    public static bool CheckWin(Tile[,] tileGrid)
    {
        // Count unrevealed tiles that are not mines
        var unrevealedCount = tileGrid.Cast<Tile>().Count(tile => !tile.IsRevealed && tile is NormalTile);

        // Player wins if all non-mine tiles are revealed
        return unrevealedCount == 0;
    }

    /// <summary>
    /// Checks if the player has lost the game by determining if the specified tile is a mine.
    /// </summary>
    /// <param name="tile">The tile to be checked for being a mine.</param>
    /// <returns>
    ///     <c>true</c> if the specified tile is a mine, indicating that the player has lost; otherwise, <c>false</c>.
    /// </returns>
    public static bool CheckLose(Tile tile)
    {
        // Check if user revealed a mine
        return tile is MineTile;
    }
}