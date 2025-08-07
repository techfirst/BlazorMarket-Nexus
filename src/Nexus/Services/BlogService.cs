using Nexus.Models;

namespace Nexus.Services;

public class BlogService
{
    private readonly List<BlogPost> _blogPosts;

    public BlogService()
    {
        _blogPosts = GenerateSampleBlogPosts();
    }

    public async Task<List<BlogPost>> GetAllPostsAsync()
    {
        await Task.Delay(50); // Simulate async operation
        return _blogPosts.OrderByDescending(p => p.PublishedDate).ToList();
    }

    public async Task<List<BlogPost>> GetPostsByCategoryAsync(string category)
    {
        await Task.Delay(50);
        
        if (category == BlogCategories.All)
            return await GetAllPostsAsync();
            
        return _blogPosts
            .Where(p => p.Category == category)
            .OrderByDescending(p => p.PublishedDate)
            .ToList();
    }

    public async Task<List<BlogPost>> SearchPostsAsync(string searchTerm)
    {
        await Task.Delay(50);
        
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllPostsAsync();
            
        return _blogPosts
            .Where(p => p.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                       p.Excerpt.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                       p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(p => p.PublishedDate)
            .ToList();
    }

    public async Task<BlogPost?> GetPostBySlugAsync(string slug)
    {
        await Task.Delay(50);
        return _blogPosts.FirstOrDefault(p => p.Slug == slug);
    }

    public async Task<List<BlogPost>> GetRelatedPostsAsync(string currentSlug, string category, int count = 3)
    {
        await Task.Delay(50);
        
        return _blogPosts
            .Where(p => p.Slug != currentSlug && p.Category == category)
            .OrderByDescending(p => p.PublishedDate)
            .Take(count)
            .ToList();
    }

    public List<TableOfContentsItem> GenerateTableOfContents(string content)
    {
        // Simple mock implementation - in real app would parse HTML content
        return new List<TableOfContentsItem>
        {
            new() { Id = "introduction", Title = "Introduction", Level = 2 },
            new() { Id = "key-features", Title = "Key Features", Level = 2 },
            new() { Id = "implementation", Title = "Implementation Details", Level = 2 },
            new() { Id = "best-practices", Title = "Best Practices", Level = 3 },
            new() { Id = "conclusion", Title = "Conclusion", Level = 2 }
        };
    }

    public int CalculateReadingTime(string content)
    {
        // Rough calculation: 200 words per minute
        var wordCount = content.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        return Math.Max(1, (int)Math.Ceiling(wordCount / 200.0));
    }

    public List<string> GetAllCategories()
    {
        return new List<string>
        {
            BlogCategories.All,
            BlogCategories.BusinessGrowth,
            BlogCategories.Technology,
            BlogCategories.Analytics,
            BlogCategories.Strategy,
            BlogCategories.Insights
        };
    }

    private static List<BlogPost> GenerateSampleBlogPosts()
    {
        return new List<BlogPost>
        {
            new()
            {
                Id = 1,
                Title = "10 Strategies to Scale Your Business in 2024",
                Slug = "10-strategies-scale-business-2024",
                Excerpt = "Discover proven methods to accelerate your business growth and reach new heights in the coming year with these actionable strategies.",
                Content = "Content for scaling business strategies...",
                FullContent = GenerateSampleContent("scaling", "business strategies"),
                Category = BlogCategories.BusinessGrowth,
                Author = "Sarah Chen",
                AuthorInitials = "SC",
                AuthorJobTitle = "Lead Growth Strategist",
                PublishedDate = DateTime.Now.AddDays(-2),
                ReadTimeMinutes = 8,
                FeaturedImageGradient = "from-nexus-blue to-nexus-blue-dark",
                IsFeatured = true,
                Tags = new() { "Growth", "Strategy", "Scaling" }
            },
            new()
            {
                Id = 2,
                Title = "The Future of Digital Transformation",
                Slug = "future-digital-transformation",
                Excerpt = "How emerging technologies are reshaping the way businesses operate and compete in the digital age.",
                Content = "Content about digital transformation...",
                FullContent = GenerateSampleContent("digital transformation", "emerging technologies"),
                Category = BlogCategories.Technology,
                Author = "Michael Rodriguez",
                AuthorInitials = "MR",
                AuthorJobTitle = "Senior Technology Consultant",
                PublishedDate = DateTime.Now.AddDays(-5),
                ReadTimeMinutes = 12,
                FeaturedImageGradient = "from-green-400 to-blue-500",
                IsFeatured = false,
                Tags = new() { "Digital", "Technology", "Innovation" }
            },
            new()
            {
                Id = 3,
                Title = "Making Data-Driven Decisions That Matter",
                Slug = "data-driven-decisions-matter",
                Excerpt = "Learn how to leverage analytics and insights to make smarter business decisions that drive real results.",
                Content = "Content about data-driven decisions...",
                FullContent = GenerateSampleContent("data analytics", "business intelligence"),
                Category = BlogCategories.Analytics,
                Author = "Jennifer Park",
                AuthorInitials = "JP",
                AuthorJobTitle = "Data Analytics Director",
                PublishedDate = DateTime.Now.AddDays(-7),
                ReadTimeMinutes = 6,
                FeaturedImageGradient = "from-purple-400 to-pink-500",
                IsFeatured = false,
                Tags = new() { "Data", "Analytics", "Decision Making" }
            },
            new()
            {
                Id = 4,
                Title = "Building a Customer-Centric Culture",
                Slug = "building-customer-centric-culture",
                Excerpt = "Transform your organization by putting customers at the heart of everything you do. Learn practical steps to build lasting relationships.",
                Content = "Content about customer-centric culture...",
                Category = BlogCategories.Strategy,
                Author = "David Kim",
                AuthorInitials = "DK",
                AuthorJobTitle = "Customer Experience Manager",
                PublishedDate = DateTime.Now.AddDays(-10),
                ReadTimeMinutes = 10,
                FeaturedImageGradient = "from-orange-400 to-red-500",
                IsFeatured = false,
                Tags = new() { "Customer", "Culture", "Strategy" }
            },
            new()
            {
                Id = 5,
                Title = "The Rise of Remote Work: Best Practices",
                Slug = "rise-remote-work-best-practices",
                Excerpt = "Navigate the future of work with proven strategies for building effective remote teams and maintaining productivity.",
                Content = "Content about remote work practices...",
                Category = BlogCategories.Insights,
                Author = "Emily Watson",
                AuthorInitials = "EW",
                AuthorJobTitle = "Remote Work Specialist",
                PublishedDate = DateTime.Now.AddDays(-12),
                ReadTimeMinutes = 9,
                FeaturedImageGradient = "from-teal-400 to-green-500",
                IsFeatured = false,
                Tags = new() { "Remote Work", "Productivity", "Teams" }
            },
            new()
            {
                Id = 6,
                Title = "AI and Machine Learning in Small Business",
                Slug = "ai-machine-learning-small-business",
                Excerpt = "Discover how artificial intelligence and machine learning can transform small businesses without breaking the budget.",
                Content = "Content about AI in small business...",
                Category = BlogCategories.Technology,
                Author = "Alex Thompson",
                AuthorInitials = "AT",
                AuthorJobTitle = "AI Solutions Architect",
                PublishedDate = DateTime.Now.AddDays(-15),
                ReadTimeMinutes = 11,
                FeaturedImageGradient = "from-indigo-400 to-purple-500",
                IsFeatured = false,
                Tags = new() { "AI", "Machine Learning", "Small Business" }
            },
            new()
            {
                Id = 7,
                Title = "Understanding Your Market: Research Methods",
                Slug = "understanding-market-research-methods",
                Excerpt = "Master the art of market research with these proven methods to understand your customers and competition better.",
                Content = "Content about market research...",
                Category = BlogCategories.Analytics,
                Author = "Lisa Zhang",
                AuthorInitials = "LZ",
                AuthorJobTitle = "Market Research Analyst",
                PublishedDate = DateTime.Now.AddDays(-18),
                ReadTimeMinutes = 7,
                FeaturedImageGradient = "from-pink-400 to-rose-500",
                IsFeatured = false,
                Tags = new() { "Market Research", "Analytics", "Competition" }
            },
            new()
            {
                Id = 8,
                Title = "Sustainable Business Practices for Growth",
                Slug = "sustainable-business-practices-growth",
                Excerpt = "Learn how sustainable business practices can drive long-term growth while making a positive impact on society.",
                Content = "Content about sustainable practices...",
                Category = BlogCategories.BusinessGrowth,
                Author = "Robert Johnson",
                AuthorInitials = "RJ",
                PublishedDate = DateTime.Now.AddDays(-20),
                ReadTimeMinutes = 8,
                FeaturedImageGradient = "from-green-500 to-emerald-600",
                IsFeatured = false,
                Tags = new() { "Sustainability", "Growth", "Impact" }
            },
            new()
            {
                Id = 9,
                Title = "The Art of Strategic Planning",
                Slug = "art-strategic-planning",
                Excerpt = "Develop winning strategies with our comprehensive guide to strategic planning that delivers measurable results.",
                Content = "Content about strategic planning...",
                Category = BlogCategories.Strategy,
                Author = "Maria Garcia",
                AuthorInitials = "MG",
                PublishedDate = DateTime.Now.AddDays(-22),
                ReadTimeMinutes = 13,
                FeaturedImageGradient = "from-blue-500 to-indigo-600",
                IsFeatured = false,
                Tags = new() { "Planning", "Strategy", "Results" }
            },
            new()
            {
                Id = 10,
                Title = "Digital Marketing Trends for 2024",
                Slug = "digital-marketing-trends-2024",
                Excerpt = "Stay ahead of the curve with the latest digital marketing trends that will shape customer engagement in 2024.",
                Content = "Content about marketing trends...",
                Category = BlogCategories.Insights,
                Author = "James Wilson",
                AuthorInitials = "JW",
                PublishedDate = DateTime.Now.AddDays(-25),
                ReadTimeMinutes = 9,
                FeaturedImageGradient = "from-yellow-400 to-orange-500",
                IsFeatured = false,
                Tags = new() { "Marketing", "Trends", "Engagement" }
            },
            new()
            {
                Id = 11,
                Title = "Building High-Performance Teams",
                Slug = "building-high-performance-teams",
                Excerpt = "Create teams that consistently deliver exceptional results with these proven leadership and management techniques.",
                Content = "Content about high-performance teams...",
                Category = BlogCategories.Strategy,
                Author = "Rachel Adams",
                AuthorInitials = "RA",
                PublishedDate = DateTime.Now.AddDays(-28),
                ReadTimeMinutes = 10,
                FeaturedImageGradient = "from-cyan-400 to-blue-500",
                IsFeatured = false,
                Tags = new() { "Teams", "Leadership", "Performance" }
            },
            new()
            {
                Id = 12,
                Title = "Financial Planning for Business Success",
                Slug = "financial-planning-business-success",
                Excerpt = "Master the fundamentals of business financial planning to ensure long-term success and sustainable growth.",
                Content = "Content about financial planning...",
                Category = BlogCategories.BusinessGrowth,
                Author = "Kevin Martinez",
                AuthorInitials = "KM",
                PublishedDate = DateTime.Now.AddDays(-30),
                ReadTimeMinutes = 11,
                FeaturedImageGradient = "from-slate-500 to-gray-600",
                IsFeatured = false,
                Tags = new() { "Finance", "Planning", "Success" }
            }
        };
    }

    private static string GenerateSampleContent(string topic, string context)
    {
        return $@"
<h2 id=""introduction"">Introduction</h2>
<p>In today's rapidly evolving business landscape, understanding {topic} has become more crucial than ever. Organizations worldwide are recognizing the importance of {context} in driving sustainable growth and maintaining competitive advantage.</p>

<p>This comprehensive guide explores the latest trends, proven strategies, and actionable insights that can help your business thrive in an increasingly complex market environment.</p>

<h2 id=""key-features"">Key Features</h2>
<p>When implementing {context}, there are several key features that distinguish successful approaches from less effective ones:</p>

<ul>
<li><strong>Strategic Planning:</strong> Developing a clear roadmap that aligns with your business objectives</li>
<li><strong>Data-Driven Decisions:</strong> Leveraging analytics to inform strategic choices</li>
<li><strong>Scalable Solutions:</strong> Building systems that grow with your business</li>
<li><strong>Customer Focus:</strong> Placing customer needs at the center of all initiatives</li>
</ul>

<h2 id=""implementation"">Implementation Details</h2>
<p>Successfully implementing {context} requires a systematic approach that takes into account your organization's unique needs and constraints. The process typically involves several phases:</p>

<h3 id=""best-practices"">Best Practices</h3>
<p>Drawing from industry experience and research, here are the best practices that consistently deliver results:</p>

<ol>
<li>Start with a clear understanding of your current state</li>
<li>Define specific, measurable objectives</li>
<li>Engage stakeholders throughout the process</li>
<li>Monitor progress and adjust strategies as needed</li>
<li>Celebrate milestones and learn from setbacks</li>
</ol>

<p>These practices have been validated across numerous successful implementations and represent the collective wisdom of industry leaders.</p>

<h2 id=""conclusion"">Conclusion</h2>
<p>The journey of {topic} is ongoing and requires continuous adaptation to changing market conditions. By focusing on {context} and following proven methodologies, organizations can position themselves for long-term success.</p>

<p>Remember that success in this area isn't just about implementing the right tools or processes—it's about creating a culture that embraces change and innovation while staying true to core business values.</p>

<blockquote>
<p>""The future belongs to organizations that can adapt quickly while maintaining focus on what matters most to their customers.""</p>
</blockquote>

<p>As you embark on or continue your journey with {context}, keep these principles in mind and don't hesitate to seek guidance from experts who have navigated similar challenges.</p>
";
    }
}