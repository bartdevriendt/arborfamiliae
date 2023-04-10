using ArborFamiliae.Desktop.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArborFamiliae.Desktop.Views.Person;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Services;
using Castle.Components.DictionaryAdapter;

namespace ArborFamiliae.Desktop.ViewModels.Person
{
    public class PersonListViewModel
    {
        public PersonListViewModel()
        {
            Messenger.Default.Register<ReloadDataMessage>(this, OnReloadData);
        }

        public virtual BindingList<PersonListModel> Persons
        {
            get;
            protected set;
        }

        public virtual PersonListModel SelectedEntity {
            get;
            set;
        }

        public IMessageBoxService MessageBoxService {
            get { return this.GetService<IMessageBoxService>(); }
        }
        protected INavigationService NavigationService {
            get { return this.GetService<INavigationService>(); }
        }
        IDocumentManagerService DocumentManagerService {
            get { return this.GetService<IDocumentManagerService>("Flyout"); }
        }

        void OnReloadData(ReloadDataMessage message) {
            LoadPersonsAsync();
        }


        public Task LoadPersonsAsync()
        {
            var dispatcher = this.GetService<IDispatcherService>();
            return Task.Run(() =>
            {
                var personService = ServiceContext.ServiceProvider.GetService(typeof(IPersonService)) as IPersonService;
                return personService.GetAllPersons();
            }).ContinueWith(
                r =>
                {
                    dispatcher.Invoke(() => Persons = new BindingList<PersonListModel>(r.Result));
                });
        }

        public void New()
        {
            NavigationService.Navigate(nameof(PersonDetailView), Guid.Empty);
        }

        public void Edit() {
            if(SelectedEntity != null)
                NavigationService.Navigate(nameof(PersonDetailView), SelectedEntity.Id);
        }
    }
}
