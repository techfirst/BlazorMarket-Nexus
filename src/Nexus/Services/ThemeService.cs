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
        if (_isInitialized)
        {
            Console.WriteLine($"New ThemeService instance inheriting static state: {(_isDarkMode ? "dark" : "light")}");
        }
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
            Console.WriteLine($"ThemeService initialized with theme: {(_isDarkMode ? "dark" : "light")}");
            _isInitialized = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ThemeService initialization error: {ex.Message}");
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
            Console.WriteLine($"Theme reapplied from static state: {(_isDarkMode ? "dark" : "light")}");
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
            Console.WriteLine($"Theme toggled to: {(_isDarkMode ? "dark" : "light")}");
            
            await ApplyThemeAsync();
            await SaveThemePreferenceAsync();
            OnThemeChanged?.Invoke();
            
            Console.WriteLine("Theme toggle completed successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error toggling theme: {ex.Message}");
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
            Console.WriteLine($"Theme applied: {(_isDarkMode ? "dark" : "light")}");
        }
        catch (JSDisconnectedException)
        {
            Console.WriteLine("JavaScript disconnected during theme application - theme will be applied on next render");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Theme application failed: {ex.Message}");
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
                Console.WriteLine($"Theme applied via fallback: {(_isDarkMode ? "dark" : "light")}");
            }
            catch (JSDisconnectedException)
            {
                Console.WriteLine("JavaScript disconnected during fallback theme application");
            }
            catch (Exception fallbackEx)
            {
                Console.WriteLine($"Fallback theme application failed: {fallbackEx.Message}");
            }
        }
    }

    private async Task SaveThemePreferenceAsync()
    {
        try
        {
            var themeValue = _isDarkMode ? "dark" : "light";
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", themeValue);
            Console.WriteLine($"Theme saved to localStorage: {themeValue}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving theme preference: {ex.Message}");
        }
    }
}