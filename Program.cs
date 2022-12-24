using System.Linq;

using CsML.Extensions;
using CsML.Graph;

Day20.Solution();

public static class Day20
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 20");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        List<int> numbers = File.ReadLines("Data/day20.txt")
                            .Select(x => Convert.ToInt32(x.Trim()))
                            .ToList();
        List<int> indeces = Enumerable.Range(0, numbers.Count).ToList();
        Console.WriteLine(indeces.Zip(numbers).OrderBy(x => x.First).Select(x => x.Second).Delimited());

        int workingNumberIndex = 0;
        int currentIndex = indeces[workingNumberIndex];
        int newIndex = currentIndex;
        int val = numbers[workingNumberIndex];
        if (val > 0)
            for (int i = 0; i < val; i++)
            {
                newIndex++;
                if (newIndex > (numbers.Count - 1))
                    newIndex = 0;
            }
        else
            for (int i = 0; i < Math.Abs(val); i++)
            {
                newIndex--;
                if (newIndex < 0)
                    newIndex = numbers.Count - 2;
            }
        if (newIndex > currentIndex)
        {
            int[] indecesToUpdate = indeces.Where(x => x > currentIndex & x <= newIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]--;
        }
        else
        {
            int[] indecesToUpdate = indeces.Where(x => x >= newIndex & x < currentIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]++;
        }
        indeces[workingNumberIndex] = newIndex;
        Console.WriteLine(indeces.Zip(numbers).OrderBy(x => x.First).Select(x => x.Second).Delimited());

        workingNumberIndex = 1;
        currentIndex = indeces[workingNumberIndex];
        newIndex = currentIndex;
        val = numbers[workingNumberIndex];
        if (val > 0)
            for (int i = 0; i < val; i++)
            {
                newIndex++;
                if (newIndex > (numbers.Count - 1))
                    newIndex = 0;
            }
        else
            for (int i = 0; i < Math.Abs(val); i++)
            {
                newIndex--;
                if (newIndex < 0)
                    newIndex = numbers.Count - 2;
            }
        if (newIndex > currentIndex)
        {
            int[] indecesToUpdate = indeces.Where(x => x > currentIndex & x <= newIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]--;
        }
        else
        {
            int[] indecesToUpdate = indeces.Where(x => x >= newIndex & x < currentIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]++;
        }
        indeces[workingNumberIndex] = newIndex;
        Console.WriteLine(indeces.Zip(numbers).OrderBy(x => x.First).Select(x => x.Second).Delimited());

        workingNumberIndex = 2;
        currentIndex = indeces[workingNumberIndex];
        newIndex = currentIndex;
        val = numbers[workingNumberIndex];
        if (val > 0)
            for (int i = 0; i < val; i++)
            {
                newIndex++;
                if (newIndex > (numbers.Count - 1))
                    newIndex = 0;
            }
        else
            for (int i = 0; i < Math.Abs(val); i++)
            {
                newIndex--;
                if (newIndex < 0)
                    newIndex = numbers.Count - 2;
            }
        if (newIndex > currentIndex)
        {
            int[] indecesToUpdate = indeces.Where(x => x > currentIndex & x <= newIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]--;
        }
        else
        {
            int[] indecesToUpdate = indeces.Where(x => x >= newIndex & x < currentIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]++;
        }
        indeces[workingNumberIndex] = newIndex;
        Console.WriteLine(indeces.Zip(numbers).OrderBy(x => x.First).Select(x => x.Second).Delimited());

        workingNumberIndex = 3;
        currentIndex = indeces[workingNumberIndex];
        newIndex = currentIndex;
        val = numbers[workingNumberIndex];
        if (val > 0)
            for (int i = 0; i < val; i++)
            {
                newIndex++;
                if (newIndex > (numbers.Count - 1))
                    newIndex = 0;
            }
        else
            for (int i = 0; i < Math.Abs(val); i++)
            {
                newIndex--;
                if (newIndex < 0)
                    newIndex = numbers.Count - 2;
            }
        if (newIndex > currentIndex)
        {
            int[] indecesToUpdate = indeces.Where(x => x > currentIndex & x <= newIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]--;
        }
        else
        {
            int[] indecesToUpdate = indeces.Where(x => x >= newIndex & x < currentIndex).ToArray();
            foreach (int i in indecesToUpdate)
                indeces[indeces.IndexOf(i)]++;
        }
        indeces[workingNumberIndex] = newIndex;
        Console.WriteLine(indeces.Zip(numbers).OrderBy(x => x.First).Select(x => x.Second).Delimited());


        return 0;
    }

    public static int Part2()
    {
        return 0;
    }

}

public static class Day19
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 19");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        return 0;
    }

    public static int Part2()
    {
        return 0;
    }

}

public static class Day18
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 15");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        // Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        string[] data = File.ReadLines("Data/day18.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        (int, int, int)[] points = data
                .Select(x => x.Split(","))
                .Select(x => (Convert.ToInt32(x[0]), Convert.ToInt32(x[1]), Convert.ToInt32(x[2])))
                .ToArray();
        int maxX = points.Select(x => x.Item1).Max();
        int maxY = points.Select(x => x.Item2).Max();
        int maxZ = points.Select(x => x.Item3).Max();
        int[,,] space = new int[maxZ + 2, maxY + 2, maxX + 2];
        int surface = 0;
        foreach (var point in points)
            space[point.Item3, point.Item2, point.Item1] = 1;
        for (int z = 0; z <= maxZ; z++)
            for (int y = 0; y <= maxY; y++)
                for (int x = 0; x <= maxX; x++)
                {
                    if (space[z, y, x] != 1) continue;

                    if (z == 0) surface++;
                    else if (space[z - 1, y, x] == 0) surface++;
                    if (space[z + 1, y, x] == 0) surface++;

                    if (y == 0) surface++;
                    else if (space[z, y - 1, x] == 0) surface++;
                    if (space[z, y + 1, x] == 0) surface++;

                    if (x == 0) surface++;
                    else if (space[z, y, x - 1] == 0) surface++;
                    if (space[z, y, x + 1] == 0) surface++;
                }
        return surface;
    }

    public static int Part2()
    {
        // Get data
        string[] data = File.ReadLines("Data/day18.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        // Convert data to 3d points
        (int, int, int)[] points = data
                .Select(x => x.Split(","))
                .Select(x => (Convert.ToInt32(x[0]), Convert.ToInt32(x[1]), Convert.ToInt32(x[2])))
                .ToArray();
        // Get space dimension and create a 3d matrix
        int maxX = points.Select(x => x.Item1).Max();
        int maxY = points.Select(x => x.Item2).Max();
        int maxZ = points.Select(x => x.Item3).Max();
        int[,,] space = new int[maxZ + 2, maxY + 2, maxX + 2];
        int surface = 0;
        // Fill space with rock locations
        foreach (var point in points)
            space[point.Item3, point.Item2, point.Item1] = 1;
        // Count the outside surfaces
        for (int z = 0; z <= maxZ; z++)
            for (int y = 0; y <= maxY; y++)
                for (int x = 0; x <= maxX; x++)
                {
                    if (space[z, y, x] != 1) continue;

                    if (z == 0) surface++;
                    else if (space[z - 1, y, x] == 0) surface++;
                    if (space[z + 1, y, x] == 0) surface++;

                    if (y == 0) surface++;
                    else if (space[z, y - 1, x] == 0) surface++;
                    if (space[z, y + 1, x] == 0) surface++;

                    if (x == 0) surface++;
                    else if (space[z, y, x - 1] == 0) surface++;
                    if (space[z, y, x + 1] == 0) surface++;
                }
        // Create a graph to find locations water cannot reach
        Graph<string> graph = new();
        List<string> nodes = new();
        for (int z = 0; z <= maxZ + 3; z++)
            for (int y = 0; y <= maxY + 3; y++)
                for (int x = 0; x <= maxX + 3; x++)
                    nodes.Add($"{z}-{y}-{x}");
        graph.AddNodes(nodes.ToArray());
        // Console.WriteLine(graph.nodes.Delimited());
        string currentNode, nextNode;
        for (int z = 0; z <= maxZ; z++)
            for (int y = 0; y <= maxY; y++)
                for (int x = 0; x <= maxX; x++)
                {
                    if (space[z, y, x] == 1) continue;
                    currentNode = $"{z}-{y}-{x}";
                    if (z != 0)
                        if (space[z - 1, y, x] == 0)
                        {
                            nextNode = $"{z - 1}-{y}-{x}";
                            graph.UpdateEdge(currentNode, nextNode, undirected: true);
                        }
                    if (space[z + 1, y, x] == 0)
                    {
                        nextNode = $"{z + 1}-{y}-{x}";
                        graph.UpdateEdge(currentNode, nextNode, undirected: true);
                    }
                    if (y != 0)
                        if (space[z, y - 1, x] == 0)
                        {
                            nextNode = $"{z}-{y - 1}-{x}";
                            graph.UpdateEdge(currentNode, nextNode, undirected: true);
                        }
                    if (space[z, y + 1, x] == 0)
                    {
                        nextNode = $"{z}-{y + 1}-{x}";
                        graph.UpdateEdge(currentNode, nextNode, undirected: true);
                    }
                    if (x != 0)
                        if (space[z, y, x - 1] == 0)
                        {
                            nextNode = $"{z}-{y}-{x - 1}";
                            graph.UpdateEdge(currentNode, nextNode, undirected: true);
                        }
                    if (space[z, y, x + 1] == 0)
                    {
                        nextNode = $"{z}-{y}-{x + 1}";
                        graph.UpdateEdge(currentNode, nextNode, undirected: true);
                    }
                }

        // Find all dry nodes
        string firstWater = "0-0-0";
        string[] waterNodes = graph.WalkDepthFirst(firstWater, includeBacktrack: false);
        // Console.WriteLine(waterNodes.Length);
        List<string> dryNodes = new();
        for (int z = 0; z <= maxZ; z++)
            for (int y = 0; y <= maxY; y++)
                for (int x = 0; x <= maxX; x++)
                {
                    if (space[z, y, x] == 1) continue;
                    currentNode = $"{z}-{y}-{x}";
                    if (waterNodes.Contains(currentNode)) continue;
                    dryNodes.Add(currentNode);
                }
        // Console.WriteLine(dryNodes.Delimited(delimiter: "\n"));
        // Calculate space not reachable by water
        string[] split;
        int inner = 0;
        foreach (string dryNode in dryNodes)
        {
            split = dryNode.Split("-");
            int z = Convert.ToInt32(split[0]);
            int y = Convert.ToInt32(split[1]);
            int x = Convert.ToInt32(split[2]);

            if (space[z - 1, y, x] == 1) inner++;
            if (space[z + 1, y, x] == 1) inner++;
            if (space[z, y - 1, x] == 1) inner++;
            if (space[z, y + 1, x] == 1) inner++;
            if (space[z, y, x - 1] == 1) inner++;
            if (space[z, y, x + 1] == 1) inner++;
        }
        // Deduct space not reachable by water
        return surface - inner;
    }
}

public static class Day17
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 15");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        return 0;
    }

    public static int Part2()
    {
        return 0;
    }

}

public static class Day16
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 16");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        (Graph<string> graph, Dictionary<string, int> flows) = BuildGraph();
        string[] path;

        path = Walk(graph, flows, "AA");
        Console.WriteLine(path.Delimited());
        Console.WriteLine(DoPath(path, graph, flows));

        path = new string[] { "AA", "DD", "CC", "BB", "AA", "II", "JJ", "II", "AA", "DD", "EE", "FF", "GG", "HH", "GG", "FF", "EE", "DD", "CC" };
        Console.WriteLine(path.Delimited());
        return DoPath(path, graph, flows);
    }

    public static int Part2()
    {
        return 0;
    }

    public static string[] Walk(Graph<string> graph, Dictionary<string, int> flows, string start)
    {
        int idx = graph.nodes.IndexOf(start);
        int maxSearchSteps = 1_000_000;
        List<int> path = new();
        bool[] visited = Enumerable.Repeat(false, graph.nodes.Count).ToArray();
        Stack<int> stack = new();
        int[] unvisitedNeighbours, neighbours;
        int newIdx, pathIdx, steps = 0;
        while (steps <= maxSearchSteps)
        {
            // Visit the node
            path.Add(idx);
            if (!visited[idx]) visited[idx] = true;
            // Check the neighbhours
            neighbours = graph.Neighbours(idx);
            unvisitedNeighbours = neighbours.Where(x => !visited[x]).ToArray();
            if (unvisitedNeighbours.Length == 0 & stack.Count == 0)
                break;
            // Add unvisited neighbours to the top of stack
            unvisitedNeighbours = unvisitedNeighbours.OrderByDescending(x => flows[graph.nodes[x]]).ToArray();
            foreach (int val in unvisitedNeighbours)
                if (!stack.Contains(val)) stack.Push(val);
            // Visit the top of the stack 
            newIdx = stack.Pop();
            // If not possible to visit the top of the stack backtrack
            if (!neighbours.Contains(newIdx))
            {
                pathIdx = path.Count - 1;
                while (pathIdx > 0)
                {
                    pathIdx--;
                    path.Add(path[pathIdx]);
                    if (graph.Neighbours(path[pathIdx]).Contains(newIdx))
                        break;
                }
            }
            idx = newIdx;
            steps++;
        }
        return path.Select(x => graph.nodes[x]).ToArray();
    }

    public static int DoPath(string[] path, Graph<string> graph, Dictionary<string, int> flows)
    {
        List<string> onValves = new();
        int totalPressure = 0, pressure;
        int pathidx = 0;
        string step = path[pathidx];
        string[] bigs = graph.nodes.Where(x => flows[x] > 10).ToArray();
        for (int mins = 1; mins <= 30; mins++)
        {
            pressure = onValves.Select(x => flows[x]).Sum();
            totalPressure += pressure;
            if (!onValves.Contains(step) & flows[step] != 0)
            {
                if (bigs.Contains(step))
                {
                    onValves.Add(step);
                    bigs = bigs.Where(x => x != step).ToArray();
                    // Console.WriteLine($"min {mins} open {step} pressure {pressure}");
                    continue;
                }
                if (bigs.Length == 0)
                {
                    onValves.Add(step);
                    // Console.WriteLine($"min {mins} open {step} pressure {pressure}");
                    continue;
                }
            }
            if (pathidx < path.Length - 1) pathidx++;
            step = path[pathidx];
            // Console.WriteLine($"min {mins} move to {step} pressure {pressure} valves open {onValves.Delimited()}");
        }
        return totalPressure;
    }

    public static (Graph<string>, Dictionary<string, int>) BuildGraph()
    {
        Graph<string> graph = new();
        Dictionary<string, int> flows = new();
        string[] data = File.ReadLines("Data/day16.txt")
                            .Select(x => x.Trim())
                            .ToArray();
        List<string> nodes = new();
        List<(string, string)> edges = new();
        string[] splits;
        string nodeName, leadsTo;
        int offset;
        foreach (string row in data)
        {
            nodeName = row.Substring(6, 2);
            nodes.Add(nodeName);
            splits = row.Split("; ");
            offset = splits[1].Contains("valves") ? 23 : 22;
            leadsTo = splits[1].Substring(offset);
            if (leadsTo.Length == 2) edges.Add((nodeName, leadsTo));
            else foreach (string itm in leadsTo.Split(", "))
                    edges.Add((nodeName, itm.Trim()));
            flows[nodeName] = Convert.ToInt32(splits[0].Substring(23));
        }
        // Console.WriteLine(flows.Keys.Zip(flows.Values).Delimited());
        // Console.WriteLine(nodes.Delimited());
        // Console.WriteLine(edges.Delimited());
        graph.AddNodes(nodes.ToArray());
        graph.UpdateEdges(edges.ToArray(), undirected: true);
        return (graph, flows);
    }
}

public static class Day15
{
    public static void Solution()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Advent of Code 2022 Day 15");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public static int Part1()
    {
        return 0;
    }

    public static int Part2()
    {
        return 0;
    }

}

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
        (int minX, int maxX, int minY, int maxY) = GetDimensions(lines);
        int width = maxX - minX + 1;
        int height = maxY - minY + 1;
        int[,] matrix = new int[height, width];
        foreach (var line in lines) AddRock(matrix, line, minX, minY);
        // PrintMatrix(matrix);
        int result = CountSandPart1(matrix, minX, maxY);
        // PrintMatrix(matrix);
        return result;
    }

    public static int Part2()
    {
        List<(int, int)[]> lines = GetLines();
        (int minX, int maxX, int minY, int maxY) = GetDimensions(lines);
        minX = 0;
        maxX += 500;
        maxY += 2;
        int width = maxX - minX + 1;
        int height = maxY - minY + 1;
        int[,] matrix = new int[height, width];
        lines.Add(new (int, int)[] { (minX, maxY), (maxX, maxY) });
        foreach (var line in lines) AddRock(matrix, line, minX, minY);
        int result = CountSandPart2(matrix, minX, maxY);
        return result;
    }

    public static int CountSandPart2(int[,] matrix, int minX, int maxY)
    {
        int atRest = 0;
        bool flowingOut = false, grainMoving;
        int x, y, nextY, downVal, downLeftVal, downRightVal;
        while (!flowingOut)
        {
            x = 500 - minX;
            y = 0;
            grainMoving = true;
            while (grainMoving)
            {
                nextY = y + 1;
                downVal = matrix[nextY, x];
                if (downVal == 0) { y++; continue; }
                if (downVal != 0)
                {
                    downLeftVal = matrix[nextY, x - 1];
                    if (downLeftVal == 0)
                    {
                        x = x - 1;
                        y = nextY;
                        continue;
                    }
                    downRightVal = matrix[nextY, x + 1];
                    if (downRightVal == 0)
                    {
                        x = x + 1;
                        y = nextY;
                        continue;
                    }
                    matrix[y, x] = 2;
                    atRest += 1;
                    grainMoving = false;
                }
            }
            if ((x == 500 - minX) & y == 0) flowingOut = true;
        }
        return atRest;
    }

    public static int CountSandPart1(int[,] matrix, int minX, int maxY)
    {
        int atRest = 0;
        bool flowingOut = false, grainMoving;
        int x, y, nextY, downVal, downLeftVal, downRightVal;
        while (!flowingOut)
        {
            x = 500 - minX;
            y = 0;
            grainMoving = true;
            while (grainMoving)
            {
                nextY = y + 1;
                if (y > maxY | nextY > maxY)
                {
                    flowingOut = true;
                    break;
                }
                downVal = matrix[nextY, x];
                if (downVal == 0) { y++; continue; }
                if (downVal != 0)
                {
                    if ((x - 1) < 0 | (x > matrix.GetLength(1)))
                    {
                        flowingOut = true;
                        break;
                    }
                    downLeftVal = matrix[nextY, x - 1];
                    if (downLeftVal == 0)
                    {
                        x = x - 1;
                        y = nextY;
                        continue;
                    }
                    downRightVal = matrix[nextY, x + 1];
                    if (downRightVal == 0)
                    {
                        x = x + 1;
                        y = nextY;
                        continue;
                    }
                    matrix[y, x] = 2;
                    atRest += 1;
                    grainMoving = false;
                }
            }
        }
        return atRest;
    }

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
            if (curY == nextY)
            {
                if (curX <= nextX)
                    for (int x = curX; x <= nextX; x++)
                        matrix[curY - yoffset, x - xoffset] = 1;
                if (curX > nextX)
                    for (int x = nextX; x <= curX; x++)
                        matrix[curY - yoffset, x - xoffset] = 1;
            }
            else
            {
                if (curY <= nextY)
                    for (int y = curY; y <= nextY; y++)
                        matrix[y - yoffset, curX - xoffset] = 1;
                if (curY > nextY)
                    for (int y = nextY; y <= curY; y++)
                        matrix[y - yoffset, curX - xoffset] = 1;

            }
        }
    }

    public static (int, int, int, int) GetDimensions(List<(int, int)[]> lines)
    {
        int minX = int.MaxValue, maxX = int.MinValue;
        int maxY = int.MinValue;
        foreach (var line in lines)
            foreach ((int xval, int yval) in line)
            {
                if (xval < minX) minX = xval;
                if (xval > maxX) maxX = xval;
                if (yval > maxY) maxY = yval;
            }
        return (minX, maxX, 0, maxY);
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
        return 0;
    }
    public static int Part2()
    {
        return 0;
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
                        graph.UpdateEdge(fromNode: currentNode, toNode: nextNode, undirected: true);
                }
                // Down
                if (row < data.Length - 1)
                {
                    nextNode = $"{row + 1}-{col}";
                    nextChar = data[row + 1][col].ToString();
                    if (AllowedChars(currentChar).Contains(nextChar))
                        graph.UpdateEdge(fromNode: currentNode, toNode: nextNode, undirected: true);
                }
                // Left
                if (col > 0)
                {
                    nextNode = $"{row}-{col - 1}";
                    nextChar = data[row][col - 1].ToString();
                    if (AllowedChars(currentChar).Contains(nextChar))
                        graph.UpdateEdge(fromNode: currentNode, toNode: nextNode, undirected: true);
                }
                // Right
                if (col < data[0].Count() - 1)
                {
                    nextNode = $"{row}-{col + 1}";
                    nextChar = data[row][col + 1].ToString();
                    if (AllowedChars(currentChar).Contains(nextChar))
                        graph.UpdateEdge(fromNode: currentNode, toNode: nextNode, undirected: true);
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

    public static long Part2()
    {
        List<Monkey> monkeys = GetMonkeys();
        long mod = monkeys.Select(x => x.divisibleBy).Product();
        int rounds = 10_000;
        for (int r = 0; r < rounds; r++)
        {
            foreach (var monkey in monkeys) monkey.PlayRoundPart2(monkeys, mod);
        }
        // foreach (var monkey in monkeys) Console.WriteLine(monkey);
        long[] counts = monkeys.Select(x => (long)x.inspectionCount).ToArray();
        counts = counts.OrderByDescending(x => x).ToArray();
        return counts[0] * counts[1];
    }

    public class Monkey
    {
        public List<long> items;
        public Func<long, long> operation = x => x;
        public string operationString;
        public int divisibleBy;
        public int monkeyOnTrue;
        public int monkeyOnFalse;
        public int worryLevel;
        public int inspectionCount;

        public Monkey(
            long[] items,
            string operationString,
            int divisibleBy,
            int monkeyOnTrue,
            int monkeyOnFalse
        )
        {
            this.items = new List<long>(items);
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
            long worry;
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

        public void PlayRoundPart2(List<Monkey> monkeys, long mod)
        {
            long worry;
            foreach (int item in items)
            {
                worry = operation(item);
                // worry /= 3;
                worry %= mod;
                if ((worry % divisibleBy) == 0)
                    monkeys[monkeyOnTrue].items.Add(worry);
                else monkeys[monkeyOnFalse].items.Add(worry);
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
        long[] items = { };
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
                             .Select(x => (long)Convert.ToInt32(x))
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
