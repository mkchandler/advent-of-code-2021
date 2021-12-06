namespace AdventOfCode.Day05;

public class Line
{
    public Line(Coordinates start, Coordinates end)
    {
        Start = start;
        End = end;
    }

    public Coordinates Start { get; }

    public Coordinates End { get; }
}
