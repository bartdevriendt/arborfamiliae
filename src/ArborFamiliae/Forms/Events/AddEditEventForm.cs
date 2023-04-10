using ArborFamiliae.Domain.Events;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArborFamiliae.Forms.Events
{
    public partial class AddEditEventForm : DevExpress.XtraEditors.XtraForm
    {

        private EventAddEditModel _model;

        public EventAddEditModel Model
        {
            get => _model;
            set
            {
                _model = value;
                eventAddEditModelBindingSource.DataSource = value;
            }

        }
        public AddEditEventForm()
        {
            InitializeComponent();
        }
    }
}