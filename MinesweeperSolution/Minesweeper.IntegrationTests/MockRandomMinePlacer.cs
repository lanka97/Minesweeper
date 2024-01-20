using Minesweeper.Util.MinesPlacer;

namespace Minesweeper.IntegrationTests;

internal class MockRandomMinePlacer : IRandomMinePlacer
{
    public void CalculateNearbyMines(Tile[,] grid)
    {
    }

    public void SetMines(int minesCount, Tile[,] grid)
    {
        for (var row = 0; row < grid.GetLength(0); row++)
        for (var col = 0; col < grid.GetLength(0); col++)
        {
            if (minesCount <= 0) return;
                grid[row, col] = new MineTile();
            minesCount--;
        }
    }
}