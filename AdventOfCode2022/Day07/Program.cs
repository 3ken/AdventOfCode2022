using Day07;

var file = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day07\Data.txt").ToList();

var currentPosition = new Node { Name = "/" };

CreateFileTree(file, currentPosition);
ResetToTopStartPosition(currentPosition);

var totalSize = CalculateTotalSize(currentPosition);

Console.WriteLine(totalSize);
Console.ReadLine();

void CreateFileTree(List<string> list, Node node)
{
    foreach (var line in list)
    {
        var splitLine = line.Split(" ");
        if (int.TryParse(splitLine[0], out var fileSize))
        {
            node.Branches.Add(new Node { Name = splitLine[1], Parent = node, Size = fileSize });
        }

        if (splitLine[0] == "dir")
        {
            node.Branches.Add(new Node { Name = splitLine[1], Parent = node });
        }

        if (splitLine[0] == "$")
        {
            if (splitLine[1] == "cd"  && line != "$ cd /")
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

int CalculateTotalSize(Node currentPosition)
{
    if (!currentPosition.Branches.Any() && currentPosition.Size <= 100000)
        return currentPosition.Size;
    if (!currentPosition.Branches.Any() && currentPosition.Size > 100000)
        return 0;

    var currentPositionBranchesSize = 0;
    foreach(var branch in currentPosition.Branches)
    {
        currentPositionBranchesSize += CalculateTotalSize(branch);
    }
    return currentPositionBranchesSize;
}