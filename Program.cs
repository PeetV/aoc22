using System.Linq;

using CsML.Extensions;
using CsML.Graph;

Day14.Solution();

public static class Day14
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 14");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        List<(int, int)[]> lines = GetLines();
        foreach (var line in lines) Console.WriteLine(line.Delimited());
        // Console.WriteLine(GetDimensions(lines));
        (int minX, int maxX, int minY, int maxY) = GetDimensions(lines);
        int width = maxX - minX + 1;
        int height = maxY - minY + 1;
        // Console.WriteLine($"Matrix with width {width} and height {height}");
        int[,] matrix = new int[height, width];
        // AddRock(matrix, new (int, int)[] { (498, 4) }, minX, minY);
        foreach (var line in lines) AddRock(matrix, line, minX, minY);
        PrintMatrix(matrix);
        return 0;
    }

    public static int Part2()
    { return 0; }

    public static void PrintMatrix(int[,] matrix)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
                Console.Write(matrix[r, c]);
            Console.WriteLine("");
        }
    }

    public static void AddRock(int[,] matrix, (int, int)[] line, int xoffset, int yoffset)
    {
        if (line.Length == 0) return;
        if (line.Length == 1) matrix[line[0].Item2 - yoffset, line[0].Item1 - xoffset] = 1;
        int curX, curY, nextX, nextY;
        for (int idx = 0; idx < line.Length - 1; idx++)
        {
            (curX, curY) = line[idx];
            matrix[curY - yoffset, curX - xoffset] = 1;
            (nextX, nextY) = line[idx + 1];
            Console.WriteLine($"from {curX}, {curY} to {nextX}, {nextY}");
            if (curY == nextY)
            {
                if (curX < nextX)
                    for (int x = curX; x <= nextX; x++)
                        matrix[curY - yoffset, x - xoffset] = 1;
                if (curX > nextX)
                    for (int x = nextX; x >= curX; x--)
                        matrix[curY - yoffset, x - xoffset] = 1;
            }
            else
            {
                if (curY < nextY)
                    for (int y = curY; y <= nextY; y++)
                        matrix[y - yoffset, curX - xoffset] = 1;
                if (curY > nextY)
                    for (int y = nextY; y >= curY; y--)
                        matrix[y - yoffset, curX - xoffset] = 1;

            }
        }
    }

    public static (int, int, int, int) GetDimensions(List<(int, int)[]> lines)
    {
        int minX = int.MaxValue, maxX = int.MinValue;
        int minY = int.MaxValue, maxY = int.MinValue;
        foreach (var line in lines)
            foreach ((int xval, int yval) in line)
            {
                if (xval < minX) minX = xval;
                if (xval > maxX) maxX = xval;
                if (yval < minY) minY = yval;
                if (yval > maxY) maxY = yval;
            }
        return (minX, maxX, minY, maxY);
    }

    public static List<(int, int)[]> GetLines()
    {
        List<(int, int)[]> result = new();
        string[] data = File.ReadLines("Data/day14.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        string[] stringPoints;
        int[] point;
        List<(int, int)> buffer;
        foreach (string line in data)
        {
            buffer = new();
            stringPoints = line.Split(" -> ");
            foreach (string stringPoint in stringPoints)
            {
                point = stringPoint.Split(",")
                                   .Select(x => Convert.ToInt32(x))
                                   .ToArray();
                buffer.Add((point[0], point[1]));
            }
            result.Add(buffer.ToArray());
        }
        return result;
    }
}

public static class Day13
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 13");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        // int[] p1 = { 1, 1, 3, 1, 1 };
        // int[] p2 = { 1, 1, 5, 1, 1 };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // p1 = new int[] { 1, 2, 3, 4 };
        // p2 = new int[] { 1, 4 };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // p1 = new int[] { 9 };
        // p2 = new int[] { 8, 7, 6 };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // p1 = new int[] { 4, 4, 4, 4 };
        // p2 = new int[] { 4, 4, 4, 4, 4 };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // p1 = new int[] { 7, 7, 7, 7 };
        // p2 = new int[] { 7, 7, 7 };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // p1 = new int[] { };
        // p2 = new int[] { 3 };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // p1 = new int[] { };
        // p2 = new int[] { };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // p1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // p2 = new int[] { 1, 2, 3, 4, 5, 6, 0, 8, 9 };
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // Console.WriteLine($"[{p1.Delimited()}], [{p2.Delimited()}]: {ProcessPair((p1, p2))}");
        // return 0;
        (int[], int[])[] pairs = GetData();
        int total = 0;
        for (int i = 0; i < pairs.Length; i++)
        {
            if (ProcessPair(pairs[i]) == 1)
            {
                total += i + 1;
            }
        }
        return total;
    }

    public static int Part2()
    {
        return 0;
    }

    private static int ProcessPair((int[], int[]) input)
    {
        var zipped = input.Item1.Zip(input.Item2);
        if (input.Item1.Length == input.Item2.Length)
            return zipped.Any(x => x.First < x.Second) ? 1 : 0;
        if (zipped.All(x => x.First == x.Second))
            return input.Item1.Length < input.Item2.Length ? 1 : 0;
        if (zipped.Any(x => x.First < x.Second))
            return 1;
        return 0;
    }

    public static (int[], int[])[] GetData()
    {
        List<(int[], int[])> result = new();
        string[] data = File.ReadLines("Data/day13.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == "")
            {
                result.Add((StringToList(data[i - 2]),
                            StringToList(data[i - 1])));
            }
            if (i == data.Length - 1)
            {
                result.Add((StringToList(data[i - 1]),
                            StringToList(data[i - 0])));
            }
        }
        return result.ToArray();
    }

    private static int[] StringToList(string input)
    {
        List<int> result = new();
        for (int i = 0; i < input.Count(); i++)
        {
            if ("[], ".Contains(input[i])) continue;
            result.Add(Convert.ToInt32(input[i] - '0'));
        }
        return result.ToArray();
    }

}

public static class Day12
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 12");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        Graph<string> graph = BuildGraph();
        (double shortest, string[] path) = graph.ShortestPathDijkstra("20-0", "20-52");
        return (int)shortest;
    }

    public static int Part2()
    {
        Graph<string> graph = BuildGraph();
        string[] data = File.ReadLines("Data/day12.txt")
                                    .Select(x => x.Trim())
                                    .ToArray();
        string currentNode, currentChar;
        double shortest;
        List<string> candidates = new();
        for (int row = 0; row < data.Length; row++)
            for (int col = 0; col < data[0].Count(); col++)
            {
                currentNode = $"{row}-{col}";
                currentChar = data[row][col].ToString();
                if (currentChar != "a") continue;
                candidates.Add(currentNode);
            }
        List<int> results = Enumerable.Repeat(0, candidates.Count()).ToList();
        Parallel.For(0, candidates.Count(), x =>
        {
            currentNode = candidates[x];
            (shortest, _) = graph.ShortestPathDijkstra(currentNode, "20-52");
            results[x] = (int)shortest;
        });
        return results.Where(x => x > 0).Min();
    }

    public static Graph<string> BuildGraph()
    {
        Graph<string> graph = new();
        string[] data = File.ReadLines("Data/day12.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        // Add nodes
        for (int row = 0; row < data.Length; row++)
            for (int col = 0; col < data[0].Count(); col++)
                graph.AddNode($"{row}-{col}");
        // Add edges
        string currentNode, nextNode, currentChar, nextChar;
        for (int row = 0; row < data.Length; row++)
            for (int col = 0; col < data[0].Count(); col++)
            {
                currentNode = $"{row}-{col}";
                currentChar = data[row][col].ToString();
                // Up
                if (row > 0)
                {
                    nextNode = $"{row - 1}-{col}";
                    nextChar = data[row - 1][col].ToString();
                    if (AllowedChars(currentChar).Contains(nextChar))
                        graph.UpdateEdge(from: currentNode, to: nextNode, undirected: true);
                }
                // Down
                if (row < data.Length - 1)
                {
                    nextNode = $"{row + 1}-{col}";
                    nextChar = data[row + 1][col].ToString();
                    if (AllowedChars(currentChar).Contains(nextChar))
                        graph.UpdateEdge(from: currentNode, to: nextNode, undirected: true);
                }
                // Left
                if (col > 0)
                {
                    nextNode = $"{row}-{col - 1}";
                    nextChar = data[row][col - 1].ToString();
                    if (AllowedChars(currentChar).Contains(nextChar))
                        graph.UpdateEdge(from: currentNode, to: nextNode, undirected: true);
                }
                // Right
                if (col < data[0].Count() - 1)
                {
                    nextNode = $"{row}-{col + 1}";
                    nextChar = data[row][col + 1].ToString();
                    if (AllowedChars(currentChar).Contains(nextChar))
                        graph.UpdateEdge(from: currentNode, to: nextNode, undirected: true);
                }
            }
        return graph;
    }

    public static string[] AllowedChars(string current)
    {
        if (current == "S") return new string[] { "a" };
        if (current == "E") return new string[] { "z" };
        string letters = "SabcdefghijklmnopqrstuvwxyzE";
        int index = letters.IndexOf(current);
        if (index == -1) throw new System.ArgumentOutOfRangeException($"{current} not in {letters}");
        return new string[] { letters[index - 1].ToString(),
                                  letters[index].ToString(),
                                  letters[index + 1].ToString() };
    }
}

public static class Day11
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 11");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        List<Monkey> monkeys = GetMonkeys();
        int rounds = 20;
        for (int r = 0; r < rounds; r++)
        {
            foreach (var monkey in monkeys) monkey.PlayRoundPart1(monkeys);
        }
        int[] counts = monkeys.Select(x => x.inspectionCount).ToArray();
        counts = counts.OrderByDescending(x => x).ToArray();
        return counts[0] * counts[1];
    }

    public static int Part2()
    {
        List<Monkey> monkeys = GetMonkeys();
        int rounds = 20;
        for (int r = 0; r < rounds; r++)
        {
            foreach (var monkey in monkeys) monkey.PlayRoundPart2(monkeys);
        }
        foreach (var monkey in monkeys) Console.WriteLine(monkey);
        int[] counts = monkeys.Select(x => x.inspectionCount).ToArray();
        counts = counts.OrderByDescending(x => x).ToArray();
        return counts[0] * counts[1];
    }

    public class Monkey
    {
        public List<int> items;
        public Func<int, int> operation = x => x;
        public string operationString;
        public int divisibleBy;
        public int monkeyOnTrue;
        public int monkeyOnFalse;
        public int worryLevel;
        public int inspectionCount;

        public Monkey(
            int[] items,
            string operationString,
            int divisibleBy,
            int monkeyOnTrue,
            int monkeyOnFalse
        )
        {
            this.items = new List<int>(items);
            this.operationString = operationString;
            this.divisibleBy = divisibleBy;
            this.monkeyOnTrue = monkeyOnTrue;
            this.monkeyOnFalse = monkeyOnFalse;
            OperationStringToFunc();
            this.inspectionCount = 0;
        }

        public override string ToString()
        {
            return $"Monkey(inspections={inspectionCount} items=[{string.Join(",", items)}], operation={operationString}, divisible={divisibleBy}, true={monkeyOnTrue}, false={monkeyOnFalse})";
        }

        private void OperationStringToFunc()
        {
            string[] splits = { };
            string op;
            if (operationString.Contains("+")) op = "+";
            else op = "*";
            splits = operationString.Split($" {op} ");
            if (splits[0] == "old" & splits[1] == "old" & op == "+")
                operation = x => x + x;
            if (splits[0] == "old" & splits[1] == "old" & op == "*")
                operation = x => x * x;
            if (splits[0] == "old" & splits[1] != "old" & op == "+")
                operation = x => x + Convert.ToInt32(splits[1]);
            if (splits[0] != "old" & splits[1] == "old" & op == "+")
                operation = x => Convert.ToInt32(splits[0]) + x;
            if (splits[0] == "old" & splits[1] != "old" & op == "*")
                operation = x => x * Convert.ToInt32(splits[1]);
            if (splits[0] != "old" & splits[1] == "old" & op == "*")
                operation = x => Convert.ToInt32(splits[0]) * x;
        }

        public void PlayRoundPart1(List<Monkey> monkeys)
        {
            int worry;
            foreach (int item in items)
            {
                worry = operation(item);
                worry /= 3;
                if ((worry % divisibleBy) == 0)
                    monkeys[monkeyOnTrue].items.Add(worry);
                else monkeys[monkeyOnFalse].items.Add(worry);
                inspectionCount++;
            }
            items.Clear();
        }

        public void PlayRoundPart2(List<Monkey> monkeys)
        {
            int worry;
            foreach (int item in items)
            {
                worry = operation(item);
                // worry /= 3;
                if ((worry % divisibleBy) == 0)
                {
                    worry = 1;
                    monkeys[monkeyOnTrue].items.Add(worry);
                }
                else
                {
                    worry = worry % divisibleBy;
                    monkeys[monkeyOnFalse].items.Add(worry);
                }
                inspectionCount++;
            }
            items.Clear();
        }
    }

    public static List<Monkey> GetMonkeys()
    {
        string[] data = File.ReadLines("Data/day11.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        List<Monkey> monkeys = new();
        int[] items = { };
        string[] split;
        string line, sub, operationString = "";
        int divisibleBy = 0, monkeyTrue = 0, monkeyFalse = 0;
        for (int i = 0; i < data.Length; i++)
        {
            line = data[i];
            if (line.Trim().StartsWith("Starting items:"))
            {
                sub = line[15..line.Count()];
                if (!sub.Contains(","))
                    split = new string[] { sub };
                else
                    split = sub.Split(",");
                items = split.Select(x => x.Trim())
                             .Select(x => Convert.ToInt32(x))
                             .ToArray();
            }
            if (line.Trim().StartsWith("Operation: new = "))
                operationString = line[17..line.Count()];
            if (line.Trim().StartsWith("Test: divisible by "))
                divisibleBy = Convert.ToInt32(line[19..line.Count()]);
            if (line.Trim().StartsWith("If true: throw to monkey "))
                monkeyTrue = Convert.ToInt32(line[25..line.Count()]);
            if (line.Trim().StartsWith("If false: throw to monkey "))
                monkeyFalse = Convert.ToInt32(line[26..line.Count()]);
            if (line == "" | i == data.Length - 1)
            {
                monkeys.Add(new Monkey(items, operationString, divisibleBy, monkeyTrue, monkeyFalse));
            }
        }
        return monkeys;
    }
}

public static class Day10
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 10");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.Write("Part 1: ");
        Part1();
        Console.WriteLine("Part 2: ");
        Part2();
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static void Part1()
    {
        List<(int, int)> queue = GetQue();
        int[] slots = { 19, 59, 99, 139, 179, 219 };
        int result = slots.Select(x => queue[x].Item1 * queue[x].Item2).Sum();
        Console.WriteLine(result);
    }

    public static void Part2()
    {
        List<(int, int)> queue = GetQue();
        int currentCrt = 0;
        int[] newRowAt = { 40, 80, 120, 160, 200, 240 };
        foreach ((int cycle, int x) in queue)
        {
            if (currentCrt >= x - 1 & currentCrt <= x + 1)
                Console.Write("#");
            else
                Console.Write(".");
            currentCrt += 1;
            if (newRowAt.Contains(cycle))
            {
                currentCrt = 0;
                Console.WriteLine("");
            }
        }
    }

    public static List<(int, int)> GetQue()
    {
        int cycle = 0;
        int x = 1;
        (string, int)[] instructions = GetData();
        List<(int, int)> queue = new();
        List<(int, int)> tail = new();
        foreach ((string instr, int val) in instructions)
        {
            if (instr == "noop")
            {
                cycle += 1;
                queue.Add((cycle, x));
            }
            else if (instr == "addx")
            {
                cycle += 1;
                queue.Add((cycle, x));
                cycle += 1;
                queue.Add((cycle, x));
                x += val;
            }
        }
        return queue;
    }

    public static (string, int)[] GetData()
    {
        string[] split;
        Func<string, (string, int)> processData = x =>
        {
            if (x == "noop") return ("noop", 0);
            split = x.Trim().Split(" ");
            return (split[0], Convert.ToInt32(split[1]));
        };
        (string, int)[] data = File.ReadLines("Data/day10.txt")
                                   .Select(x => processData(x))
                                   .ToArray();
        return data;
    }
}

public static class Day9
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 9");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        (string, int)[] data = GetData();
        int hx = 0, hy = 0, tx = 0, ty = 0;
        Dictionary<string, int> visited = new() { { "0-0", 1 } };
        foreach ((string dir, int steps) in data)
        {
            for (int step = 0; step < steps; step++)
            {
                switch (dir)
                {
                    case "R": hx++; break;
                    case "L": hx--; break;
                    case "U": hy++; break;
                    case "D": hy--; break;
                };
                (tx, ty) = UpdateFollowerPart1(hx, hy, tx, ty);
                Increment(visited, $"{tx}-{ty}");
            }
        }
        return visited.Keys.Count();
    }

    public static int Part2()
    {
        (string, int)[] data = GetData();
        List<(int, int)> knots = Enumerable.Repeat((0, 0), 10).ToList();
        Dictionary<string, int> visited = new() { { "0-0", 1 } };
        foreach ((string dir, int steps) in data)
        {
            for (int step = 0; step < steps; step++)
            {
                // Move head knot
                (int hx, int hy) = knots[0];
                switch (dir)
                {
                    case "R": hx++; break;
                    case "L": hx--; break;
                    case "U": hy++; break;
                    case "D": hy--; break;
                };
                knots[0] = (hx, hy);
                // Move following knots
                for (int i = 0; i < knots.Count() - 1; i++)
                {
                    (int hX, int hY) = knots[i];
                    (int tX, int tY) = knots[i + 1];
                    (tX, tY) = UpdateFollowerPart2(hX, hY, tX, tY);
                    knots[i + 1] = (tX, tY);
                }
                (int tx, int ty) = knots[9];
                Increment(visited, $"{tx}-{ty}");
            }
        }
        return visited.Keys.Count();
    }

    private static (int, int) UpdateFollowerPart1(int hx, int hy, int tx, int ty)
    {
        if ((hx - tx) > 1)
        {
            tx = hx - 1;
            ty = hy;
        }
        if ((tx - hx) > 1)
        {
            tx = hx + 1;
            ty = hy;
        }
        if ((hy - ty) > 1)
        {
            ty = hy - 1;
            tx = hx;
        }
        if ((ty - hy) > 1)
        {
            ty = hy + 1;
            tx = hx;
        }
        return (tx, ty);
    }

    private static (int, int) UpdateFollowerPart2(int hx, int hy, int tx, int ty)
    {
        // Scenarios:
        //    A     B     C     D     E     F     G     H
        //  -----|-----|-----|-----|-----|-----|-----|-----|
        //  . H .|. H H|. . .|T . .|. T .|. . T|. . .|H H .|
        //  . - .|. - H|T - H|. - H|. - .|H - .|H - T|H - .|
        //  . T .|T . .|. . .|. H H|. H .|H H .|. . .|. . T|
        // Scenario A
        if ((hy - ty) == 2 & hx == tx)
        {
            ty++;
            return (tx, ty);
        }
        // Scenario B
        if (((hy - ty) == 2 & (hx - tx) >= 1) | ((hy - ty) == 1 & (hx - tx) == 2))
        {
            tx++;
            ty++;
            return (tx, ty);
        }
        // Scenario C
        if ((hx - tx) == 2 & hy == ty)
        {
            tx++;
        }
        // Scenario D
        if (((ty - hy) == 2 & (hx - tx) >= 1) | ((ty - hy) == 1 & (hx - tx) == 2))
        {
            tx++;
            ty--;
        }
        // Scenario E
        if ((ty - hy) > 1 & hx == tx)
        {
            ty = hy + 1;
        }
        // Scenario F
        if (((ty - hy) == 2 & (tx - hx) >= 1) | ((ty - hy) == 1 & (tx - hx) == 2))
        {
            tx--;
            ty--;
        }
        // Scenario G
        if ((tx - hx) >= 1 & hy == ty)
        {
            tx = hx + 1;
        }
        // Scenario H
        if (((hy - ty) == 2 & (tx - hx) >= 1) | ((hy - ty) == 1) & (tx - hx) == 2)
        {
            tx--;
            ty++;
        }
        return (tx, ty);
    }

    private static void Increment(Dictionary<string, int> dict, string key)
    {
        if (dict.ContainsKey(key))
            dict[key] += 1;
        else dict[key] = 1;
    }

    public static (string, int)[] GetData()
    {
        string[] split;
        Func<string, (string, int)> func = x =>
        {
            split = x.Trim().Split(" ");
            return (split[0], Convert.ToInt32(split[1]));
        };
        (string, int)[] data = File.ReadLines("Data/day9.txt")
                                   .Select(x => func(x))
                                   .ToArray();
        return data;
    }

}

public static class Day8
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 8");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        string[] data = File.ReadLines("Data/day8.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        int total = CountPerimeter(data);
        for (int row = 1; row < data[0].Count() - 1; row++)
            for (int col = 1; col < data.Count() - 1; col++)
                total += PointVisible(data, row, col);
        return total;
    }

    public static int Part2()
    {
        string[] data = File.ReadLines("Data/day8.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        List<int> scores = new();
        int val = 0;
        for (int row = 1; row < data[0].Count() - 1; row++)
            for (int col = 1; col < data.Count() - 1; col++)
            {
                val = TreesVisible(data, row, col);
                scores.Add(val);
            }
        int max = scores.Max();
        return max;
    }

    public static int CountPerimeter(string[] data)
    {
        return (data.Count() * 2) + (data[0].Count() * 2) - 4;
    }

    public static int PointVisible(string[] data, int row, int col)
    {
        bool visible;
        int pointVal = Convert.ToInt32(data[row][col] - '0');
        int[] above = Enumerable.Range(0, row)
                                .Select(x => Convert.ToInt32(data[x][col] - '0'))
                                .ToArray();
        visible = above.All(x => x < pointVal);
        if (visible) return 1;
        int[] below = Enumerable.Range(row + 1, data.Count() - row - 1)
                                .Select(x => Convert.ToInt32(data[x][col] - '0'))
                                .ToArray();
        visible = below.All(x => x < pointVal);
        if (visible) return 1;
        int[] right = Enumerable.Range(col + 1, data[0].Count() - col - 1)
                               .Select(x => Convert.ToInt32(data[row][x] - '0'))
                               .ToArray();
        visible = right.All(x => x < pointVal);
        if (visible) return 1;
        int[] left = Enumerable.Range(0, col)
                               .Select(x => Convert.ToInt32(data[row][x] - '0'))
                               .ToArray();
        visible = left.All(x => x < pointVal);
        if (visible) return 1;
        return 0;
    }

    public static int TreesVisible(string[] data, int row, int col)
    {
        int pointVal = Convert.ToInt32(data[row][col] - '0');
        // looking up
        int[] ups = Enumerable.Range(0, row)
                              .Select(x => Convert.ToInt32(data[x][col] - '0'))
                              .Reverse()
                              .ToArray();
        int upCount = CountVisible(ups, pointVal);
        // looking down
        int[] downs = Enumerable.Range(row + 1, data.Count() - row - 1)
                                .Select(x => Convert.ToInt32(data[x][col] - '0'))
                                .ToArray();
        int downCount = CountVisible(downs, pointVal);
        // looking left
        int[] lefts = Enumerable.Range(0, col)
                        .Select(x => Convert.ToInt32(data[row][x] - '0'))
                        .Reverse()
                        .ToArray();
        int leftCount = CountVisible(lefts, pointVal);
        // looking right
        int[] rights = Enumerable.Range(col + 1, data[0].Count() - col - 1)
                        .Select(x => Convert.ToInt32(data[row][x] - '0'))
                        .ToArray();
        int rightCount = CountVisible(rights, pointVal);
        int scenicScore = upCount * downCount * leftCount * rightCount;
        return scenicScore;
    }

    private static int CountVisible(int[] heights, int currentHeight)
    {
        int count = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] >= currentHeight)
            {
                count++;
                break;
            }
            count++;
        }
        return count;
    }
}

public static class Day7
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 7");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        Dictionary<string, int> dirs = ProcessDirectories();
        return dirs.Values.Where(x => x <= 100000).Sum();
    }

    public static int Part2()
    {
        Dictionary<string, int> dirs = ProcessDirectories();
        int spaceNeeded = 30000000 - (70000000 - dirs.Values.Max());
        int[] vals = dirs.Values
                         .Where(x => x >= spaceNeeded)
                         .OrderBy(x => x)
                         .ToArray();
        return vals[0];
    }

    public static Dictionary<string, int> ProcessDirectories()
    {
        string[] data = File.ReadLines("Data/day7.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        Dictionary<string, int> dirs = new();
        List<string> currentPath = new();
        List<string> buffer = new();
        string substr, key;
        foreach (string line in data)
        {
            if (line.StartsWith("dir")) continue;
            if (line.StartsWith("$") & buffer.Count != 0)
                ProcessBuffer(buffer, dirs, currentPath);
            if (line == "$ cd ..")
            {
                currentPath.RemoveAt(currentPath.Count - 1);
                continue;
            }
            if (line.StartsWith("$ cd"))
            {
                substr = line.Substring(5);
                currentPath.Add(substr);
                key = string.Join("-", currentPath);
                if (!dirs.ContainsKey(key)) dirs[key] = 0;
                continue;
            }
            if (line.StartsWith("$ ls")) continue;
            buffer.Add(line);
        }
        ProcessBuffer(buffer, dirs, currentPath);
        return dirs;
    }

    private static void ProcessBuffer(
        List<string> buffer,
        Dictionary<string, int> dirs,
        List<string> currentPath
    )
    {
        if (buffer.Count != 0)
        {
            string[] splits;
            int fileSize;
            List<string> tmp = new();
            string key;
            foreach (string buffline in buffer)
            {
                splits = buffline.Split();
                fileSize = Convert.ToInt32(splits[0]);
                tmp = new List<string>(currentPath);
                while (tmp.Count > 0)
                {
                    key = string.Join("-", tmp);
                    dirs[key] += fileSize;
                    if (tmp.Count > 0) tmp.RemoveAt(tmp.Count - 1);
                }
            }
            buffer.Clear();
        }
    }
}

public static class Day6
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 6");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {ProcessStream(offset: 4)}");
        Console.WriteLine($"Part 2: {ProcessStream(offset: 14)}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int ProcessStream(int offset)
    {
        string[] data = File.ReadLines("Data/day6.txt")
                           .Select(x => x.Trim())
                           .ToArray();
        string buffer = "";
        for (int idx = 0; idx < data[0].Length; idx++)
        {
            buffer = data[0].Substring(idx, offset);
            if (buffer.Distinct().Count() == offset)
                return idx + offset;
        }
        return 0;
    }
}

public static class Day5
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 5");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Day5.ProcessData()}");
        Console.WriteLine($"Part 2: {Day5.ProcessData(reverseBuffer: true)}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
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
