using System.ComponentModel;
using System.Runtime.CompilerServices;
using ArborFamiliae.Shared.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using DevExpress.Mvvm.POCO;

namespace ArborFamiliae.ViewModels.Base;

public class ArborViewModelBase: ISupportServices

{
    protected IWindowService WindowService {
        get { return this.GetService<IWindowService>(); }
    }
    protected IDialogService DialogService {
        get { return this.GetService<IDialogService>(); }
    }
    protected IDocumentManagerService DocumentManagerService {
        get { return this.GetService<IDocumentManagerService>(); }
    }
    protected INavigationService NavigationService {
        get { return this.GetService<INavigationService>(); }
    }
    protected IMessageBoxService MessageBoxService {
        get { return this.GetService<IMessageBoxService>(); }
    }
    
    protected virtual IServiceProvider ServiceProvider
    {
        get { return ServiceContainer.GetService<IServiceProvider>(); }
    }
    
    
    protected IPersonService? PersonService {
        get
        {
            var provider = ServiceProvider;
            return provider.GetService(typeof(IPersonService)) as IPersonService;
        }
    }
    
    
    IServiceContainer serviceContainer = null;
    protected IServiceContainer ServiceContainer {
        get {
            if(serviceContainer == null)
                serviceContainer = new ServiceContainer(this);
            return serviceContainer; 
        }
    }
    
    IServiceContainer ISupportServices.ServiceContainer  { get { return ServiceContainer; } }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public virtual void RaisePropertyChanged(string propertyName)  
    {  
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}