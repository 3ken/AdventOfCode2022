var valueDict = new Dictionary<char, int>
{
    { 'a', 1 },
    { 'b', 2 },
    { 'c', 3 },
    { 'd', 4 },
    { 'e', 5 },
    { 'f', 6 },
    { 'g', 7 },
    { 'h', 8 },
    { 'i', 9 },
    { 'j', 10 },
    { 'k', 11 },
    { 'l', 12 },
    { 'm', 13 },
    { 'n', 14 },
    { 'o', 15 },
    { 'p', 16 },
    { 'q', 17 },
    { 'r', 18 },
    { 's', 19 },
    { 't', 20 },
    { 'u', 21 },
    { 'v', 22 },
    { 'w', 23 },
    { 'x', 24 },
    { 'y', 25 },
    { 'z', 26 },
    { 'A', 27 },
    { 'B', 28 },
    { 'C', 29 },
    { 'D', 30 },
    { 'E', 31 },
    { 'F', 32 },
    { 'G', 33 },
    { 'H', 34 },
    { 'I', 35 },
    { 'J', 36 },
    { 'K', 37 },
    { 'L', 38 },
    { 'M', 39 },
    { 'N', 40 },
    { 'O', 41 },
    { 'P', 42 },
    { 'Q', 43 },
    { 'R', 44 },
    { 'S', 45 },
    { 'T', 46 },
    { 'U', 47 },
    { 'V', 48 },
    { 'W', 49 },
    { 'X', 50 },
    { 'Y', 51 },
    { 'Z', 52 }
};

var sum = 0;
var lines = new List<string>();
var badgesSum = 0;

foreach (var line in File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day03\Data.txt"))
{
    lines.Add(line);
    if (!string.IsNullOrEmpty(line))
    {
        var itemsInEachComp = line.Length / 2;
        var comp1 = line[.. itemsInEachComp];
        var comp2 = line[itemsInEachComp ..];
        var charInBoth = comp1.Intersect(comp2).First();
        sum += valueDict[charInBoth];
    }
}

for (var i = 0; i < lines.Count; i = i + 3)
{
    var badge = lines[i].Intersect(lines[i + 1]).Intersect(lines[i + 2]).First();
    badgesSum += valueDict[badge];
}

Console.WriteLine(sum);
Console.WriteLine(badgesSum);

