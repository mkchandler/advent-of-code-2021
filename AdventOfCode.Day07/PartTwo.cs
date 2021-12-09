namespace AdventOfCode.Day07;

public class PartTwo
{
    // There are a few things that make this method inefficient, but it does
    // solve the problem for now. I think this will be a really interesting 
    // problem to return to (and possibly blog about) because it can be a 
    // lesson in optimization.
    // 
    // A couple things I can think of would be:
    // 1. Narrowing down possible horizontal positions so that all don't have
    //    to be iterated over. There are probably a couple ways to solve this.
    // 2. Group all common crab together so that the same position doesn't 
    //    have to be calculated multiple times.
    // 3. Apply a better formula for the increase in fuel burn so that multiple
    //    enumerations don't have to happen (currently the slowest part).
    public int CalculateFuelCost(IList<int> crabPositions)
    {
        int lowestFuelCost = int.MaxValue;

        for (int horizontalPosition = crabPositions.Min();
             horizontalPosition < crabPositions.Max();
             horizontalPosition++)
        {
            int currentFuelCost = 0;

            for (int crabPosition = 0;
                 crabPosition < crabPositions.Count;
                 crabPosition++)
            {
                // This is the most expensive part of this method. It is very inefficient because
                // it is doing multiple enumerations over the entire collection. I will save any 
                // optimizations for the future as I think there could be some really good ones 
                // to explore.
                currentFuelCost += Enumerable
                    .Range(0, Math.Abs(horizontalPosition - crabPositions[crabPosition]) + 1)
                    .Aggregate(0, (total, next) => total + next);
            }

            if (currentFuelCost < lowestFuelCost)
            {
                lowestFuelCost = currentFuelCost;
            }
        }

        return lowestFuelCost;
    }
}
