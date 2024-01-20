using Minesweeper.Util.Prompts;

namespace Minesweeper.UnitTests;

public class MockReader : IReader
{
    private readonly Queue<string> _responseSet = new();

    public MockReader(IEnumerable<string> responseSet)
    {
        foreach (var response in responseSet) _responseSet.Enqueue(response);
    }

    public string ReadLine(string prompt)
    {
        var response = _responseSet.Dequeue();
        return response;
    }
}