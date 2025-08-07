namespace Nexus.Models;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Excerpt { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string FullContent { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string AuthorInitials { get; set; } = string.Empty;
    public string AuthorJobTitle { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public int ReadTimeMinutes { get; set; }
    public string FeaturedImageGradient { get; set; } = "from-nexus-blue to-nexus-blue-dark";
    public bool IsFeatured { get; set; }
    public List<string> Tags { get; set; } = new();
}

public static class BlogCategories
{
    public const string All = "All";
    public const string BusinessGrowth = "Business Growth";
    public const string Technology = "Technology";
    public const string Analytics = "Analytics";
    public const string Strategy = "Strategy";
    public const string Insights = "Industry Insights";
}