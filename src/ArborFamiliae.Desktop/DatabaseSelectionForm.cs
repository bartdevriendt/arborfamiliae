using System;
using System.Windows.Forms;
using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.Desktop;
using ArborFamiliae.Services.Common;

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

            MainForm f = new MainForm();
            f.Show();

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