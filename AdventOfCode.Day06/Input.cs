namespace AdventOfCode.Day06;

public class Input
{
    public IList<int> ParseInput(string input)
    {
        return input
            .Split(',')
            .Select(int.Parse)
            .ToList();
    }
}
