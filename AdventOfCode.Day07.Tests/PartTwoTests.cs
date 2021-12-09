using Xunit;

namespace AdventOfCode.Day07.Tests;

public class PartTwoTests
{
    private readonly string _input = @"16,1,2,0,4,2,7,1,2,14";

    [Fact]
    public void CrabFuelCostIsCalculatedCorrectly()
    {
        IList<int> input = new Input().ParseInput(_input);
        int fuelCost = new PartTwo().CalculateFuelCost(input);
        
        Assert.Equal(168, fuelCost);
    }
}
