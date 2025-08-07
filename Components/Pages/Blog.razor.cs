using Microsoft.AspNetCore.Components;
using Nexus.Models;
using Nexus.Services;

namespace Nexus.Components.Pages;

public partial class Blog : ComponentBase
{
    [Inject] private BlogService BlogService { get; set; } = null!;
    
    private List<BlogPost> _allPosts = new();
    private bool _isLoading = true;
    
    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }
    
    private async Task LoadData()
    {
        _isLoading = true;
        
        try
        {
            _allPosts = await BlogService.GetAllPostsAsync();
        }
        finally
        {
            _isLoading = false;
        }
    }
}