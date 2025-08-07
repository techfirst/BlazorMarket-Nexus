using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Nexus.Components.Layout;

public partial class NavMenu : ComponentBase
{
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    
    private bool _mobileMenuOpen = false;

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
        
        return isActive 
            ? "text-nexus-blue hover:text-nexus-blue-dark" 
            : "text-gray-600 hover:text-nexus-dark";
    }
}