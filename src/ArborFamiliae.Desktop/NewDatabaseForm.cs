using ArborFamiliae.Services;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.Services.Common;

namespace ArborFamiliae
{
    public partial class NewDatabaseForm : DevExpress.XtraEditors.XtraForm
    {

       
        private FamilyTreeDatabaseService familyTreeDatabaseService;

        public NewDatabaseForm(FamilyTreeDatabaseService familyTreeDatabaseService)
        {
            InitializeComponent();
            this.familyTreeDatabaseService = familyTreeDatabaseService;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var database = new FamilyTreeDatabase();

            database.Database = txtDatabase.Text;
            database.Server = txtServer.Text;
            database.Username = txtUsername.Text;
            database.Password = txtPassword.Text;
            database.DatabaseType = comboBoxEdit1.SelectedItem.ToString();
            database.Name = txtName.Text; 


            familyTreeDatabaseService.StoreDatabase(database);


            DialogResult = DialogResult.OK;
            Close();
        }
    }
}