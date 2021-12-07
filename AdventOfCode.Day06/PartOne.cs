namespace AdventOfCode.Day06;

public class PartOne
{
    // For part one I went with a brute force approach to counting the 
    // the lanternfish. This proved to be fine for small numbers of days,
    // but failed miserably with the higher number of days in part two.
    public int CountLanternfishForDays(IList<int> input, int days)
    {
        for (int i = 0; i < days; i++)
        {
            int startDayCount = input.Count;

            for (int fishIndex = 0; fishIndex < startDayCount; fishIndex++)
            {
                int fishValue = input[fishIndex];

                if (fishValue == 0)
                {
                    input[fishIndex] = 6;
                    input.Add(8);
                }
                else
                {
                    input[fishIndex] = --fishValue;
                }
            }
        }

        return input.Count;
    }
}
