// Part One

const string DirectionForward = "forward";
const string DirectionUp = "up";
const string DirectionDown = "down";

var instructions = new List<Instruction>();

// Read all of the lines from the input.txt file into a 
// List<Instruction> collection while parsing the values
// out of each string/line.
foreach (string line in File.ReadLines("input.txt"))
{
    var spaceIndex = line.IndexOf(' ');
    string direction = line[..(spaceIndex)];
    int moves = int.Parse(line[(spaceIndex)..]);
    
    instructions.Add(new Instruction(direction, moves));
}

int horizontalPosition = 0;
int verticalPosition = 0;

foreach ((string direction, int moves) in instructions)
{
    switch (direction)
    {
        case DirectionForward:
            horizontalPosition += moves;
            break;
        case DirectionUp:
            verticalPosition -= moves;
            break;
        case DirectionDown:
            verticalPosition += moves;
            break;
    }
}

Console.WriteLine("--- Day 2: Part One ---");
Console.WriteLine($"Horizontal position: {horizontalPosition}");
Console.WriteLine($"Vertical position: {verticalPosition}");
Console.WriteLine($"Horizontal * Vertical = {horizontalPosition * verticalPosition}");

// Part Two

horizontalPosition = 0;
verticalPosition = 0;
int aim = 0;

foreach ((string direction, int moves) in instructions)
{
    switch (direction)
    {
        case DirectionForward:
            horizontalPosition += moves;
            verticalPosition += aim * moves;
            break;
        case DirectionUp:
            aim -= moves;
            break;
        case DirectionDown:
            aim += moves;
            break;
    }
}

Console.WriteLine("--- Day 2: Part Two ---");
Console.WriteLine($"Horizontal position: {horizontalPosition}");
Console.WriteLine($"Vertical position: {verticalPosition}");
Console.WriteLine($"Horizontal * Vertical = {horizontalPosition * verticalPosition}");

internal record Instruction(string Direction, int Moves);
