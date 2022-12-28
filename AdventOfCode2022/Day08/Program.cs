var file = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day08\Data.txt").ToList();

var treeMatrix = FormatDataToMatrix(file);

var visibleTreesFromOutside = CalculateVisibleTreesFromOutside(treeMatrix);

Console.WriteLine(visibleTreesFromOutside);

List<List<int>> FormatDataToMatrix(IEnumerable<string> fileLines)
{
    return fileLines.Select(line => line.Select(t => int.Parse(t.ToString())).ToList()).ToList();
}

int CalculateVisibleTreesFromOutside(List<List<int>> matrix)
{
    var visibleTrees = new List<string>();
    CalculateVisibleFromLeft(matrix, visibleTrees);
    CalculateVisibleFromRight(matrix, visibleTrees);
    CalculateVisibleFromTop(matrix, visibleTrees);
    CalculateVisibleFromBottom(matrix, visibleTrees);
    var outerVisibleTrees = CalculateOuterVisible(matrix);

    return visibleTrees.Distinct().Count() + outerVisibleTrees;
}

void CalculateVisibleFromLeft(List<List<int>> matrix, List<string> visibleTrees)
{
    var rows = matrix.Count;
    var columns = matrix[0].Count;
    for (var row = 0; row < rows; row++)
    {
        if (row == 0 || row == rows - 1) continue;
        var highestTreeInRow = matrix[row][0];
        for (var column = 0; column < columns; column++)
        {
            if (column == 0 || column == columns - 1) continue;
            if (matrix[row][column] <= highestTreeInRow) continue;
            visibleTrees.Add($"{row} {column}");
            highestTreeInRow = matrix[row][column];
        }
    }
}

void CalculateVisibleFromRight(List<List<int>> matrix, List<string> visibleTrees)
{
    var rows = matrix.Count;
    var columns = matrix[0].Count;
    for (var row = 0; row < rows; row++)
    {
        if (row == 0 || row == rows - 1) continue;
        var highestTreeInRow = matrix[row][columns - 1];
        for (var column = columns - 1; column >= 0; column--)
        {
            if (column == 0 || column == columns - 1) continue;
            if (matrix[row][column] <= highestTreeInRow) continue;
            visibleTrees.Add($"{row} {column}");
            highestTreeInRow = matrix[row][column];
        }
    }
}

void CalculateVisibleFromTop(List<List<int>> matrix, List<string> visibleTrees)
{
    var rows = matrix.Count;
    var columns = matrix[0].Count;
    for (var column = 0; column < columns; column++)
    {
        if (column == 0 || column == columns - 1) continue;
        var highestTreeInColumn = matrix[0][column];
        for (var row = 0; row < matrix.Count; row++)
        {
            if (row == 0 || row == matrix.Count - 1) continue;
            if (matrix[row][column] <= highestTreeInColumn) continue;
            visibleTrees.Add($"{row} {column}");
            highestTreeInColumn = matrix[row][column];
        }
    }
}

void CalculateVisibleFromBottom(List<List<int>> matrix, List<string> visibleTrees)
{
    var rows = matrix.Count;
    var columns = matrix[0].Count;
    for (var column = 0; column < columns; column++)
    {
        if (column == 0 || column == columns - 1) continue;
        var highestTreeInColumn = matrix[rows - 1][column];
        for (var row = rows - 1; row >= 0; row--)
        {
            if (row == 0 || row == rows - 1) continue;
            if (matrix[row][column] <= highestTreeInColumn) continue;
            visibleTrees.Add($"{row} {column}");
            highestTreeInColumn = matrix[row][column];
        }
    }
}

int CalculateOuterVisible(List<List<int>> matrix)
{
    return matrix.Count * 2 + (matrix[0].Count * 2 - 4);
}