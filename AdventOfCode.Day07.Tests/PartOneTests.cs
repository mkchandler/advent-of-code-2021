using Xunit;

namespace AdventOfCode.Day07.Tests;

public class PartOneTests
{
    private readonly string _input = @"16,1,2,0,4,2,7,1,2,14";

    [Fact]
    public void InputParsedAsNumbers()
    {
        IEnumerable<int> input = new Input().ParseInput(_input);

        Assert.Equal(10, input.Count());
    }

    [Fact]
    public void CrabFuelCostIsCalculatedCorrectly()
    {
        IList<int> input = new Input().ParseInput(_input);
        int fuelCost = new PartOne().CalculateFuelCost(input);
        
        Assert.Equal(37, fuelCost);
    }
}
