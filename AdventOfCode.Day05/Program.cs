using AdventOfCode.Day05;

string inputText = File.ReadAllText("input.txt");
IEnumerable<Line> lines = new Input().ParseInput(inputText).ToList();

PartOne(lines);
PartTwo(lines);

static void PartOne(IEnumerable<Line> lines)
{
    int overlapCount = new PartOne().GetOverlapCount(lines);

    Console.WriteLine("--- Part One ---");
    Console.WriteLine($"Overlap count: {overlapCount}");
}

static void PartTwo(IEnumerable<Line> lines)
{
    int overlapCount = new PartTwo().GetOverlapCount(lines);

    Console.WriteLine("--- Part Two ---");
    Console.WriteLine($"Overlap count: {overlapCount}");
}
