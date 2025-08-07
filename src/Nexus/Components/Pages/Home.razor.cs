using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Nexus.Components.Pages;

public partial class Home : ComponentBase
{
    [Inject] private IJSRuntime JSRuntime { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // JavaScript handles hash navigation automatically
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task HandleGetStartedClick()
    {
        // TODO: Add navigation logic or show signup modal
        // For now, we could scroll to a signup section or navigate to a signup page
        await Task.CompletedTask;
    }

    private async Task HandleWatchDemoClick()
    {
        // TODO: Add demo modal or video player logic
        await Task.CompletedTask;
    }
}