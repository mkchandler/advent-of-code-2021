namespace AdventOfCode.Day04;

public class PartOne
{
    public (int LastNumberCalled, Board? WinningBoard) PlayBingo(IEnumerable<int> numbers, IList<Board> boards)
    {
        foreach (int number in numbers)
        {
            foreach (Board board in boards)
            {
                foreach (Square square in board.Squares)
                {
                    if (square.Value == number)
                    {
                        square.Drawn = true;
                    }
                }

                if (CheckForWinningBoard(board))
                {
                    return (number, board);
                }
            }
        }

        return new ValueTuple<int, Board?>(default, default);
    }

    private static bool CheckForWinningBoard(Board board)
    {
        var winningSquares = board.Squares.Where(s => s.Drawn).ToList();

        if (winningSquares.Any())
        {
            // Group the winning squares by row and column. If we have 5 winning 
            // squares for a single row or column, then we have a winning board.
            var rows = winningSquares
                .GroupBy(s => s.Row)
                .Select(g => g.Count());

            var columns = winningSquares
                .GroupBy(s => s.Column)
                .Select(g => g.Count());

            return rows.Any(g => g == 5) || columns.Any(g => g == 5);
        }

        return false;
    }
}