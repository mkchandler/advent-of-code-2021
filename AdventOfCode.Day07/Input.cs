namespace AdventOfCode.Day07;

public class Input
{
    public IList<int> ParseInput(string inputText)
    {
        return inputText
            .Split(',')
            .Select(int.Parse)
            .ToList();
    }
}
