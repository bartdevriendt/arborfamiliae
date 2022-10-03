using ArborFamiliae.Forms.Persons;
using DevExpress.Data.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArborFamiliae
{
    public partial class ArborFamiliaeMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private PersonListForm _personList = null;
        private IServiceProvider _serviceProvider = null;

        public ArborFamiliaeMainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnPerson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if(_personList == null || _personList.IsDisposed)
            {
                _personList = _serviceProvider.GetService<PersonListForm>();
            }

            OpenOrShowForm(_personList);
            
        }

        private void OpenOrShowForm(Form f)
        {
            BaseDocument document;

            if(tabbedView1.Documents.TryGetValue(f, out document))
            {
                tabbedView1.Controller.Activate(document);
            }
            else
            {
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
