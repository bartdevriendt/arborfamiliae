using Photino.NET;
using System.Drawing;
using System.Text;
using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Data.Sqlite;
using ArborFamiliae.Services;
using ArborFamiliae.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using Photino.Blazor;
using Syncfusion.Blazor;

namespace ArborFamiliae.CrossPlatform
{
    //NOTE: To hide the console window, go to the project properties and change the Output Type to Windows Application.
    // Or edit the .csproj file and change the <OutputType> tag from "WinExe" to "Exe".
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/Vkd+XU9FcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3tSd0VhWH9acHVRT2FeUU91Xg==");
            
            
            // Window title declared here for visibility
            string windowTitle = "Arbor Familiae";
            var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
            appBuilder.Services
                .AddLogging();
            appBuilder.Services.AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.MaxDisplayedSnackbars = 5;
                configuration.SnackbarConfiguration.RequireInteraction = true;
                configuration.SnackbarConfiguration.ShowCloseIcon = true;
                configuration.SnackbarConfiguration.PreventDuplicates = true;
            });
            appBuilder.Services.AddSyncfusionBlazor();

            appBuilder.Services.RegisterArborServices();
            
            appBuilder.Services.AddDbContextFactory<ArborFamiliaeContext>(config =>
            {
                var connstring = ConnectionStringService.ConnectionString;
                config.EnableSensitiveDataLogging();
                config.UseLazyLoadingProxies();
                config.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                if (ConnectionStringService.Provider == Provider.MySql.Name)
                {
                    config.UseMySql(
                        connstring,
                        ServerVersion.AutoDetect(connstring),
                        x =>
                        {
                            x.MigrationsAssembly(typeof(MySqlMarker).Assembly.GetName().Name);
                        }
                    );    
                }
                else if (ConnectionStringService.Provider == Provider.Sqlite.Name)
                {
                    config.UseSqlite(connstring,x =>
                    {
                        x.MigrationsAssembly(typeof(SqliteMarker).Assembly.GetName().Name);
                    });
                }
            }, ServiceLifetime.Transient);
            
            // register root component and selector
            appBuilder.RootComponents.Add<App>("app");
            
            // Creating a new PhotinoWindow instance with the fluent API
            // var window = new PhotinoWindow()
            //     .SetTitle(windowTitle)
            //     // Resize to a percentage of the main monitor work area
            //     .SetUseOsDefaultSize(false)
            //     .SetSize(new Size(1024, 800))
            //     // Center window in the middle of the screen
            //     .Center()
            //     // Users can resize windows by default.
            //     // Let's make this one fixed instead.
            //     .SetResizable(false)
            //     .RegisterCustomSchemeHandler("app", (object sender, string scheme, string url, out string contentType) =>
            //     {
            //         contentType = "text/javascript";
            //         return new MemoryStream(Encoding.UTF8.GetBytes(@"
            //             (() =>{
            //                 window.setTimeout(() => {
            //                     alert(`🎉 Dynamically inserted JavaScript.`);
            //                 }, 1000);
            //             })();
            //         "));
            //     })
            //     // Most event handlers can be registered after the
            //     // PhotinoWindow was instantiated by calling a registration 
            //     // method like the following RegisterWebMessageReceivedHandler.
            //     // This could be added in the PhotinoWindowOptions if preferred.
            //     .RegisterWebMessageReceivedHandler((object sender, string message) =>
            //     {
            //         var window = (PhotinoWindow)sender;
            //
            //         // The message argument is coming in from sendMessage.
            //         // "window.external.sendMessage(message: string)"
            //         string response = $"Received message: \"{message}\"";
            //
            //         // Send a message back the to JavaScript event handler.
            //         // "window.external.receiveMessage(callback: Function)"
            //         window.SendWebMessage(response);
            //     })
            //     .Load("wwwroot/index.html"); // Can be used with relative path strings or "new URI()" instance to load a website.
            //
            // window.WaitForClose(); // Starts the application event loop
            
            
            var app = appBuilder.Build();

            
            // customize window
            app.MainWindow
                //.SetIconFile("favicon.ico")
                .SetMaximized(true)
                .SetTitle(windowTitle);

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
            };

            app.Run();
        }
    }
}
