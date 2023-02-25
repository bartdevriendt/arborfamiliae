using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Hybrid.Services;
using ArborFamiliae.Hybrid.Shared.Models;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace ArborFamiliae.Hybrid
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            //TODO: Remove this once .NET 8 upgrade has been done
            // See: https://github.com/dotnet/maui/issues/7997
            this.FormClosing += (sender, args) => { Environment.Exit(0); };
            
            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            #if DEBUG
            services.AddBlazorWebViewDeveloperTools();
            #endif
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
                    config.UseMySql(
                        connstring,
                        ServerVersion.AutoDetect(connstring),
                        x =>
                        {
                            x.MigrationsAssembly(typeof(DependencyInjection).Assembly.GetName().Name);
                        }
                    );    
                }
            });
            

            services.AddSingleton<ConnectionStringService>();
            
            blazorWebView1.HostPage = "wwwroot\\index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
            
        }
    }
}
