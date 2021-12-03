// Part One

var depths = new List<int>();

// Read the contents of the file into a List<int>. Since we
// know that all of the values will be `int` types, we can use
// `int.Parse/1` instead of `int.TryParse/2`.
foreach (string line in File.ReadLines("input.txt"))
{
    depths.Add(int.Parse(line));
}

int depthIncreaseCount = 0;

// Loop over all of the values, skipping the first value
// since there is not a previous value to compare it to.
// My thinking of skipping the first value and checking
// the index behind the current value we is to avoid having
// to do a bounds check at the end of the array.
for (int i = 0; i < depths.Count; i++)
{
    if (i > 0)
    {
        if (depths[i - 1] < depths[i])
        {
            depthIncreaseCount++;
        }
    }
}

Console.WriteLine("--- Day 1: Part One ---");
Console.WriteLine($"Depth increased {depthIncreaseCount} times");

// Part Two

int groupDepthIncreaseCount = 0;
int? previousGroup = null;

// Loop over all of the values, skipping the first two, so that we can
// sum the three values next to each other. My thinking on skipping the
// first two values is that we can avoid doing a bounds check at the 
// end of the array and just let the loop run to completion.
for (int i = 0; i < depths.Count; i++)
{
    if (i > 1)
    {
        int currentGroup = depths[i - 2] + depths[i - 1] + depths[i];

        if (currentGroup > previousGroup)
        {
            groupDepthIncreaseCount++;
        }

        previousGroup = currentGroup;
    }
}

Console.WriteLine("--- Day 1: Part Two ---");
Console.WriteLine($"Grouped depth increased {groupDepthIncreaseCount} times");