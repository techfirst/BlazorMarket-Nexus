using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Nexus.Components.Shared;

public partial class ScrollToTop : ComponentBase, IAsyncDisposable
{
    [Inject] private IJSRuntime JSRuntime { get; set; } = null!;
    
    private bool _isVisible = false;
    private DotNetObjectReference<ScrollToTop>? _dotNetRef;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _dotNetRef = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("initializeScrollToTop", _dotNetRef);
        }
    }

    [JSInvokable]
    public async Task UpdateVisibility(bool isVisible)
    {
        if (_isVisible != isVisible)
        {
            _isVisible = isVisible;
            await InvokeAsync(StateHasChanged);
        }
    }

    private async Task ScrollToTopAsync()
    {
        try
        {
            await JSRuntime.InvokeVoidAsync("eval", "window.scrollTo({ top: 0, behavior: 'smooth' })");
        }
        catch (JSDisconnectedException)
        {
            // Ignore - the circuit has disconnected
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ScrollToTop scroll error: {ex.Message}");
        }
    }

    private string GetScrollToTopClass()
    {
        return _isVisible 
            ? "fixed bottom-6 right-6 z-50 opacity-100 translate-y-0 transition-all duration-300 ease-out"
            : "fixed bottom-6 right-6 z-50 opacity-0 translate-y-4 pointer-events-none transition-all duration-300 ease-out";
    }

    public async ValueTask DisposeAsync()
    {
        if (_dotNetRef != null)
        {
            try
            {
                await JSRuntime.InvokeVoidAsync("disposeScrollToTop");
            }
            catch (JSDisconnectedException)
            {
                // Ignore - the circuit has disconnected, which is expected during navigation
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ScrollToTop dispose error: {ex.Message}");
            }
            finally
            {
                _dotNetRef.Dispose();
            }
        }
    }
}