using System.ComponentModel;
using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.Services.Interfaces.Database;
using ArborFamiliae.ViewModels.Base;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using DevExpress.Mvvm.POCO;

namespace ArborFamiliae.ViewModels.Database;

[GenerateViewModel]
public partial class DatabaseSelectionViewModel : ArborViewModelBase
{
    [GenerateProperty] private BindingList<FamilyTreeDatabase> _familyTreeDatabases = new();

    [GenerateProperty] private FamilyTreeDatabase? _selectedDatabase;

    [GenerateCommand]
    public Task LoadDatabases()
    { 
        var service = ServiceProvider.GetService(typeof(IFamilyTreeDatabaseService)) as IFamilyTreeDatabaseService;
        var dispatcher = this.GetService<IDispatcherService>();
        return Task.Run(() =>
        {
            return service.LoadDatabases();
        }).ContinueWith(
            r =>
            {
                dispatcher.Invoke(() => FamilyTreeDatabases = new BindingList<FamilyTreeDatabase>(r.Result));
            });
    }

    [GenerateCommand]
    public void AddNewDatabase()
    {
        var viewModel = new NewDatabaseViewModel();
        var result = DialogService.ShowDialog(MessageButton.OKCancel, "New Database", "NewDatabaseView", viewModel);
        if (result == MessageResult.OK)
        {
            var service = ServiceProvider.GetService(typeof(IFamilyTreeDatabaseService)) as IFamilyTreeDatabaseService;
            service.StoreDatabase(new FamilyTreeDatabase
            {
                Name = viewModel.Family,
                DatabaseType = viewModel.DatabaseType,
                Database = viewModel.DatabaseName,
                Server = viewModel.Server,
                Username = viewModel.Username,
                Password = viewModel.Password
            });
            LoadDatabases();
        }
    }
}