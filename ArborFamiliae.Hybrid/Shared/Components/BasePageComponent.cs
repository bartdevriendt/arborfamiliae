using Microsoft.AspNetCore.Components;

namespace ArborFamiliae.Hybrid.Shared.Components;

public class BasePageComponent : ComponentBase
{
    [Inject]
    protected NavigationManager NavigationManager { get; set; }
}
