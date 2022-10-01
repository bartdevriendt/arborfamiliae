using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ArborFamiliae
{
    public partial class DatabaseSelectionForm : DevExpress.XtraEditors.XtraForm
    {
        public DatabaseSelectionForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            InitializeServices();
            
            Hide();
            using (var serviceScope = ServiceContext.ServiceProvider.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var form = services.GetRequiredService<ArborFamiliaeMainForm>();
                    form.ShowDialog();
                    Show();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void InitializeServices()
        {
            var builder = new HostBuilder();
            builder.ConfigureServices((hostcontext, services) =>
            {
                services.AddScoped<ArborFamiliaeMainForm>();
                services.RegisterMySqlContext("192.168.3.11", "arbor", "arbor", "arbor");
            });

            var host = builder.Build();
            ServiceContext.ServiceProvider = host.Services;

            using(var serviceScope = ServiceContext.ServiceProvider.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetRequiredService<ArborFamiliaeContext>();
                ArborFamiliaeContext.InitializeAsync(db);
            }
            
        }
    }
}