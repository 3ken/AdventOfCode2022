using Day07;

var file = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day07\Data.txt").ToList();

var currentPosition = new Node { Name = "/" };

CreateFileTree(file, currentPosition);
ResetToTopStartPosition(currentPosition);

var totalSize = CalculateTotalSize(currentPosition);

Console.WriteLine(totalSize);

void CreateFileTree(List<string> list, Node node)
{
    foreach (var line in list)
    {
        var splitLine = line.Split(" ");
        if (int.TryParse(splitLine[0], out var fileSize))
        {
            node.Branches.Add(new Node { Name = splitLine[1], Parent = node, Size = fileSize, Type = "file" });
        }

        if (splitLine[0] == "dir")
        {
            node.Branches.Add(new Node { Name = splitLine[1], Parent = node, Type = "dir" });
        }

        if (splitLine[0] == "$")
        {
            if (splitLine[1] == "cd" && line != "$ cd /")
            {
                if (splitLine[2] == ".." && node.Parent != null)
                {
                    node = node.Parent;
                }
                else
                {
                    node = node.Branches.First(b => b.Name == splitLine[2]);
                }
            }
        }
    }
}

void ResetToTopStartPosition(Node node)
{
    while (node.Parent != null)
    {
        node = node.Parent;
    }
}

int CalculateTotalSize(Node node)
{
    var totSize = 0;
    if (node.GetTotalSize() <= 100000)
        totSize += node.GetTotalSize();

    foreach (var branch in node.Branches)
    {
        if (branch.Type == "dir")
        {
            totSize += CalculateTotalSize(branch);
        }
    }

    return totSize;
}