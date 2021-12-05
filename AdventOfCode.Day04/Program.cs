using AdventOfCode.Day04;

string inputText = File.ReadAllText("input.txt");
(IEnumerable<int> numbers, IList<Board> boards) = new Input().ParseInput(inputText);

PartOne(numbers, boards);
PartTwo(numbers, boards);

static void PartOne(IEnumerable<int> numbers, IList<Board> boards)
{
    (int lastNumberCalled, Board? winningBoard) = new PartOne().PlayBingo(numbers, boards);
    int? unmarkedNumbersSum = winningBoard?.Squares.Where(s => !s.Drawn).Sum(s => s.Value);

    Console.WriteLine("--- Part One ---");
    Console.WriteLine($"Winning board sum of unmarked numbers: {unmarkedNumbersSum}");
    Console.WriteLine($"Last number called: {lastNumberCalled}");
    Console.WriteLine($"Multiplication result: {lastNumberCalled * unmarkedNumbersSum}");
}

static void PartTwo(IEnumerable<int> numbers, IList<Board> boards)
{
    (int lastNumberCalled, Board? lastWinningBoard) = new PartTwo().PlayBingo(numbers, boards);
    int? unmarkedNumbersSum = lastWinningBoard?.Squares.Where(s => !s.Drawn).Sum(s => s.Value);

    Console.WriteLine("--- Part Two ---");
    Console.WriteLine($"Last winning board sum of unmarked numbers: {unmarkedNumbersSum}");
    Console.WriteLine($"Last number called: {lastNumberCalled}");
    Console.WriteLine($"Multiplication result: {lastNumberCalled * unmarkedNumbersSum}");
}