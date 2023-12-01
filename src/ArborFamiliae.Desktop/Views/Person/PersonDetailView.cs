using System;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.ViewModels.Person;
using DevExpress.Utils.MVVM.Services;

namespace ArborFamiliae.Desktop.Views.Person
{
    public partial class PersonDetailView : DevExpress.XtraEditors.XtraUserControl
    {
        public PersonDetailView()
        {
            InitializeComponent();

            

            if (!mvvmContext1.IsDesignMode)
            {
                InitializeNavigation();
                InitializeBindings();
            }
            
            personAddEditModelBindingSource.DataSource = new PersonAddEditModel();
        }

        void InitializeNavigation()
        {
            var msgService = MessageBoxService.CreateXtraMessageBoxService();
            mvvmContext1.RegisterService(msgService);
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<PersonDetailViewModel>();
            fluent.SetBinding(personAddEditModelBindingSource, pbs => pbs.DataSource, x => x.Person);
            fluent.WithEvent(this, nameof(Load))
                .EventToCommand(x => x.LoadPersonAsync);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
