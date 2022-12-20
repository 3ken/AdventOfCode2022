namespace Day07;

public class Node
{
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; } = 0;
    public Node? Parent { get; set; }
    public List<Node> Branches { get; set; } = new();

    public int GetTotalSize()
    {
        return Branches.Sum(b => b.Size);
    }
}