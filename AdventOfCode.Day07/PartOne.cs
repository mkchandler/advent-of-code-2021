namespace AdventOfCode.Day07;

public class PartOne
{
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
                currentFuelCost += 
                    Math.Abs(horizontalPosition - crabPositions[crabPosition]);
            }

            if (currentFuelCost < lowestFuelCost)
            {
                lowestFuelCost = currentFuelCost;
            }
        }

        return lowestFuelCost;
    }
}
