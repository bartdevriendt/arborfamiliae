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
    public partial class DatabaseSelectionView : DevExpress.XtraEditors.XtraUserControl
    {
        public DatabaseSelectionView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluentAPI = mvvmContext1.OfType<DatabaseSelectionViewModel>();
            fluentAPI.SetBinding(familyTreeDatabaseBindingSource, bs => bs.DataSource, x => x.FamilyTreeDatabases);
            fluentAPI.SetBinding(familyTreeDatabaseBindingSource, pbs => pbs.Current, x => x.SelectedDatabase);
            fluentAPI.WithEvent(this, nameof(Load))
                .EventToCommand(x => x.LoadDatabases);
            fluentAPI.WithEvent(btnAddDatabase, nameof(Click)).EventToCommand(x => x.AddNewDatabase);
        }
    }
}
