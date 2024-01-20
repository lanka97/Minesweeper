using Minesweeper.Util.MinesPlacer;
using Minesweeper.Util.Prompts;

namespace Minesweeper;

public static class ConsoleUi
{
    /// <summary>
    /// Entry point to the Minesweeper game. Runs in an infinite loop until the user chooses to exit.
    /// </summary>
    public static void Start()
    {
        Console.WriteLine("Hello! Welcome to Minesweeper!\n");

        char exitChar;

        do
        {
            var inputReader = new Reader();
            var minePlacer = new RandomMinePlacer();
            var game = new Game(inputReader, minePlacer);

            game.CreateBoard();
            game.Play();

            Console.WriteLine("Press 'q' to exit or press any key to restart...");
            var keyInfo = Console.ReadKey();

            exitChar = keyInfo.KeyChar;

            Console.WriteLine("\n");
        } while (!Equals(exitChar, 'q'));
    }
}