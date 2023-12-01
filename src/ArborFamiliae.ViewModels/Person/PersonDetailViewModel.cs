using System.ComponentModel;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Services;
using ArborFamiliae.ViewModels.Base;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using DevExpress.Mvvm.POCO;

namespace ArborFamiliae.ViewModels.Person;

[GenerateViewModel]
public partial class PersonDetailViewModel : ArborDetailViewModelBase, IDocumentContent
{
    
    public Guid PersonId => Id;

    [GenerateProperty(OnChangedMethod = "OnPersonLoaded")] private PersonAddEditModel? person;

    private void OnPersonLoaded()
    {
        RaisePropertyChanged(new PropertyChangedEventArgs(nameof(Title)));
    }

    [GenerateCommand]
    public void DataUpdated()
    {
        OnPersonLoaded();
    }
    
    [GenerateCommand]
    public Task LoadPersonAsync()
    {
        if (PersonId == Guid.Empty)
        {
            Person = new PersonAddEditModel();
            return Task.CompletedTask;
        }
        
        var dispatcher = this.GetService<IDispatcherService>();
        return Task.Run(() => PersonService?.GetPersonById(PersonId))
            .ContinueWith(
            r =>
            {
                dispatcher.Invoke(() => Person = r.Result);
            });

        
    }

    public void OnClose(CancelEventArgs e)
    {
        
    }

    public void OnDestroy()
    {
        
    }

    public IDocumentOwner DocumentOwner { get; set; }
    public object Title => Person != null ? Person.DisplayName : "New Person";
    
    
}