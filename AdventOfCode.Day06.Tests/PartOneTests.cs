using Xunit;

namespace AdventOfCode.Day06.Tests;

public class PartOneTests
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
        int count = new PartOne().CountLanternfishForDays(input, 80);
        
        Assert.Equal(5_934, count);
    }
}
