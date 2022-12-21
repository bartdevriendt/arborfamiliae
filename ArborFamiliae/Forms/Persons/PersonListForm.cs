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

namespace ArborFamiliae.Forms.Persons;

public partial class PersonListForm : DevExpress.XtraEditors.XtraForm
{

    private PersonService personService;
    private IServiceProvider serviceProvider;

    public PersonListForm(PersonService personService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        this.personService = personService;
        this.serviceProvider = serviceProvider;
    }

    private void PersonListForm_Load(object sender, EventArgs e)
    {
        personListModelBindingSource.DataSource = this.personService.GetAllPersons();

    }

    private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        var form = this.serviceProvider.GetService<AddEditPersonForm>();
        form.ShowDialog();
    }
}
