using Minesweeper.Util.Validators;

namespace Minesweeper.UnitTests;

[TestFixture]
public class CellValidatorTests
{
    [TestCase(0, 0, 5, ExpectedResult = true)]
    [TestCase(2, 3, 4, ExpectedResult = true)]
    [TestCase(5, 5, 6, ExpectedResult = true)]
    [TestCase(6, 6, 6, ExpectedResult = false)]
    [TestCase(-1, 2, 3, ExpectedResult = false)]
    [TestCase(3, -1, 4, ExpectedResult = false)]
    [TestCase(2, 2, 0, ExpectedResult = false)]
    public bool IsValidCell_ShouldReturnExpectedResult(int row, int column, int gridLength)
    {
        var result = CellValidator.IsValidCell(row, column, gridLength);

        return result;
    }
}