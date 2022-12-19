var stacks1 = new List<List<string>>();
var stacks2 = new List<List<string>>();
var file = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day05\Data.txt").ToList();

AddStackData(file, stacks1);
AddStackData(file, stacks2);

// 1
foreach (var line in file.Where(l => l.StartsWith("move ", StringComparison.Ordinal)))
{
    var stringSplit = line.Split(' ');
    var quantityToMove = int.Parse(stringSplit[1]);
    var from = int.Parse(stringSplit[3]);
    var to = int.Parse(stringSplit[5]);
    for (var i = 0; i < quantityToMove; i++)
    {
        stacks1[to - 1].Add(stacks1[from - 1].Last());
        stacks1[from - 1] = stacks1[from - 1].Take(stacks1[from - 1].Count - 1).ToList();
    }
}

var stringToWrite = stacks1.Aggregate("", (current, stack) => current + stack.Last());
Console.WriteLine(stringToWrite);

// 2
foreach (var line in file.Where(l => l.StartsWith("move ", StringComparison.Ordinal)))
{
    var stringSplit = line.Split(' ');
    var quantityToMove = int.Parse(stringSplit[1]);
    var from = int.Parse(stringSplit[3]);
    var to = int.Parse(stringSplit[5]);
    stacks2[to - 1].AddRange(stacks2[from - 1].Skip(Math.Max(0, stacks2[from - 1].Count - quantityToMove)).ToList());
    stacks2[from - 1] = stacks2[from - 1].Take(stacks2[from - 1].Count - quantityToMove).ToList();
}

stringToWrite = stacks2.Aggregate("", (current, stack) => current + stack.Last());
Console.WriteLine(stringToWrite);


void AddStackData(IList<string> list, ICollection<List<string>> list1)
{
    for (var j = 1; j < list[0].Length; j += 4)
    {
        var stack = new List<string>();
        for (var i = list.IndexOf(list.First(l => l.StartsWith(" 1", StringComparison.Ordinal))) - 1; i >= 0; i--)
        {
            if (list[i][j] != ' ')
            {
                stack.Add(list[i][j].ToString());
            }
        }

        list1.Add(stack);
    }
}