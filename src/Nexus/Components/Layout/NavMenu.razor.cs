using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Nexus.Services;

namespace Nexus.Components.Layout;

public partial class NavMenu : ComponentBase, IDisposable
{
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    [Inject] private ThemeService ThemeService { get; set; } = null!;
    
    private bool _mobileMenuOpen = false;

    protected override async Task OnInitializedAsync()
    {
        await ThemeService.InitializeAsync();
        ThemeService.OnThemeChanged += StateHasChanged;
    }

    private async Task ToggleTheme()
    {
        await ThemeService.ToggleThemeAsync();
    }

    private void ToggleMobileMenu()
    {
        _mobileMenuOpen = !_mobileMenuOpen;
    }

    private string GetMobileMenuClass()
    {
        return _mobileMenuOpen ? "" : "hidden";
    }
    
    private string GetBlogLinkClass()
    {
        var uri = new Uri(Navigation.Uri);
        var isActive = uri.AbsolutePath.StartsWith("/blog", StringComparison.OrdinalIgnoreCase);
        
        if (isActive)
        {
            return "text-nexus-blue hover:text-nexus-blue-dark dark:text-nexus-blue dark:hover:text-nexus-blue-dark";
        }
        else
        {
            return "text-gray-600 dark:text-gray-300 hover:text-nexus-dark dark:hover:text-white";
        }
    }

    public void Dispose()
    {
        ThemeService.OnThemeChanged -= StateHasChanged;
    }
}