using Xunit;

namespace AdventOfCode.Day06.Tests;

public class PartTwoTests
{
    private readonly string _input = @"3,4,3,1,2";

    [Fact]
    public void InputParsedAsNumbers()
    {
        IEnumerable<int> input = new Input().ParseInput(_input);
        
        Assert.Equal(5, input.Count());
    }
    
    [Fact]
    public void LanternfishCountedCorrectlyForSpecifiedDays()
    {
        IList<int> input = new Input().ParseInput(_input);
        long count = new PartTwo().CountLanternfishForDays(input, 256);
        
        Assert.Equal(26_984_457_539, count);
    }
}
