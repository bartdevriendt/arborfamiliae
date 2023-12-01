using DevExpress.Utils.MVVM;
using System;
using System.Linq;
using System.Windows.Forms;
using ArborFamiliae.Desktop.ViewModels;
using ArborFamiliae.Desktop.Views;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;

namespace ArborFamiliae.Desktop
{
    public partial class MainForm : RibbonForm
    {

        static MainForm()
        {
            // Global setting for all dialogs UI
            MVVMContext.RegisterXtraFormService();
        }
        protected override FormShowMode ShowMode
        {
            get { return FormShowMode.AfterInitialization; }
        }

        public MainForm()
        {
            InitializeComponent();

            xtraTabControl1.CloseButtonClick += XtraTabControl1OnCloseButtonClick;
            xtraTabControl1.SelectedPageChanged += XtraTabControl1OnSelectedPageChanged;
            
            ServiceContext.BuildServices();
            
            if (!mvvmContext.IsDesignMode)
            {
                InitializeNavigation();
                InitializeBindings();
            }
        }

        private void XtraTabControl1OnSelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if(e.Page == null)
                ribbonControl1.UnMergeRibbon();
            else {
                var view = ((XtraTabPage)e.Page).Controls[0] as UserControl;
                var childRibbon = view.Controls.OfType<Control>()
                    .FirstOrDefault(c => c is RibbonControl) as RibbonControl;
                if(childRibbon != null)
                    ribbonControl1.MergeRibbon(childRibbon);
            }
        }

        private void XtraTabControl1OnCloseButtonClick(object sender, EventArgs e)
        {
            PageEventArgs ea = e as PageEventArgs;
            if(ea != null) {
                XtraTabPage page = ea.Page as XtraTabPage;
                if(page != null) page.Dispose();
            }
        }

        void InitializeNavigation()
        {
            // Main Navigation Service for all child views
            var navigationService = NavigationService.Create(xtraTabControl1);
            mvvmContext.RegisterDefaultService(navigationService);
            // Flyout Service for all child views
            var flyoutService = WindowedDocumentManagerService.CreateFlyoutFormService();
            flyoutService.DocumentShowMode = WindowedDocumentManagerService.FormShowMode.Dialog;
            flyoutService.FormStyle = (form) =>
            {
                var flyout = form as FlyoutDialog;
                flyout.Properties.Style = FlyoutStyle.Popup;
                
            };
            mvvmContext.RegisterDefaultService("Flyout", flyoutService);
        }
        void InitializeBindings()
        {
            var fluentApi = mvvmContext.OfType<MainFormViewModel>();
            //UI
            //fluentApi.BindCommand(darkThemeBBI, x => x.ChangeTheme);
            // Navigation Items
            //fluentApi.BindCommand(loginButtonItem, x => x.OpenLoginView);
            //fluentApi.SetBinding(usersViewItem, x => x.Visible, x => x.ShowUserCollectionView);
            //fluentApi.WithEvent<ElementClickEventArgs>(accordionControl1, nameof(accordionControl1.ElementClick))
            //    .EventToCommand(x => x.NavigateTo, args => CreateNavigateArgs(args));
            //// BreadCrumb Navigation
            //fluentApi.SetBinding(breadCrumbEdit1, x => x.SelectedNode, x => x.SelectedNode);
            //fluentApi.SetBinding(breadCrumbEdit1, x => x.EditValue, x => x.NavigationPath);
            //fluentApi.SetBinding(pnlNavigationBar, x => x.Visible, x => x.NavigationBarVisible);
            //var navigationContext = new NavigationContext(breadCrumbEdit1.Properties.Nodes);
            //navigationContext.MainForm = this;
            fluentApi.WithEvent(this, nameof(Load))
                .EventToCommand(x => x.Load);
            fluentApi.BindCommand(bbiPersons, x => x.ShowPage, x => "PersonListView");
            //fluentApi.WithEvent<BreadCrumbNodeClickEventArgs>(breadCrumbEdit1.Properties, nameof(breadCrumbEdit1.Properties.NodeClick))
            //    .EventToCommand(x => x.NavigateTo, args => CreateNavigateArgs(args));
            //// UI synchronization
            //accordionControl1.SelectedElement = accPerson;
            //fluentApi.SetTrigger(x => x.CurrentViewType, viewType =>
            //{
            //    if (viewType == nameof(PersonListView))
            //    {
            //        accordionControl1.SelectedElement = accPerson;
            //    }
            //});
            //fluentApi.SetTrigger(x => x.OverlayFormTrigger, showOverlay =>
            //{
            //    if (showOverlay)
            //    {
            //        overlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(mainPanel, new OverlayWindowOptions()
            //        {
            //            Opacity = 1f,
            //            BackColor = mainPanel.BackColor,
            //            FadeIn = false,
            //            FadeOut = true
            //        });
            //    }
            //    else DisposeHelper.Dispose(ref overlaySplashScreenHandle);
            //});
        }

        NavigateArgs CreateNavigateArgs(EventArgs eventArgs)
        {
            string path;
            Action cancelAction;
            if (eventArgs is ElementClickEventArgs)
            {
                var args = eventArgs as ElementClickEventArgs;
                path = args.Element.Tag as string;
                cancelAction = () => args.Handled = true;
            }
            else
            {
                var args = eventArgs as BreadCrumbNodeClickEventArgs;
                path = args.Node.Path;
                cancelAction = () => args.Handled = true;
            }

            bool showOverlay = false; // (path == nameof(View.AnalyticsView)) 
                                      // || (path == nameof(View.SchedulerView));
            return new NavigateArgs(path, cancelAction, showOverlay);
        }
    }
}
