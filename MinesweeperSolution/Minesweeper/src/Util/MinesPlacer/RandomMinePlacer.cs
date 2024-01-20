using Minesweeper.Util.Validators;

/*
 * RandomMinePlacer implements IRandomMinePlacer for random mine placement in Minesweeper.
 * It ensures proper mine placement and calculates nearby mine counts for each tile, promoting
 * code modularity and flexibility. Different mine placement strategies can be easily swapped
 * by implementing this interface, and it facilitates testability by providing a clear boundary
 * for mine placement functionality.
 */
namespace Minesweeper.Util.MinesPlacer;

public class RandomMinePlacer : IRandomMinePlacer
{
    /// <summary>
    /// Sets mines on the game board.
    /// </summary>
    /// <param name="minesCount">The number of mines to be set on the board.</param>
    /// <param name="tileGrid">The 2D array representing the game board with tiles.</param>
    public void SetMines(int minesCount, Tile[,] tileGrid)
    {
        var random = new Random();

        while (minesCount > 0)
        {
            var row = random.Next(tileGrid.GetLength(0));
            var col = random.Next(tileGrid.GetLength(0));

            if (tileGrid[row, col] is MineTile) continue;
            tileGrid[row, col] = new MineTile();
            minesCount--;
        }
    }

    /// <summary>
    /// Calculates and sets the number of nearby mines for each non-mine tile on the game board.
    /// </summary>
    /// <param name="tileGrid">The 2D array representing the game board with tiles.</param>
    public void CalculateNearbyMines(Tile[,] tileGrid)
    {
        var gridLength = tileGrid.GetLength(0);
        for (var row = 0; row < gridLength; row++)
        for (var col = 0; col < gridLength; col++)
            if (tileGrid[row, col] is NormalTile normalTile)
            {
                var count = CountNearbyMines(row, col, tileGrid);
                normalTile.AdjacentMinesCount = count;
            }
    }

    /// <summary>
    /// Counts the number of nearby mines for a specific tile on the game board.
    /// </summary>
    /// <param name="row">The row index of the tile.</param>
    /// <param name="col">The column index of the tile.</param>
    /// <param name="grid">The 2D array representing the game board with tiles.</param>
    /// <returns>The number of nearby mines for the specified tile.</returns>
    private static int CountNearbyMines(int row, int col, Tile[,] grid)
    {
        var mineCount = 0;

        for (var i = row - 1; i <= row + 1; i++)
        for (var j = col - 1; j <= col + 1; j++)
            if (grid != null && CellValidator.IsValidCell(i, j, grid.GetLength(0)) &&
                grid[i, j] is MineTile)
                mineCount++;

        return mineCount;
    }
}