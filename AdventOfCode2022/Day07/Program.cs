using Day07;

var file = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day07\Data.txt").ToList();

var currentPosition = new Node { Name = "/" };

CreateFileTree(file, currentPosition);
ResetToTopStartPosition(currentPosition);

var totalFileSystemSize = currentPosition.GetTotalSize();
var answerOne = CalculateTotalSizeOfAllDirectoriesWithSizeLessThan100000(currentPosition);
var answerTwo = GetSizeOfDirectoryToDelete(currentPosition, totalFileSystemSize);

Console.WriteLine(answerOne);
Console.WriteLine(answerTwo);

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

        if (splitLine[0] != "$") continue;
        if (splitLine[1] != "cd" || line == "$ cd /") continue;
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

void ResetToTopStartPosition(Node node)
{
    while (node.Parent != null)
    {
        node = node.Parent;
    }
}

int CalculateTotalSizeOfAllDirectoriesWithSizeLessThan100000(Node node)
{
    var totSize = 0;
    if (node.GetTotalSize() <= 100000)
        totSize += node.GetTotalSize();

    totSize += node.Branches.Where(branch => branch.Type == "dir").Sum(CalculateTotalSizeOfAllDirectoriesWithSizeLessThan100000);

    return totSize;
}

int GetSizeOfDirectoryToDelete(Node node, int filesystemSize)
{
    var directorySizes = new List<int>();
    GetAllBranchDirectorySizes(node, directorySizes);
    return CalculateWhatDirectoryToDelete(directorySizes, filesystemSize);
}

void GetAllBranchDirectorySizes(Node node, List<int> directorySizes)
{
    foreach (var branch in node.Branches.Where(branch => branch.Type == "dir"))
    {
        directorySizes.Add(branch.GetTotalSize());
        GetAllBranchDirectorySizes(branch, directorySizes);
    }
}

int CalculateWhatDirectoryToDelete(List<int> directorySizes, int filesystemSize)
{
    var bestSizeToDelete = 0;
    var bestSizeYet = int.MaxValue;
    var spaceNeeded = 30000000;
    var totalFileSystem = 70000000;
    foreach (var directorySize in directorySizes)
    {
        var fileSystemSizeAfterDeletion = totalFileSystem - filesystemSize + directorySize;
        if (fileSystemSizeAfterDeletion < spaceNeeded) continue;

        var diff = fileSystemSizeAfterDeletion - spaceNeeded;
        if (diff >= bestSizeYet) continue;
        bestSizeYet = diff;
        bestSizeToDelete = directorySize;
    }

    return bestSizeToDelete;
}