using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Nexus.Models;
using Nexus.Services;

namespace Nexus.Components.Pages;

public partial class BlogDetail : ComponentBase
{
    [Parameter] public string Slug { get; set; } = string.Empty;
    [Inject] private BlogService BlogService { get; set; } = null!;
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    [Inject] private IJSRuntime JSRuntime { get; set; } = null!;
    
    private BlogPost? Post { get; set; }
    private List<TableOfContentsItem> _tableOfContents = new();
    private List<BlogPost> _relatedPosts = new();
    private bool IsLoading { get; set; } = true;
    
    protected override async Task OnParametersSetAsync()
    {
        await LoadPost();
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Force scroll to top as a backup if FocusOnNavigate doesn't work
            await JSRuntime.InvokeVoidAsync("window.scrollTo", 0, 0);
        }
        
        await base.OnAfterRenderAsync(firstRender);
    }
    
    private async Task LoadPost()
    {
        IsLoading = true;
        
        try
        {
            Post = await BlogService.GetPostBySlugAsync(Slug);
            
            if (Post != null)
            {
                // Generate table of contents
                _tableOfContents = BlogService.GenerateTableOfContents(Post.FullContent);
                
                // Load related posts
                _relatedPosts = await BlogService.GetRelatedPostsAsync(Post.Slug, Post.Category, 3);
            }
        }
        catch (Exception)
        {
            Post = null;
        }
        finally
        {
            IsLoading = false;
        }
    }
    
    private void NavigateToBlob()
    {
        Navigation.NavigateTo("/blog");
    }
}