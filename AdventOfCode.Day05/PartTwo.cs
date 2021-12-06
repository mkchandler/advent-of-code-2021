namespace AdventOfCode.Day05;

public class PartTwo
{
    public int GetOverlapCount(IEnumerable<Line> lines)
    {
        var overlappingLines = lines
            .Select(GetAllLinePoints)
            .Where(c => c.Any())
            .SelectMany(c => c.ToList())
            .GroupBy(c => new {c.X, c.Y})
            .Where(g => g.Count() > 1)
            .ToList();

        return overlappingLines.Count;
    }

    // I'm not happy with this function at all, but I'm not very 
    // familiar yet with coordinate and line logic. I'm sure there
    // is a much better way to do this and I will continue to research.
    private IEnumerable<Coordinates> GetAllLinePoints(Line line)
    {
        var coordinates = new List<Coordinates>();

        if (line.Start.X == line.End.X)
        {
            int minY = Math.Min(line.Start.Y, line.End.Y);
            int maxY = Math.Max(line.Start.Y, line.End.Y);

            for (int i = minY; i <= maxY; i++)
            {
                coordinates.Add(new Coordinates(line.Start.X, i));
            }
        }
        else if (line.Start.Y == line.End.Y)
        {
            int minX = Math.Min(line.Start.X, line.End.X);
            int maxX = Math.Max(line.Start.X, line.End.X);

            for (int i = minX; i <= maxX; i++)
            {
                coordinates.Add(new Coordinates(i, line.Start.Y));
            }
        }
        else
        {
            if (line.Start.X < line.End.X)
            {
                int y = line.Start.Y;

                for (int x = line.Start.X; x <= line.End.X; x++)
                {
                    if (y < line.End.Y)
                    {
                        coordinates.Add(new Coordinates(x, y));
                        y++;
                    }
                    else
                    {
                        coordinates.Add(new Coordinates(x, y));
                        y--;
                    }
                }
            }
            else
            {
                int y = line.Start.Y;

                for (int x = line.Start.X; x >= line.End.X; x--)
                {
                    if (y < line.End.Y)
                    {
                        coordinates.Add(new Coordinates(x, y));
                        y++;
                    }
                    else
                    {
                        coordinates.Add(new Coordinates(x, y));
                        y--;
                    }
                }
            }
        }

        return coordinates;
    }
}
