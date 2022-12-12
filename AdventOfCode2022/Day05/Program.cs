var stacks = new List<List<char>>();
foreach (var line in File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day05\Data.txt"))
{
    if (!string.IsNullOrEmpty(line) && line.StartsWith(" ", StringComparison.Ordinal) || line.StartsWith("[", StringComparison.Ordinal))
    {
        if (line.StartsWith(" 1", StringComparison.Ordinal))
            break;
    }
}

