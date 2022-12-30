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
using ArborFamiliae.Services.Genealogy;

namespace ArborFamiliae.Forms.Persons
{
    public partial class AddEditPersonForm : DevExpress.XtraEditors.XtraForm
    {
        private GenderService genderService;


        public AddEditPersonForm(GenderService genderService)
        {
            this.genderService = genderService;
            InitializeComponent();
        }

        private void AddEditPersonForm_Load(object sender, EventArgs e)
        {
            genderModelBindingSource.DataSource = Task.Run(async () => await genderService.GetGenders()).Result;
        }
    }
}