using Microsoft.AspNetCore.Components;

namespace RedSpartan.UI.Components;

public abstract class RedSpartanComponentBase : ComponentBase
{
    [Parameter] public string? Id { get; set; }
    [Parameter] public string? CssClass { get; set; }
    [Parameter] public string? Style { get; set; }
    
    protected string ComponentId => Id ?? $"rs-{Guid.NewGuid():N}";
    
    protected virtual string GetBaseCssClasses()
    {
        var classes = new List<string>();
        
        if (!string.IsNullOrEmpty(CssClass))
            classes.Add(CssClass);
            
        return string.Join(" ", classes);
    }
}
