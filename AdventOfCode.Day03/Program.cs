// Part One

var diagnostics = new List<string>();

// Read the contents of the file into a List<string>. For now
// I am just storing each binary value as a string.
foreach (string line in File.ReadLines("input.txt"))
{
    diagnostics.Add(line);
}

int bits = diagnostics.First().Length;
char[] gammaRateBits = new char[bits];
char[] epsilonRateBits = new char[bits];

// Loop through all of the diagnostics inside of a loop that
// will look at the first bit of everything, then the second bit
// of everything, etc. This is a horribly inefficient way of 
// doing this.
for (int i = 0; i < bits; i++)
{
    int lowBitCount = diagnostics.Count(d => d[i] == '0');
    int highBitCount = diagnostics.Count - lowBitCount;
    
    gammaRateBits[i] = lowBitCount > highBitCount ? '0' : '1';
    epsilonRateBits[i] = lowBitCount > highBitCount ? '1' : '0';
}

// Convert the string representation of the binary to number to a base 2 integer.
int gammaRate = Convert.ToInt32(new string(gammaRateBits), 2);
int epsilonRate = Convert.ToInt32(new string(epsilonRateBits), 2);
int powerConsumption = gammaRate * epsilonRate;

Console.WriteLine("--- Day 3: Part One ---");
Console.WriteLine($"Gamma rate: {gammaRate}");
Console.WriteLine($"Epsilon rate: {epsilonRate}");
Console.WriteLine($"Power consumption: {powerConsumption}");

// Part Two

List<string> oxygenGeneratorDiagnostics = new(diagnostics);
List<string> co2ScrubberDiagnostics = new(diagnostics);

for (int i = 0; i < bits; i++)
{
    List<string> lowBitOxygenDiagnostics = oxygenGeneratorDiagnostics.Where(d => d[i] == '0').ToList();
    List<string> highBitOxygenDiagnostics = oxygenGeneratorDiagnostics.Where(d => d[i] == '1').ToList();
    List<string> lowBitCo2Diagnostics = co2ScrubberDiagnostics.Where(d => d[i] == '0').ToList();
    List<string> highBitCo2Diagnostics = co2ScrubberDiagnostics.Where(d => d[i] == '1').ToList();
    
    // If we only have one item left in a collection, that means we are done
    // searching through those particular diagnostics. There may still be additional
    // bits that need to be searched in the other collection though.
    if (oxygenGeneratorDiagnostics.Count > 1)
    {
        // We need to narrow down the list of diagnostics as we iterate over each 
        // bit. This will clear the list and add only the narrowed down list found
        // during this iteration.
        oxygenGeneratorDiagnostics.Clear();

        oxygenGeneratorDiagnostics.AddRange(lowBitOxygenDiagnostics.Count > highBitOxygenDiagnostics.Count
            ? lowBitOxygenDiagnostics
            : highBitOxygenDiagnostics);
    }

    // Do the same thing as above but for the CO2 scrubber diagnostics.
    if (co2ScrubberDiagnostics.Count > 1)
    {
        co2ScrubberDiagnostics.Clear();

        co2ScrubberDiagnostics.AddRange(lowBitCo2Diagnostics.Count > highBitCo2Diagnostics.Count
            ? highBitCo2Diagnostics
            : lowBitCo2Diagnostics);
    }
}

// Convert the string representation of the binary to number to a base 2 integer.
int oxygenGeneratorRating = Convert.ToInt32(oxygenGeneratorDiagnostics.First(), 2);
int co2ScrubberRating = Convert.ToInt32(co2ScrubberDiagnostics.First(), 2);
int lifeSupportRating = oxygenGeneratorRating * co2ScrubberRating;

Console.WriteLine("--- Day 3: Part Two ---");
Console.WriteLine($"Oxygen generator rating: {oxygenGeneratorRating}");
Console.WriteLine($"CO2 scrubber rating: {co2ScrubberRating}");
Console.WriteLine($"Life support rating: {lifeSupportRating}");
