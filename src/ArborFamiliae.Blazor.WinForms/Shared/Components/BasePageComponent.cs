using Microsoft.AspNetCore.Components;

namespace ArborFamiliae.Blazor.WinForms.Shared.Components;

public class BasePageComponent : ComponentBase
{
[Inject]
protected NavigationManager NavigationManager { get; set; }
}