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
using ArborFamiliae.ViewModels.Database;

namespace ArborFamiliae.Desktop.Views.Database
{
    public partial class NewDatabaseView : DevExpress.XtraEditors.XtraUserControl
    {
        public NewDatabaseView()
        {
            InitializeComponent();
            if(!mvvmContext1.IsDesignMode)
            {
                InitializeBindings();
            }
        }

        private void InitializeBindings()
        {
            var api = mvvmContext1.OfType<NewDatabaseViewModel>();
            api.SetBinding(txtName, y => y.EditValue, z => z.Family);
            api.SetBinding(txtDatabase, y => y.EditValue, z => z.DatabaseName);
            api.SetBinding(comboBoxEdit1, y => y.EditValue, z => z.DatabaseType);
            api.SetBinding(txtServer, y => y.EditValue, z => z.Server);
            api.SetBinding(txtUsername, y => y.EditValue, z => z.Username);
            api.SetBinding(txtPassword, y => y.EditValue, z => z.Password);
            
        }
    }
}
