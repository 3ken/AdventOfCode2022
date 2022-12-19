var stacks = new List<List<string>>();
var file = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day05\Data.txt").ToList();

for (var j = 1; j < file[0].Length; j += 4)
{
    var stack = new List<string>();
    for (var i = file.IndexOf(file.First(l => l.StartsWith(" 1", StringComparison.Ordinal))) - 1; i >= 0; i--)
    {
        if (file[i][j] != ' ')
        {
            stack.Add(file[i][j].ToString());
        }
    }
    stacks.Add(stack);
}

foreach (var line in file.Where(l => l.StartsWith("move ", StringComparison.Ordinal)))
{
    var stringSplit = line.Split(' ');
    var quantityToMove = int.Parse(stringSplit[1]);
    var from = int.Parse(stringSplit[3]);
    var to = int.Parse(stringSplit[5]);
    for (var i = 0; i < quantityToMove; i++)
    {
        stacks[to - 1].Add(stacks[from - 1].Last());
        stacks[from - 1] = stacks[from - 1].Take(stacks[from - 1].Count - 1).ToList();
    }
}

var stringToWrite = stacks.Aggregate("", (current, stack) => current + stack.Last());
Console.WriteLine(stringToWrite);


