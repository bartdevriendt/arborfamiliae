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
    
    IServiceContainer serviceContainer = null;
    protected IServiceContainer ServiceContainer {
        get {
            if(serviceContainer == null)
                serviceContainer = new ServiceContainer(this);
            return serviceContainer; 
        }
    }
    
    IServiceContainer ISupportServices.ServiceContainer  { get { return ServiceContainer; } }
}