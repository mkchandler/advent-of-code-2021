using AdventOfCode.Day06;

string inputText = File.ReadAllText("input.txt");
IList<int> input = new Input().ParseInput(inputText);

PartOne(input.ToList());
PartTwo(input.ToList());

static void PartOne(IList<int> input)
{
    int count = new PartOne().CountLanternfishForDays(input, 80);

    Console.WriteLine("--- Part One ---");
    Console.WriteLine($"Lanternfish count after 80 days: {count}");
}

static void PartTwo(IList<int> input)
{
    long count = new PartTwo().CountLanternfishForDays(input, 256);

    Console.WriteLine("--- Part Two ---");
    Console.WriteLine($"Lanternfish count after 256 days: {count}");
}
