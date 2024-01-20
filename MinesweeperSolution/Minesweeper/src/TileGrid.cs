namespace Minesweeper;

/*
 * The TileGrid class represents the game board in its entirety.
 * It adheres to the Singleton design pattern, ensuring a single instance
 * of the game board (mineGrid) is accessible throughout the entire game,
 * ensuring a single shared instance of the board for consistent game state and actions.
 */
public class TileGrid
{
    // Private constructor to enforce Singleton pattern
    private TileGrid(int length)
    {
        Status = GameStatus.Pending;
        GridSize = length;
        Grid = CreateTiles();
    }

    // 2D array to represent the game board
    public Tile[,] Grid { get; }

    // Holds Mines count in the grid
    public int MinesCount { get; set; }
    public int GridSize { get; }
    public GameStatus Status = GameStatus.Pending;


    /// <summary>
    /// Creates and initializes tiles for the game board.
    /// </summary>
    /// <returns>A 2D array of tiles representing the initialized game board.</returns>
    private Tile[,] CreateTiles()
    {
        var grid = new Tile[GridSize, GridSize];
        for (var row = 0; row < GridSize; row++)
        for (var col = 0; col < GridSize; col++)
            grid[row, col] = new NormalTile();
        return grid;
    }

    /// <summary>
    /// Generates a new game board with the specified length.
    /// </summary>
    /// <param name="length">The length of one side of the square game board.</param>
    /// <returns>A TileGrid representing the new game board.</returns>
    public static TileGrid GenerateBoard(int length)
    {
        return new TileGrid(length);
    }

    /// <summary>
    /// Prints the current state of the game board.
    /// </summary>
    /// <returns>A string representing the current state of the game board.</returns>
    public string DisplayGridString()
    {
        var printMsg = "  " + string.Join(" ", GetColumnLabels()) + "\n";
        for (var row = 0; row < GridSize; row++)
        {
            printMsg += (char)('A' + row) + " ";
            for (var col = 0; col < GridSize; col++)
            {
                var cellSymbol = Grid[row, col].GetCellSymbol();
                printMsg += cellSymbol + " ";
            }

            printMsg += "\n";
        }

        return printMsg;
    }

    /// <summary>
    /// Reveals the whole mine grid, making all tiles visible.
    /// </summary>
    public void SetAllRevealed(bool isWin)
    {
        Status = isWin ? GameStatus.Win : GameStatus.Lose;
        for (var row = 0; row < GridSize; row++)
        for (var col = 0; col < GridSize; col++)
            Grid[row, col].IsRevealed = true;
    }

    /// <summary>
    /// Gets column labels (numeric labels) for the game board.
    /// </summary>
    /// <returns>An array of strings representing numeric labels for each column.</returns>
    private string[] GetColumnLabels()
    {
        var labels = new string[GridSize];
        for (var i = 0; i < GridSize; i++) labels[i] = (i + 1).ToString();
        return labels;
    }
}