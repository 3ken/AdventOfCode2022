using Day07;

var file = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day07\Data.txt").ToList();

var currentPosition = new Node { Name = "/" };

CreateFileTree(file, currentPosition);
ResetToTopStartPosition(currentPosition);

var totalSize = CalculateTotalSize(currentPosition);

void CreateFileTree(List<string> list, Node node)
{
    foreach (var line in list)
    {
        var splitLine = line.Split(" ");
        if (splitLine[0] == "$" && line != "$ cd /")
        {
            if (splitLine[1] == "cd")
            {
                node = node.Branches.First(b => b.Name == splitLine[2]);
            }

            if (splitLine[1] == "ls")
            {
                if (splitLine[2] == ".." && node.Parent != null)
                {
                    node = node.Parent;
                }
            }
        }

        if (splitLine[0] == "dir")
        {
            node.Branches.Add(new Node { Name = splitLine[1], Parent = node });
        }

        if (int.TryParse(splitLine[0], out var fileSize))
        {
            node.Branches.Add(new Node { Name = splitLine[1], Parent = node, Size = fileSize });
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
    var totalSize = 0;
    while (currentPosition.GetTotalSize() > 10000)
    {
        
    }
}