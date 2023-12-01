using System;
using ArborFamiliae.Shared.Services;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Domain.Enums;

namespace ArborFamiliae.Forms.Persons
{
    public partial class AddEditPersonForm : DevExpress.XtraEditors.XtraForm
    {
        private IGenderService genderService;
        private IPersonService personService;
        private IEnumService enumService;

        private PersonAddEditModel editModel = new();

        public Guid? PersonId { get; set; }


        public AddEditPersonForm(IGenderService genderService, IPersonService personService, IEnumService enumService)
        {
            this.genderService = genderService;
            this.personService = personService;
            this.enumService = enumService;
            InitializeComponent();

            

        }

        private async void AddEditPersonForm_Load(object sender, EventArgs e)
        {
            genderModelBindingSource.DataSource = await genderService.GetGenders();
            luePreferredNameType.Properties.DataSource = enumService.GetEnumTypes<NameType>();
            luePreferredNameType.Properties.ValueMember = "Value";
            luePreferredNameType.Properties.DisplayMember = "Description";
            luePreferredNameType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description"));

            if (PersonId != null)
            {
                editModel = await personService.GetPersonById(PersonId.Value);
            }

            personAddEditModelBindingSource.DataSource = editModel;
            ucEventList1.Events = editModel.Events;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            await personService.AddEditPerson(editModel);
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
