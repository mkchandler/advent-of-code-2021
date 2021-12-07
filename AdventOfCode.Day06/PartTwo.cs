namespace AdventOfCode.Day06;

public class PartTwo
{
    // To be able to calculate larger numbers of days, I am storing 
    // the count of each lanternfish in its corresponding index that 
    // matches the lanternfish's internal timer. The count is stored 
    // in a `long` to account for larger numbers that accumulate with
    // a larger number of days.
    public long CountLanternfishForDays(IList<int> input, int days)
    {
        List<long> lanternfishSpawnState = new(new long[9]);

        // Set any initial states from the input to their corresponding index
        foreach (int initialSpawnState in input)
        {
            lanternfishSpawnState[initialSpawnState]++;
        }

        for (int i = 0; i < days; i++)
        {
            List<long> updatedLanternfishSpawnState = new(new long[9]);
            
            // Get any lanternfish that has a health timer of zero and 
            // reset it to 6.
            updatedLanternfishSpawnState[6] = lanternfishSpawnState[0];
            
            // When a lanternfish is at zero, not only does it reset to 6,
            // but it also adds a new lanternfish with a health of 8.
            updatedLanternfishSpawnState[8] = lanternfishSpawnState[0];

            // Loop through each health timer value and replace their values
            // with the incremented index, which will decrement the health
            // of each lanternfish by one each day.
            for (int j = 0; j < 8; j++)
            {
                updatedLanternfishSpawnState[j] += lanternfishSpawnState[j + 1];
            }

            lanternfishSpawnState = updatedLanternfishSpawnState;
        }

        // Add up the values from all of the indexes to get the final count
        return lanternfishSpawnState.Aggregate<long, long>(0, (count, i) => count + i);
    }
}
