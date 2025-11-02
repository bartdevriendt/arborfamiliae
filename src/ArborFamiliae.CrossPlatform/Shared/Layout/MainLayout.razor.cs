using MudBlazor;

namespace ArborFamiliae.CrossPlatform.Shared.Layout;

public partial class MainLayout
{
    private MudTheme _currentTheme;
    private bool _drawerOpen = true;
    private bool _isDarkMode = false;

    protected override async Task OnInitializedAsync()
    {
        _currentTheme = new MudTheme();
        
    }
    
    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private Task DarkMode()
    {
        _isDarkMode = !_isDarkMode;
        // _currentTheme = _isDarkMode
        //     ? ControlPanelTheme.DefaultTheme
        //     : ControlPanelTheme.DarkTheme;

        return Task.CompletedTask;
    }
}