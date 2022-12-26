namespace Day07;

public class Node
{
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; } = 0;
    public Node? Parent { get; set; }
    public List<Node> Branches { get; set; } = new();

    public int GetTotalSize()
    {
        if(!Branches.Any())
            return 0;
        return Branches.Sum(b => b.Size);
    }

    public Node Copy()
    {
        return new Node { Name = this.Name, Size = this.Size, Parent = this.Parent, Branches = this.Branches };
    }
}