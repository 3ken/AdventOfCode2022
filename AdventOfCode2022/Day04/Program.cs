var total = 0;

foreach (var line in File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day04\Data.txt"))
{
    if (!string.IsNullOrEmpty(line))
    {
        var pairs = line.Split(",");
        var range1 = pairs[0].Split("-");
        var range2 = pairs[1].Split("-");
        if (int.Parse(range1[0]) >= int.Parse(range2[0]) && int.Parse(range1[1]) <= int.Parse(range2[1])
            || int.Parse(range2[0]) >= int.Parse(range1[0]) && int.Parse(range2[1]) <= int.Parse(range1[1]))
        {
            total++;
        }
    }
}

Console.WriteLine(total);