using Microsoft.JSInterop;

namespace Nexus.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    private static bool _isDarkMode = false;
    private static bool _isInitialized = false;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        
        // If we have static state, immediately apply it to this instance
        // This ensures new service instances inherit the persisted theme
    }

    public bool IsDarkMode => _isDarkMode;

    public event Action? OnThemeChanged;

    public async Task InitializeAsync()
    {
        if (_isInitialized) return;
        
        try
        {
            var savedTheme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "theme");
            _isDarkMode = savedTheme == "dark";
            await ApplyThemeAsync();
            _isInitialized = true;
        }
        catch (Exception ex)
        {
            _isDarkMode = false;
            _isInitialized = true;
        }
    }

    public async Task ReapplyThemeAsync()
    {
        if (_isInitialized)
        {
            // Add a small delay to ensure DOM is ready
            await Task.Delay(50);
            
            // We have static state, just apply it
            await ApplyThemeAsync();
        }
        else
        {
            // First time initialization
            await InitializeAsync();
        }
    }

    public async Task ToggleThemeAsync()
    {
        try
        {
            _isDarkMode = !_isDarkMode;
            
            await ApplyThemeAsync();
            await SaveThemePreferenceAsync();
            OnThemeChanged?.Invoke();
        }
        catch (Exception ex)
        {
            // Revert the change if something went wrong
            _isDarkMode = !_isDarkMode;
        }
    }

    private async Task ApplyThemeAsync()
    {
        try
        {
            // Try coordinated approach first
            await _jsRuntime.InvokeVoidAsync("window.themeHelper.setTheme", _isDarkMode);
        }
        catch (JSDisconnectedException)
        {
            // JavaScript disconnected - theme will be applied on next render
        }
        catch (Exception ex)
        {
            // Fallback to direct DOM manipulation
            try
            {
                if (_isDarkMode)
                {
                    await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.add('dark')");
                }
                else
                {
                    await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.remove('dark')");
                }
            }
            catch (JSDisconnectedException)
            {
                // JavaScript disconnected during fallback
            }
            catch (Exception fallbackEx)
            {
                // Fallback failed
            }
        }
    }

    private async Task SaveThemePreferenceAsync()
    {
        try
        {
            var themeValue = _isDarkMode ? "dark" : "light";
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", themeValue);
        }
        catch (Exception ex)
        {
            // Error saving theme preference
        }
    }
}