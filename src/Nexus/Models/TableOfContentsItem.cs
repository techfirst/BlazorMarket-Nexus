namespace Nexus.Models;

public class TableOfContentsItem
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Level { get; set; } = 2; // H2, H3, etc.
    public List<TableOfContentsItem> Children { get; set; } = new();
}