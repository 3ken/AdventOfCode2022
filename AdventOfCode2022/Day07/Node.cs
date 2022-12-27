namespace Day07;

public class Node
{
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; }
    public Node? Parent { get; set; }
    public List<Node> Branches { get; set; } = new();
    public string Type { get; set; } = string.Empty;

    public int GetTotalSize()
    {
        return Type == "file" ? Size : Branches.Sum(b => b.GetTotalSize());
    }
}