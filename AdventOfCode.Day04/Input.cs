namespace AdventOfCode.Day04;

public class Input
{
    public (IEnumerable<int> Numbers, IList<Board> Boards) ParseInput(string input)
    {
        // Since we know the format of the input file we can 
        // strip out all of the empty lines up front.
        var lines = input
            .Split('\r', '\n')
            .Where(l => !string.IsNullOrEmpty(l))
            .ToList();

        // The first line of the input contains all of the numbers 
        // that will be called during the game.
        var numbers = lines
            .Take(1)
            .SelectMany(numbers =>
                numbers
                    .Split(',')
                    .Select(int.Parse));

        // The remaining lines after the first will be 5-line chunks
        // that each will contain the 5x5 grid of bingo card values.
        var boards = lines
            .Skip(1)
            .Chunk(5)
            .Select(boardLines =>
                new Board(GetSquares(boardLines.ToList())))
            .ToList();

        return (numbers, boards);
    }

    private IList<Square> GetSquares(List<string> input)
    {
        // The squares are separated by a line for each row and by a space
        // for each value within the row.
        return new List<Square>(
            input
                .SelectMany((row, rowIndex) =>
                    row
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select((value, columnIndex) =>
                            new Square(rowIndex, columnIndex, int.Parse(value)))));
    }
}