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
            }
        }

        void InitializeNavigation()
        {
            var msgService = MessageBoxService.CreateXtraMessageBoxService();
            mvvmContext1.RegisterService(msgService);
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<PersonDetailViewModel>();

        }
    }
}
