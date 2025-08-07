using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Nexus.Components.Shared;

public partial class Button : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Primary;
    [Parameter] public ButtonSize Size { get; set; } = ButtonSize.Medium;
    [Parameter] public bool Disabled { get; set; } = false;
    [Parameter] public string Type { get; set; } = "button";
    [Parameter] public string AdditionalClasses { get; set; } = "";

    private async Task HandleClick(MouseEventArgs args)
    {
        if (!Disabled && OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync(args);
        }
    }

    private string GetButtonClasses()
    {
        var baseClasses = "inline-flex items-center justify-center font-semibold transition-all duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2";
        
        var variantClasses = Variant switch
        {
            ButtonVariant.Primary => "bg-nexus-blue text-white hover:bg-nexus-blue-dark focus:ring-nexus-blue hover:shadow-lg hover:-translate-y-1",
            ButtonVariant.Secondary => "bg-transparent text-nexus-blue border-2 border-nexus-blue hover:bg-nexus-blue hover:text-white focus:ring-nexus-blue",
            ButtonVariant.White => "bg-white text-nexus-blue hover:bg-gray-50 focus:ring-nexus-blue shadow-md",
            _ => "bg-nexus-blue text-white hover:bg-nexus-blue-dark focus:ring-nexus-blue"
        };

        var sizeClasses = Size switch
        {
            ButtonSize.Small => "px-4 py-2 text-sm rounded-lg",
            ButtonSize.Medium => "px-6 py-3 text-base rounded-lg",
            ButtonSize.Large => "px-8 py-4 text-lg rounded-full",
            _ => "px-6 py-3 text-base rounded-lg"
        };

        var disabledClasses = Disabled ? "opacity-50 cursor-not-allowed" : "";

        return $"{baseClasses} {variantClasses} {sizeClasses} {disabledClasses} {AdditionalClasses}".Trim();
    }
}

public enum ButtonVariant
{
    Primary,
    Secondary,
    White
}

public enum ButtonSize
{
    Small,
    Medium,
    Large
}