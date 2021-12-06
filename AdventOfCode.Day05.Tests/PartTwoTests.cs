using Xunit;

namespace AdventOfCode.Day05.Tests;

public class PartTwoTests
{
    private readonly string _input =
        @"0,9 -> 5,9
         8,0 -> 0,8
         9,4 -> 3,4
         2,2 -> 2,1
         7,0 -> 7,4
         6,4 -> 2,0
         0,9 -> 2,9
         3,4 -> 1,4
         0,0 -> 8,8
         5,5 -> 8,2";

    [Fact]
    public void InputReturnsAllLines()
    {
        IEnumerable<Line> lines = new Input().ParseInput(_input);

        Assert.Equal(10, lines.Count());
    }

    [Fact]
    public void LinesReturnCorrectOverlapCount()
    {
        IEnumerable<Line> lines = new Input().ParseInput(_input);
        int overlapCount = new PartTwo().GetOverlapCount(lines);

        Assert.Equal(12, overlapCount);
    }
}
