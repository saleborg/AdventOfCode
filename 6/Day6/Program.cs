internal class Day_06
{
    private readonly int[] _input;

    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        var Day = new Day_06();
        Console.WriteLine(Day.Solve_1());
        Console.WriteLine(Day.Solve_2());

    }


    public Day_06()
    {


        _input = File.ReadAllText(@"C:\Code\AdventOfCode\6\input.txt").Split(',').Select(int.Parse).ToArray();
    }

    public ValueTask<string> Solve_1()
    {
        var spawnNumbers = GetNumberOfSpawnsAfterXAmountOfDays(80);

        return new(spawnNumbers.ToString());
    }

    public ValueTask<string> Solve_2()
    {
        var spawnNumbers = GetNumberOfSpawnsAfterXAmountOfDays(256);

        return new(spawnNumbers.ToString());
    }

    private long GetNumberOfSpawnsAfterXAmountOfDays(int endDayCount)
    {
        var spawnRates = Enumerable.Range(0, 9).Select(x => new
        {
            Key = x,
            Value = Convert.ToInt64(_input.Where(y => y == x).Count())
        }).ToDictionary(x => x.Key, x => x.Value);

        var dayCount = 0;

        while (dayCount < endDayCount)
        {
            var previousNumberOfSpawns = 0L;

            foreach (var day in spawnRates.Reverse())
            {
                if (day.Key == 8)
                {
                    previousNumberOfSpawns = day.Value;
                    spawnRates[8] = 0;
                }
                else if (day.Key == 0)
                {
                    spawnRates[6] += day.Value;
                    spawnRates[8] = day.Value;

                    spawnRates[day.Key] = previousNumberOfSpawns;
                    previousNumberOfSpawns = day.Value;
                }
                else
                {
                    spawnRates[day.Key] = previousNumberOfSpawns;
                    previousNumberOfSpawns = day.Value;
                }
            }

            dayCount++;
        }

        return spawnRates.Sum(x => x.Value);
    }
}