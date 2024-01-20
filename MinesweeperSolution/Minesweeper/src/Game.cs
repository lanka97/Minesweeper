using Minesweeper.Util.GameStatusCheck;
using Minesweeper.Util.MinesPlacer;
using Minesweeper.Util.Prompts;
using Minesweeper.Util.Validators;

namespace Minesweeper;

/*
 * Game class interconnect the user and the tile grid
 */
public class Game
{
    private readonly IRandomMinePlacer _minePlacer;
    private readonly IReader _reader;
    public TileGrid TileGrid { get; private set; }

    public Game(IReader reader, IRandomMinePlacer minePlacer)
    {
        _reader = reader;
        _minePlacer = minePlacer;
        TileGrid = TileGrid.GenerateBoard(0);
    }

    /// <summary>
    /// Creates the game board and sets mines.
    /// </summary>
    public void CreateBoard()
    {
        var bordSize = SetBordSize();
        TileGrid = TileGrid.GenerateBoard(bordSize);
        var minesCount = SetMinesCount(bordSize);
        _minePlacer.SetMines(minesCount, TileGrid.Grid);
        _minePlacer.CalculateNearbyMines(TileGrid.Grid);
    }

    /// <summary>
    /// Gets grid locations and reveals tiles until the game is won or lost.
    /// </summary>
    public void Play()
    {
        var updated = false;
        while (true)
        {
            Console.WriteLine("\n"+ (updated ? "Here is your updated minefield:" : "Here is your minefield:"));
            updated = true;
            Console.WriteLine(TileGrid.DisplayGridString());

            var input = _reader.ReadLine("Select a square to reveal (e.g., A1): ");

            if (input.Length < 2 || !char.IsLetter(input[0]) || !char.IsDigit(input[1]))
            {
                Console.WriteLine("Incorrect input. Please enter a valid square (e.g., A1).");
                continue;
            }

            var row = input[0] - 'A';
            var col = input[1] - '1';

            if (!CellValidator.IsValidCell(row, col, TileGrid.Grid.GetLength(0)))
            {
                Console.WriteLine("Incorrect input. Please enter a valid square (e.g., A1).");
                continue;
            }

            if (GameStatusChecker.CheckLose(TileGrid.Grid[row, col]))
            {
                TileGrid.SetAllRevealed(false);

                Console.WriteLine("\nDetonated Board:");
                Console.WriteLine(TileGrid.DisplayGridString());
                Console.WriteLine("Oh no, you detonated a mine! Game over.");
                return;
            }

            RevealTile(row, col, true);

            if (!GameStatusChecker.CheckWin(TileGrid.Grid)) continue;
            TileGrid.SetAllRevealed(true);
            Console.WriteLine("\nWinning Board:");
            Console.WriteLine(TileGrid.DisplayGridString());
            Console.WriteLine("Congratulations, you have won the game!");
            return;
        }
    }

    /// <summary>
    /// Checks if the tile is valid and reveals the appropriate character.
    /// </summary>
    private void RevealTile(int row, int col, bool isSelected)
    {
        if (!CellValidator.IsValidCell(row, col, TileGrid.Grid.GetLength(0))) return;

        if (TileGrid.Grid[row, col].IsRevealed) { if (isSelected) Console.WriteLine("This square is already selected"); return; }

        if (TileGrid.Grid[row, col] is NormalTile normalTile)
        {
            TileGrid.Grid[row, col].IsRevealed = true;
            if (isSelected) Console.WriteLine($"This square contains {normalTile.AdjacentMinesCount} adjacent mines.");

            TileGrid.Grid[row, col].IsRevealed = true;

            if (normalTile.AdjacentMinesCount != 0) return;
        }

        // Auto-reveal adjacent cells
        for (var i = row - 1; i <= row + 1; i++)
            for (var j = col - 1; j <= col + 1; j++)
                RevealTile(i, j, false);
    }

    /// <summary>
    /// Reads, validates, and returns the board size.
    /// </summary>
    private int SetBordSize()
    {
        int boardSize;
        do
        {
            var boardSizeStr = _reader.ReadLine("Enter the size of the grid (e.g. 4 for a 4x4 grid):");

            if (!int.TryParse(boardSizeStr, out boardSize) || boardSize < 2 || boardSize > 26)
            {
                Console.WriteLine("Invalid input. Please enter a number between 2 and 26.");
            }
        } while (boardSize is < 2 or > 26);

        return boardSize;
    }

    /// <summary>
    /// Reads, validates, and returns the mine count.
    /// </summary>
    private int SetMinesCount(int boardSize)
    {
        int minesCount;
        var maxMines = (int)(boardSize * boardSize * 0.35); // Maximum mines (35% of total cells)

        do
        {
            var minesCountStr = _reader.ReadLine($"Enter the number of mines to place on the board (maximum is {maxMines}): ");

            if (!int.TryParse(minesCountStr, out minesCount) || minesCount <= 0 || minesCount > maxMines)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {maxMines}.");
            }
        } while (minesCount <= 0 || minesCount > maxMines);

        TileGrid.MinesCount = minesCount;
        return minesCount;
    }
}