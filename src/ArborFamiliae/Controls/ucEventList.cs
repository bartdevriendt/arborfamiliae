using ArborFamiliae.Domain.Events;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Forms.Events;
using ArborFamiliae.Forms.Persons;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class ucEventList : DevExpress.XtraEditors.XtraUserControl
    {
        private BindingList<EventAddEditModel> _events;

        public BindingList<EventAddEditModel> Events { 
            get => _events; 
            set
            {
                _events = value;
                eventAddEditModelBindingSource.DataSource = _events;
            }
        } 

        public ucEventList()
        {
            InitializeComponent();
        }

        private void ucEventList_Load(object sender, EventArgs e)
        {
            eventAddEditModelBindingSource.DataSource = Events;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Events.Add(new EventAddEditModel
            {
                Category = "Personal",
                DateText = "2011-12-13",
                Description = "Test",
                Participants = "Me and you",
                PlaceName = "Somewhere",
                ListType = Domain.Enums.EventListType.Person,
                Role = Domain.Enums.EventRole.PRIMARY,
                Type = Domain.Enums.EventType.BIRTH,
                RoleDescription = "Primary",
                TypeDescription = "Birth"
            });
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow)
            {
                EventAddEditModel model = gridView1.GetRow(info.RowHandle) as EventAddEditModel;
                var form = ServiceContext.ServiceProvider.GetService<AddEditEventForm>();
                form.Model = model;
                form.ShowDialog();
            }
        }
    }
}
