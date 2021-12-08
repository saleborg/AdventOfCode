//PART 1
var positions = File.ReadAllText(@"C:\Code\AdventOfCode\7\input.txt").Split(',').Select(double.Parse).ToArray();
var InputSplitCInt = File.ReadAllText(@"C:\Code\AdventOfCode\7\input.txt").Split(',').Select(int.Parse).ToArray(); ;

var answer = GetMedian(positions.ToArray());
Console.WriteLine("Position: " + answer);

calcFuel(ans: answer);

void calcFuel(double ans)
{

    double fuel = 0;
    foreach (var crab in positions)
    {

        if (crab < ans)
        {
            fuel += (ans - crab);
        }
        else
        {
            fuel += (crab - ans);
        }
    }
    Console.WriteLine(fuel);
}









double GetMedian(double[] sourceNumbers)
{
    //Framework 2.0 version of this method. there is an easier way in F4        
    if (sourceNumbers == null || sourceNumbers.Length == 0)
        throw new System.Exception("Median of empty array not defined.");

    //make sure the list is sorted, but use a new array
    double[] sortedPNumbers = (double[])sourceNumbers.Clone();
    Array.Sort(sortedPNumbers);

    //get the median
    int size = sortedPNumbers.Length;
    int mid = size / 2;
    double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
    return median;
}


//PART 2
var test = new List<double>() { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14, 2 };

int i = (int)Math.Round(positions.Average(), MidpointRounding.AwayFromZero);

Console.WriteLine(i);
calcFuel(ans: i);


DoWork();

void DoWork()
{
    Dictionary<int, int> positions = new();
    int WhichPart = 0;
    for (int pos = InputSplitCInt.Min(); pos <= InputSplitCInt.Max(); pos++)
    {

        if ((WhichPart == 1 && !InputSplitCInt.Contains(pos)) || positions.ContainsKey(pos)) continue;
        positions[pos] = 0;
        foreach (int sub in InputSplitCInt)
        {
            int moves = Math.Abs(sub - pos);
            positions[pos] += WhichPart == 1 ? moves : moves * (moves + 1) / 2;
        }
    }

    string Output = positions.Values.Min().ToString();
    Console.WriteLine(Output);
}
