namespace AdventOfCode.Day05;

public class Input
{
    public IEnumerable<Line> ParseInput(string input)
    {
        var lines = input
            .Split('\r', '\n')
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select((values, index) => 
            {
                int[] start = values[0].Split(',').Select(int.Parse).ToArray();
                int[] end = values[2].Split(',').Select(int.Parse).ToArray();
                
                return new Line(
                    new Coordinates(start[0], start[1]),
                    new Coordinates(end[0], end[1]));
            });

        return lines;
    }
}
