namespace AdventOfCode.Day04;

public class Board
{
    public Board(IList<Square> squares)
    {
        WinningBoard = false;
        Squares = squares;
    }
    
    public bool WinningBoard { get; set; }

    public IList<Square> Squares { get; }
}
