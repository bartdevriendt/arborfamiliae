using DevExpress.Mvvm;

namespace ArborFamiliae.ViewModels.Base;

public class ArborDetailViewModelBase : ArborViewModelBase, ISupportParameter, IEditViewModel, ISupportParentViewModel
{
    public Guid Id { get; set; }
    public object Parameter { get => Id; set => Id = (Guid)value; }
    public bool CanNavigateFrom()
    {
        var document = DocumentManagerService.Documents.FirstOrDefault(x =>x.Content is IEditViewModel);
        if(document == null) return true;
        var viewModel = document.Content as IEditViewModel;
        return viewModel.CanNavigateFrom();
    }

    public object ParentViewModel { get; set; }
}