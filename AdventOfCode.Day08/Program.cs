string sampleInputText =
    @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
    edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
    fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
    fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
    aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
    fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
    dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
    bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
    egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
    gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";

string inputText = File.ReadAllText("input.txt");

var input = inputText
    .Split('\r', '\n')
    .Select(line => line.Split('|', StringSplitOptions.TrimEntries))
    .Select(values =>
        new ValueTuple<string[], string[]>(
            values[0].Split(' '),
            values[1].Split(' ')));

// Part One

int uniqueInstances = 0;

foreach ((string[] _, string[] outputValues) in input)
{
    foreach (string outputValue in outputValues)
    {
        switch (outputValue.Length)
        {
            case 2:
            case 3:
            case 4:
            case 7:
                uniqueInstances++;
                break;
        }
    }
}

Console.WriteLine("--- Part One ---");
Console.WriteLine($"Unique value appearances: {uniqueInstances}");

// Part Two

int outputValuesSum = 0;

foreach ((string[] segments, string[] output) in input)
{
    string values = "";

    foreach (string value in output)
    {
        int valueLength = value.Length;
        var twoLengthSegment = segments.FirstOrDefault(s => s.Length == 2);
        var fourLengthSegment = segments.FirstOrDefault(s => s.Length == 4);
        
        // This will find all of the common digits in common with "1"
        int? twoLengthMask = twoLengthSegment == null
            ? null
            : value.ToCharArray()
                .Intersect(twoLengthSegment.ToCharArray())
                .Count();
        
        // This will find all of the common digits in common with "4"
        int? fourLengthMask = fourLengthSegment == null
            ? null
            : value.ToCharArray()
                .Intersect(fourLengthSegment.ToCharArray())
                .Count();

        // By using the length of the current output value with a combination of the 
        // common digits it has with a known digit (1 and 4), we can determine the 
        // actual digit of the current output value.
        switch (valueLength)
        {
            case 2:
                values += "1";
                break;
            case 3:
                values += "7";
                break;
            case 4:
                values += "4";
                break;
            case 7:
                values += "8";
                break;
            case 5:
                switch (fourLengthMask)
                {
                    case 2:
                        values += "2";
                        break;
                    case 3:
                        switch (twoLengthMask)
                        {
                            case 1:
                                values += "5";
                                break;
                            case 2:
                                values += "3";
                                break;
                        }

                        break;
                }

                break;
            case 6:
                switch (fourLengthMask)
                {
                    case 4:
                        values += "9";
                        break;
                    case 3:
                        switch (twoLengthMask)
                        {
                            case 1:
                                values += "6";
                                break;
                            case 2:
                                values += "0";
                                break;
                        }

                        break;
                }

                break;
        }
    }

    outputValuesSum += int.Parse(values);
}

Console.WriteLine("--- Part Two ---");
Console.WriteLine($"Output values sum: {outputValuesSum}");
