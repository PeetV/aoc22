Day2.SolutionPart2();

public static class Day2
{
    public static void SolutionPart1()
    {
        var scores = File.ReadLines("Data/day2.txt")
                         .Select(x => ScorePart1(x.Trim()));
        Console.WriteLine($"Total: {scores.Sum()}");
    }

    public static void SolutionPart2()
    {
        var scores = File.ReadLines("Data/day2.txt")
                         .Select(x => ScorePart2(x.Trim()));
        Console.WriteLine($"Total: {scores.Sum()}");
    }

    public static int ScorePart1(string played)
    {
        // A = Rock B = Paper C = Scissors
        // X = Rock Y = Paper Z = Scissors
        // X = 1    Y = 2     Z = 3
        // Win = 6  Draw = 3  Loss = 0  
        return played switch
        {
            "A X" => 1 + 3,
            "A Y" => 2 + 6,
            "A Z" => 3 + 0,
            "B X" => 1 + 0,
            "B Y" => 2 + 3,
            "B Z" => 3 + 6,
            "C X" => 1 + 6,
            "C Y" => 2 + 0,
            "C Z" => 3 + 3,
            _ => throw new ArgumentOutOfRangeException($"{played}!?")
        };
    }

    public static int ScorePart2(string played)
    {
        // A = Rock B = Paper C = Scissors
        // X = lose Y = draw  Z = win
        // Win = 6  Draw = 3  Loss = 0   
        return played switch
        {
            "A X" => 3 + 0, // Rock lose with scissors
            "A Y" => 1 + 3, // Rock draw with rock
            "A Z" => 2 + 6, // Rock win with paper
            "B X" => 1 + 0, // Paper lose with rock
            "B Y" => 2 + 3, // Paper draw with paper
            "B Z" => 3 + 6, // Paper win with scissors
            "C X" => 2 + 0, // Scissors lose with paper
            "C Y" => 3 + 3, // Scissors draw with scissors
            "C Z" => 1 + 6, // Scissors win with rock
            _ => throw new ArgumentOutOfRangeException($"{played}!?")
        };
    }
}

public static class Day1
{

    public static void SolutionPart1()
    {
        List<int> totals = GetTotals();
        Console.WriteLine($"Highest total: {totals.Max()}");
    }

    public static void SolutionPart2()
    {
        List<int> totals = GetTotals();
        totals = totals.OrderByDescending(i => i).ToList();
        int result = totals.ToArray()[0..3].Sum();
        Console.WriteLine($"Sum of highest 3: {result}");
    }

    public static List<int> GetTotals()
    {
        int rowval, index = 0;
        string[] data = File.ReadLines("Data/day1.txt").ToArray();
        List<int> totals = new() { 0 };
        foreach (string row in data)
        {
            if (row == "")
            {
                index += 1;
                totals.Add(0);
                continue;
            }
            if (!int.TryParse(row, out rowval)) rowval = 0;
            totals[index] += rowval;
        }
        return totals;
    }

}
