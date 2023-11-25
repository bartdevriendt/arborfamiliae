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
using ArborFamiliae.ViewModels.Person;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraGrid.Views.Grid;

namespace ArborFamiliae.Desktop.Views
{
    public partial class PersonListView : DevExpress.XtraEditors.XtraUserControl
    {
        public PersonListView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
            {
                InitializeNavigation();
                InitializeBindings();
            }
        }

        void InitializeNavigation()
        {
            var msgService = MessageBoxService.CreateXtraMessageBoxService();
            mvvmContext1.RegisterService(msgService);
        }
        void InitializeBindings()
        {
            var fluentAPI = mvvmContext1.OfType<PersonListViewModel>();
            //// DataSource
            fluentAPI.SetBinding(personListModelBindingSource, pbs => pbs.DataSource, x => x.Persons);
            fluentAPI.SetBinding(personListModelBindingSource, pbs => pbs.Current, x => x.SelectedEntity);
            //// Interactions
            fluentAPI.WithEvent<RowClickEventArgs>(gvPersons, "RowClick")
                .EventToCommand(x => x.Edit,
                    args => (args.Clicks == 2) && (args.Button == MouseButtons.Left) && gvPersons.CalcHitInfo(args.Location).HitTest != DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.CellButton);
            //fluentAPI.WithEvent<OpenLinkEventArgs>(repositoryHyperlinkCall, nameof(RepositoryItemHyperLinkEdit.OpenLink))
            //    .EventToCommand(x => x.Call);
            ////fluentAPI.WithEvent<OpenLinkEventArgs>(repositoryHyperLinkNavigateScheduller, nameof(RepositoryItemHyperLinkEdit.OpenLink))
            ////   .EventToCommand(x => x.CreateOrEditAppointment, (OpenLinkEventArgs args)=> args.EditValue);
            ////Buttons
            fluentAPI.BindCommand(sbAddPerson, x => x.New);
            //fluentAPI.BindCommand(sbEditPatient, x => x.Edit);
            //fluentAPI.BindCommand(sbRemovePatient, x => x.Remove);
            //// Initial Loading
           
            fluentAPI.WithEvent(this, nameof(Load))
                .EventToCommand(x => x.LoadPersonsAsync);
        }
    }
}
