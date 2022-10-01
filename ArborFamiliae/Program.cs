using DevExpress.Skins;
using DevExpress.UserSkins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ArborFamiliae
{
    internal static class Program
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DatabaseSelectionForm databaseSelectionForm = new DatabaseSelectionForm();
            if(databaseSelectionForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var builder = new HostBuilder();
            builder.ConfigureServices((hostcontext, services) =>
            {
                services.AddScoped<ArborFamiliaeMainForm>();
            });

            var host = builder.Build();
            ServiceProvider = host.Services;


            using(var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var form = services.GetRequiredService<ArborFamiliaeMainForm>();
                    Application.Run(form);
                }
                catch(Exception ex)
                {
                    
                }
            }

            
        }
    }
}
