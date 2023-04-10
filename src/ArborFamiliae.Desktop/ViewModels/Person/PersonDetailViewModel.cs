using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM.Services;

namespace ArborFamiliae.Desktop.ViewModels.Person
{
    public class PersonDetailViewModel : ISupportParameter, IEditViewModel
    {

        public Guid PersonId { get; set; }

        public object Parameter { get => PersonId; set => PersonId = (Guid)value; }
        public bool CanNavigateFrom()
        {
            var document = DocumentManagerService.Documents.FirstOrDefault(x =>x.Content is IEditViewModel);
            if(document == null) return true;
            var viewModel = document.Content as IEditViewModel;
            return viewModel.CanNavigateFrom();
        }


        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetService<IDocumentManagerService>(); }
        }
        protected INavigationService NavigationService {
            get { return this.GetService<INavigationService>(); }
        }

    }
}
