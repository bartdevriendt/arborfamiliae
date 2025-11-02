using Microsoft.AspNetCore.Components;

namespace ArborFamiliae.CrossPlatform.Shared.Components;

public class BasePageComponent : ComponentBase
{
    [Inject]
    protected NavigationManager NavigationManager { get; set; }
}
