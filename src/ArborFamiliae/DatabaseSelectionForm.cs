using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Models;
using ArborFamiliae.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows.Forms;

namespace ArborFamiliae
{
    public partial class DatabaseSelectionForm : DevExpress.XtraEditors.XtraForm
    {

        private FamilyTreeDatabaseService familyTreeDatabaseService;

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
            if (gridView1.FocusedRowHandle == -1)
            {
                return;
            }

            var database = gridView1.GetRow(gridView1.FocusedRowHandle) as FamilyTreeDatabase;

            ServiceContext.BuildServices(database);
            
        }

        private void DatabaseSelectionForm_Load(object sender, EventArgs e)
        {
            familyTreeDatabaseService = new FamilyTreeDatabaseService();
            LoadDatabasesList();
        }

        private void LoadDatabasesList()
        {
            familyTreeDatabaseBindingSource.DataSource = familyTreeDatabaseService.LoadDatabases();
        }

        private void btnNewDatabase_Click(object sender, EventArgs e)
        {
            NewDatabaseForm newDatabaseForm = new NewDatabaseForm(familyTreeDatabaseService);
            if (newDatabaseForm.ShowDialog() == DialogResult.OK)
            {
                LoadDatabasesList();
            }
        }

        
    }
}