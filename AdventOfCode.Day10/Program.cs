string sampleInputText =
    @"[({(<(())[]>[[{[]{<()<>>
      [(()[<>])]({[<{<<[]>>(
      {([(<{}[<>[]}>{[]{[(<()>
      (((({<>}<{<{<>}{[]{[]{}
      [[<[([]))<([[{}[[()]]]
      [{[{({}]{}}([{[{{{}}([]
      {<[[]]>}<{[{[{[]{()[[[]
      [<(<(<(<{}))><([]([]()
      <{([([[(<>()){}]>(<<{{
      <{([{{}}[<[[[<>{}]]]>[]]";

string inputText = File.ReadAllText("input.txt");

List<List<char>> subsystem = sampleInputText
    .Split('\r', '\n')
    .Select(l => l.Trim())
    .Select(l => new List<char>(l.ToCharArray()))
    .ToList();

// Part One

char[] validOpenCharacters = {'(', '{', '[', '<'};
List<int> corruptedLineScores = new();

foreach (var subsystemLine in subsystem)
{
    Stack<char> stack = new Stack<char>();

    foreach (var character in subsystemLine)
    {
        if (validOpenCharacters.Contains(character))
        {
            stack.Push(character);
        }
        else
        {
            char lastCharacter = stack.Pop();

            // Switch expressions FTW! Rider (my IDE) actually
            // helped me with this by suggesting that I convert
            // the normal switch statement I had to a switch
            // expression. I like how concise it is.
            int score = (lastCharacter, character) switch
            {
                ('(', ')') => -1,
                (_, ')') => 3,
                ('[', ']') => -1,
                (_, ']') => 57,
                ('{', '}') => -1,
                (_, '}') => 1197,
                ('<', '>') => -1,
                (_, '>') => 25137,
                _ => 0
            };

            if (score != -1)
            {
                corruptedLineScores.Add(score);
                break;
            }
        }
    }
}

int totalScore = corruptedLineScores.Sum();

Console.WriteLine("--- Part One ---");
Console.WriteLine($"Corrupted lines total score: {totalScore}");

// Part Two

List<long> incompleteLineScores = new();

foreach (List<char> subsystemLine in subsystem)
{
    Stack<char> stack = new Stack<char>();
    bool corruptedLine = false;

    foreach (char character in subsystemLine)
    {
        if (validOpenCharacters.Contains(character))
        {
            stack.Push(character);
        }
        else
        {
            char lastCharacter = stack.Pop();

            // Switch expressions FTW! Rider (my IDE) actually
            // helped me with this by suggesting that I convert
            // the normal switch statement I had to a switch
            // expression. I like how concise it is.
            int score = (lastCharacter, character) switch
            {
                ('(', ')') => -1,
                (_, ')') => 3,
                ('[', ']') => -1,
                (_, ']') => 57,
                ('{', '}') => -1,
                (_, '}') => 1197,
                ('<', '>') => -1,
                (_, '>') => 25137,
                _ => 0 
            };

            if (score != -1)
            {
                corruptedLine = true;
                break;
            }
        }
    }
    
    // If we get here and the `corruptedLine` flag is not set,
    // then we have an incomplete line. We are left with 
    // only the opening syntax characters that did not have a 
    // closing since any others were popped off the stack.
    if (!corruptedLine)
    {
        long incompleteLineScore = 0;

        foreach (char character in stack)
        {
            incompleteLineScore = incompleteLineScore * 5 + character switch
            {
                '(' => 1,
                '[' => 2,
                '{' => 3,
                '<' => 4,
                _ => 0
            };
        }

        incompleteLineScores.Add(incompleteLineScore);
    }
}

// Use Skip() and Take() to get the middle item in the 
// list. Need to research if there is a better way to do this.
var middleScore = incompleteLineScores
    .OrderBy(s => s)
    .Skip(incompleteLineScores.Count / 2)
    .Take(1)
    .First();

Console.WriteLine("--- Part Two ---");
Console.WriteLine($"Middle score: {middleScore}");
