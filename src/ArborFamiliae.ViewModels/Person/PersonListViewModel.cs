using System.ComponentModel;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Services;
using ArborFamiliae.ViewModels.Base;
using ArborFamiliae.ViewModels.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using DevExpress.Mvvm.POCO;

namespace ArborFamiliae.ViewModels.Person;

[GenerateViewModel]
public partial class PersonListViewModel : ArborViewModelBase, IDocumentContent
{

    public PersonListViewModel()
    {
        Messenger.Default.Register<ReloadDataMessage>(this, OnReloadData);

    }
    void OnReloadData(ReloadDataMessage message) {
        LoadPersonsAsync();
    }

    public string Test { get; set; } = "";
    [GenerateProperty] private BindingList<PersonListModel>? persons;
    [GenerateProperty] private PersonListModel? selectedEntity;

    IPersonService PersonService {
        get
        {
            var provider = ServiceProvider;
            return provider.GetService(typeof(IPersonService)) as IPersonService;
        }
    }



    [GenerateCommand]
    public Task LoadPersonsAsync()
    {
        var dispatcher = this.GetService<IDispatcherService>();
        return Task.Run(() =>
        {
            return PersonService.GetAllPersons();
        }).ContinueWith(
            r =>
            {
                dispatcher.Invoke(() => Persons = new BindingList<PersonListModel>(r.Result));
            });
    }
    
    [GenerateCommand]
    public void New()
    {
        NavigationService.Navigate("PersonDetailView", Guid.Empty);
        
        //DialogService.ShowDialog(MessageButton.OKCancel, "Person", "PersonDetailView", Guid.Empty, this);
    }
    [GenerateCommand]
    public void Edit() {
        if (SelectedEntity != null)
        {
            NavigationService.Navigate("PersonDetailView", SelectedEntity.Id);
            //DialogService.ShowDialog(MessageButton.OKCancel, "Person", "PersonDetailView", SelectedEntity.Id, this);
        }
    }


    public void OnClose(CancelEventArgs e)
    {
        
    }

    public void OnDestroy()
    {
        
    }

    public IDocumentOwner DocumentOwner { get; set; }
    public object Title => "Person List";
}