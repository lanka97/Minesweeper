namespace Minesweeper.Util.Prompts;

/*
 * The Reader class implements the IReader interface for handling user input prompts.
 * It utilizes the Console.ReadLine method to read user input and converts it to uppercase.
 */
public class Reader : IReader
{
    /// <summary>
    /// Reads a line from the console with the specified prompt.
    /// </summary>
    /// <param name="prompt">The prompt to be displayed before reading the input.</param>
    /// <returns>
    ///     The entered line converted to uppercase or an empty string if the input is null.
    /// </returns>
    public string ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.ToUpper() ?? "";
    }
}