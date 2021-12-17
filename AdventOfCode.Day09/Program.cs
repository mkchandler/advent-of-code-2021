string sampleInputText =
    @"2199943210
      3987894921
      9856789892
      8767896789
      9899965678";

string inputText = File.ReadAllText("input.txt");

var input = inputText
    .Split('\r', '\n')
    .Select(l => l.Trim().ToCharArray())
    .Select(c => c.Select(s => s - '0').ToList())
    .ToList();

// Part One
List<int> lowPoints = new();

for (int row = 0; row < input.Count; row++)
{
    var rowValues = input[row];

    for (int col = 0; col < rowValues.Count; col++)
    {
        int colValue = rowValues[col];
        int top = (row - 1 != -1) ? input[row - 1][col] : colValue + 1;
        int bottom = (row + 1 < input.Count) ? input[row + 1][col] : colValue + 1;
        int left = (col - 1 != -1) ? input[row][col - 1] : colValue + 1;
        int right = (col + 1 < rowValues.Count) ? input[row][col + 1] : colValue + 1;

        if (colValue < top && colValue < bottom && colValue < left && colValue < right)
        {
            lowPoints.Add(colValue);
        }
    }
}

int lowPointsSum = lowPoints.Aggregate(0, (total, next) => total + (next + 1));

Console.WriteLine("--- Part One ---");
Console.WriteLine($"Sum of low points: {lowPointsSum}");

// Part Two

List<(int Value, int X, int Y)> lowPoints2 = new();

for (int row = 0; row < input.Count; row++)
{
    var rowValues = input[row];

    for (int col = 0; col < rowValues.Count; col++)
    {
        int colValue = rowValues[col];
        int top = (row - 1 != -1) ? input[row - 1][col] : colValue + 1;
        int bottom = (row + 1 < input.Count) ? input[row + 1][col] : colValue + 1;
        int left = (col - 1 != -1) ? input[row][col - 1] : colValue + 1;
        int right = (col + 1 < rowValues.Count) ? input[row][col + 1] : colValue + 1;

        if (colValue < top && colValue < bottom && colValue < left && colValue < right)
        {
            // Need to get all values for the basin
            lowPoints2.Add((colValue, row, col));
        }
    }
}

List<List<(int, int, int)>> basins = new();

foreach (var (value, x, y) in lowPoints2)
{
    var basin = new List<(int, int, int)>();
    basins.Add(GetBasin(basin, input[x], x, y));
}

var largestBasins = basins.OrderByDescending(b => b.Count).Take(3);
int multipliedSizes = largestBasins.Aggregate(1, (total, i) => total * i.Count);

Console.WriteLine("--- Part Two ---");
Console.WriteLine($"Multiplied sizes of largest 3 basins: {multipliedSizes}");

List<(int, int, int)> GetBasin(List<(int, int, int)> basin, List<int> rowValues, int row, int col)
{
    int colValue = rowValues[col];

    if (!basin.Contains((colValue, row, col)))
    {
        basin.Add((colValue, row, col));
        int? top = row - 1 != -1 && !basin.Contains((input[row - 1][col], row - 1, col)) ? input[row - 1][col] : null;
        int? bottom = row + 1 < input.Count && !basin.Contains((input[row + 1][col], row + 1, col))
            ? input[row + 1][col]
            : null;
        int? left = col - 1 != -1 && !basin.Contains((input[row][col - 1], row, col - 1)) ? input[row][col - 1] : null;
        int? right = col + 1 < rowValues.Count && !basin.Contains((input[row][col + 1], row, col + 1))
            ? input[row][col + 1]
            : null;

        if (top < 9)
        {
            GetBasin(basin, input[row - 1], row - 1, col);
        }

        if (bottom < 9)
        {
            GetBasin(basin, input[row + 1], row + 1, col);
        }

        if (left < 9)
        {
            GetBasin(basin, input[row], row, col - 1);
        }

        if (right < 9)
        {
            GetBasin(basin, input[row], row, col + 1);
        }
    }

    return basin;
}
