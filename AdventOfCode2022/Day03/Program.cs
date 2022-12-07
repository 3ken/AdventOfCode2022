foreach (var line in File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day03\Data.txt"))
{
    var sum = 0;
    if (!string.IsNullOrEmpty(line))
    {
        var itemsInEachComp = line.Length / 2;
        var comp1 = line[.. itemsInEachComp];
        var comp2 = line[itemsInEachComp ..];
        var charInBoth = comp1.Intersect(comp2).First();
        sum += GetValue(charInBoth);
    }
    Console.WriteLine(sum);
}

int GetValue(char x)
{
    switch (x)
    {
        
    }
    return 0;
}