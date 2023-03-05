using System;
using System.Diagnostics;
using System.Windows.Forms;
using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Hybrid.Services;
using ArborFamiliae.Hybrid.Shared.Models;
using ArborFamiliae.Services;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace ArborFamiliae.Hybrid
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                //.WriteTo.Debug(LogEventLevel.Debug)
                .WriteTo.Console(LogEventLevel.Debug, theme: AnsiConsoleTheme.Code, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                //.WriteTo.File("D:\\Temp\\ArborLogs\\ArborLogs.txt")
                .CreateLogger();
            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
            //Serilog.Debugging.SelfLog.Enable(Console.Error);
            
            
            //TODO: Remove this once .NET 8 upgrade has been done
            // See: https://github.com/dotnet/maui/issues/7997
            this.FormClosing += (sender, args) => { Environment.Exit(0); };
            
            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            #if DEBUG
            services.AddBlazorWebViewDeveloperTools();
            #endif
            services.AddLocalization();
            services.AddLogging(logging =>
            {
                logging.AddSerilog(dispose: true, logger: Log.Logger);
                // logging.AddDebug();
                // logging.AddConsole();
            });
            services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
            services.AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.VisibleStateDuration = 5000;
                configuration.SnackbarConfiguration.ShowCloseIcon = false;
                configuration.SnackbarConfiguration.PreventDuplicates = true;
            });

            
            services.AddDbContext<ArborFamiliaeContext>(config =>
            {
                var connstring = ConnectionStringService.ConnectionString;
                if (ConnectionStringService.Provider == Provider.MySql.Name)
                {
                    config.UseLazyLoadingProxies();
                    config.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                    config.UseMySql(
                        connstring,
                        ServerVersion.AutoDetect(connstring),
                        x =>
                        {
                            x.MigrationsAssembly(typeof(MySqlMarker).Assembly.GetName().Name);
                        }
                    );    
                }
            });
            

            services.AddSingleton<ConnectionStringService>();
            services.RegisterServices();
            
            blazorWebView1.HostPage = "wwwroot\\index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
            
            Log.Information("Starting application");
            
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
#if DEBUG
                MessageBox.Show(text: args.ExceptionObject.ToString(), caption: "Error");
#else
    MessageBox.Show(text: "An error has occurred.", caption: "Error");
#endif
            };
        }
    }
}
