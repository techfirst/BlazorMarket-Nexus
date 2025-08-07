namespace Nexus.Models;

public class BreadcrumbItem
{
    public string Text { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
}