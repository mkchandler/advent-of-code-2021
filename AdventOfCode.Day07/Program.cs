using AdventOfCode.Day07;

string inputText = File.ReadAllText("input.txt");
IList<int> input = new Input().ParseInput(inputText);

PartOne(input.ToList());
PartTwo(input.ToList());

static void PartOne(IList<int> input)
{
    int fuelCost = new PartOne().CalculateFuelCost(input);

    Console.WriteLine("--- Part One ---");
    Console.WriteLine($"Fuel cost: {fuelCost}");
}

static void PartTwo(IList<int> input)
{
    int fuelCost = new PartTwo().CalculateFuelCost(input);

    Console.WriteLine("--- Part Two ---");
    Console.WriteLine($"Fuel cost: {fuelCost}");
}
