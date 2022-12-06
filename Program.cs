using System.Linq;

Day6.Solution();

public static class Day6
{

    public static void Solution()
    {
        Console.WriteLine("Advent of Code 2022 Day 6");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {}");
        Console.WriteLine($"Part 2: {}");
    }

    public static int ProcessData()
    {
        //string[] data = File.ReadLines("Data/day6.txt")
        //                    .Select(x => x.Trim())
        //                    .ToArray();
        stirng[] data = new string[] {"mjqjpqmgbljsphdztnvjfqwrcgsmlb"};
        string buffer = "";
        for (int idx = 0; idx < data[0].Length; idx++)
        {
            buffer = data[0].Substring(idx, 4);
            if (bubber.Distinct().Length = 4)
                return idx + 4; 
        }
        return 0;
    }

}

public static class Day5
{

    public static void Solution()
    {
        Console.WriteLine("Advent of Code 2022 Day 5");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Day5.ProcessData()}");
        Console.WriteLine($"Part 2: {Day5.ProcessData(reverseBuffer: true)}");
    }

    public static string ProcessData(bool reverseBuffer = false)
    {
        string[] data = File.ReadLines("Data/day5.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        Stack<char>[] stacks = GetStacks(data);
        (int, int, int)[] instructions = GetInstructions(data);
        List<char> buffer = new();
        foreach (var i in instructions)
        {
            buffer = Enumerable.Range(0, i.Item1)
                               .Select(x => stacks[i.Item2 - 1].Pop())
                               .ToList();
            if (reverseBuffer) buffer.Reverse();
            foreach (char c in buffer) stacks[i.Item3 - 1].Push(c);
        }
        char[] result = Enumerable.Range(0, stacks.Length)
                                  .Select(x => stacks[x].Pop())
                                  .ToArray();
        return string.Join("", result);
    }

    public static Stack<char>[] GetStacks(string[] data)
    {
        Stack<char>[] stacks = Enumerable.Range(0, 9)
                                         .Select(_ => new Stack<char>())
                                         .ToArray();
        int stackIdx = 0;
        char stack;
        for (int col = 1; col < 34; col += 4)
        {
            for (int row = 7; row >= 0; row--)
            {
                stack = data[row][col];
                if (stack != ' ')
                    stacks[stackIdx].Push(stack);
            }
            stackIdx++;
        }
        return stacks;
    }

    public static (int, int, int)[] GetInstructions(string[] data)
    {
        List<(int, int, int)> instructions = new();
        string[] split1, split2;
        int move, from, to;
        foreach (string line in data[10..data.Length])
        {
            split1 = line.Split(" from ");
            split2 = split1[1].Split(" to ");
            move = Convert.ToInt32(split1[0].Substring(5));
            from = Convert.ToInt32(split2[0]);
            to = Convert.ToInt32(split2[1]);
            instructions.Add((move, from, to));
        }
        return instructions.ToArray();
    }

}

public static class Day4
{

    public static void SolutionPart1()
    {
        var scores = File.ReadLines("Data/day4.txt")
                         .Select(x => ProcessRowPart1(x.Trim()));
        Console.WriteLine($"Total: {scores.Sum()}");
    }

    public static void SolutionPart2()
    {
        var scores = File.ReadLines("Data/day4.txt")
                         .Select(x => ProcessRowPart2(x.Trim()));
        Console.WriteLine($"Total: {scores.Sum()}");
    }

    public static int ProcessRowPart1(string row)
    {
        string[] splits = row.Split(",").ToArray();
        int[] left = splits[0].Split("-").Select(x => Convert.ToInt32(x)).ToArray();
        int[] right = splits[1].Split("-").Select(x => Convert.ToInt32(x)).ToArray();
        if (left[0] >= right[0] & left[1] <= right[1]) return 1;
        if (right[0] >= left[0] & right[1] <= left[1]) return 1;
        return 0;
    }

    public static int ProcessRowPart2(string row)
    {
        string[] splits = row.Split(",").ToArray();
        int[] left = splits[0].Split("-").Select(x => Convert.ToInt32(x)).ToArray();
        int[] right = splits[1].Split("-").Select(x => Convert.ToInt32(x)).ToArray();
        if (left[0] >= right[0] & left[0] <= right[1]) return 1;
        if (left[1] >= right[0] & left[1] <= right[1]) return 1;
        if (right[0] >= left[0] & right[0] <= left[1]) return 1;
        if (right[1] >= left[0] & right[1] <= left[1]) return 1;
        return 0;
    }

}

public static class Day3
{

    public static void SolutionPart1()
    {
        var s = new Scorer();
        var scores = File.ReadLines("Data/day3.txt")
                         .Select(x => ProcessSackPart1(x.Trim(), s));
        Console.WriteLine($"Total: {scores.Sum()}");
    }

    public static void SolutionPart2()
    {
        var s = new Scorer();
        var lines = File.ReadLines("Data/day3.txt");
        int total = 0;
        List<string> group = new();
        foreach (var line in lines)
        {
            group.Add(line);
            if (group.Count == 3)
            {
                total += ProcessGroupPart2(group, s);
                group = new();
            }
        }
        Console.WriteLine(total);
    }

    public static int ProcessSackPart1(string content, Scorer s)
    {
        if (content.Length % 2 != 0)
            throw new ArgumentException("Rucksack content must be even");
        int splitPoint = content.Length / 2;
        string left = content.Substring(0, splitPoint);
        string right = content.Substring(splitPoint, splitPoint);
        var inBoth = left.ToCharArray().Intersect(right.ToCharArray());
        return s.score(inBoth.ToArray()[0]);
    }

    public static int ProcessGroupPart2(List<string> group, Scorer s)
    {
        var firstTwo = group[0].ToCharArray().Intersect(group[1].ToCharArray());
        var inThree = firstTwo.Intersect(group[2].ToCharArray()).ToArray();
        return s.score(inThree[0]);
    }

    public class Scorer
    {
        private List<char> lower;
        private List<char> upper;

        public Scorer()
        {
            lower = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
            upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();
        }

        public int score(char c)
        {
            if (lower.Contains(c))
                return lower.IndexOf(c) + 1;
            if (upper.Contains(c))
                return upper.IndexOf(c) + 1 + 26;
            return 0;
        }
    }

}

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
