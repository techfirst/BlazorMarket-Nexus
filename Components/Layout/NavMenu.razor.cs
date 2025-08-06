using Microsoft.AspNetCore.Components;

namespace Nexus.Components.Layout;

public partial class NavMenu : ComponentBase
{
    private bool _mobileMenuOpen = false;

    private void ToggleMobileMenu()
    {
        _mobileMenuOpen = !_mobileMenuOpen;
    }

    private async Task HandleGetStartedClick()
    {
        // TODO: Add navigation to signup page or scroll to contact section
        await Task.CompletedTask;
    }

    private string GetMobileMenuClass()
    {
        return _mobileMenuOpen ? "" : "hidden";
    }
}