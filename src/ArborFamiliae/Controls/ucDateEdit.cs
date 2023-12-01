using ArborFamiliae.Domain.Events;
using ArborFamiliae.Services.Common;
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

namespace ArborFamiliae.Controls
{
    public partial class ucDateEdit : DevExpress.XtraEditors.XtraUserControl
    {
        private ArborDateModel _model;
        public ArborDateModel DateModel { get => _model; set
            {
                _model = value;
                DateText = _model.ConvertToDisplay();
            }
        }


        private string _dateText;
        public string DateText
        {
            get => _dateText; 
            set
            {
                _dateText = value;
                buttonEdit1.EditValue = _dateText;
            }
        }

        public ucDateEdit()
        {
            InitializeComponent();
            buttonEdit1.EditValue = "";
        }

        private void buttonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateText = buttonEdit1.EditValue.ToString();
            try
            {
                DateParserService dateParserService = new DateParserService();
                _model = dateParserService.ParseDate(DateText);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error parsing date");
            }
        }
    }
}
