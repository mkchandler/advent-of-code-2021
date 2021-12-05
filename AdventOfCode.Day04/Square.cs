namespace AdventOfCode.Day04;

public class Square
{
    public Square(int row, int column, int value)
    {
        Row = row;
        Column = column;
        Value = value;
        Drawn = false;
    }

    public int Row { get; }

    public int Column { get; }

    public int Value { get; }

    public bool Drawn { get; set; }
}
