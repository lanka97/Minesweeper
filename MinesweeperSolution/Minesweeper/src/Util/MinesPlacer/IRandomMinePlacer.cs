namespace Minesweeper.Util.MinesPlacer;

public interface IRandomMinePlacer
{
    public void SetMines(int minesCount, Tile[,] grid);
    public void CalculateNearbyMines(Tile[,] grid);
}