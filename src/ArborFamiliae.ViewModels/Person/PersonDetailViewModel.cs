using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Services;
using ArborFamiliae.ViewModels.Base;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using DevExpress.Mvvm.POCO;

namespace ArborFamiliae.ViewModels.Person;

[GenerateViewModel]
public partial class PersonDetailViewModel : ArborDetailViewModelBase
{
    
    public Guid PersonId => Id;

    [GenerateProperty] private PersonAddEditModel? person;


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

}