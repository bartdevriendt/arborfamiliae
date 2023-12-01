using ArborFamiliae.Services.Genealogy;
using DevExpress.Data.Utils;
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
using ArborFamiliae.Shared.Services;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ArborFamiliae.Domain.Person;

namespace ArborFamiliae.Forms.Persons;

public partial class PersonListForm : DevExpress.XtraEditors.XtraForm
{
    private IPersonService personService;
    private IServiceProvider serviceProvider;

    public PersonListForm(IPersonService personService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        this.personService = personService;
        this.serviceProvider = serviceProvider;
    }

    private async void PersonListForm_Load(object sender, EventArgs e)
    {
        var persons = await this.personService.GetAllPersons();
        personListModelBindingSource.DataSource = persons;
    }

    private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        var form = this.serviceProvider.GetService<AddEditPersonForm>();
        form.ShowDialog();
    }

    private void gvPersons_DoubleClick(object sender, EventArgs e)
    {
        DXMouseEventArgs ea = e as DXMouseEventArgs;
        GridView view = sender as GridView;
        GridHitInfo info = view.CalcHitInfo(ea.Location);
        if (info.InRow)
        {
            PersonListModel model = gvPersons.GetRow(info.RowHandle) as PersonListModel;
            var form = this.serviceProvider.GetService<AddEditPersonForm>();
            form.PersonId = model.Id;
            form.ShowDialog();
        }
    }
}
