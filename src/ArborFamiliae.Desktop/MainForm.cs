using DevExpress.Office.Services.Implementation;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ArborFamiliae.Desktop.ViewModels;
using ArborFamiliae.Desktop.Views;
using DevExpress.Mvvm;
using DevExpress.Utils;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace ArborFamiliae.Desktop
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        static MainForm()
        {
            // Global setting for all dialogs UI
            MVVMContext.RegisterFlyoutDialogService();
            //ServiceContainer.Default.RegisterService(new LoginService());
            //ServiceContainer.Default.RegisterService(new PrintReportService());
        }
        protected override FormShowMode ShowMode
        {
            get { return FormShowMode.AfterInitialization; }
        }

        public MainForm()
        {
            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
            {
                InitializeNavigation();
                InitializeBindings();
            }
        }

        void InitializeNavigation()
        {
            // Main Navigation Service for all child views
            var navigationService = NavigationService.Create(navigationFrame);
            mvvmContext.RegisterDefaultService(navigationService);
            // Flyout Service for all child views
            var flyoutService = WindowedDocumentManagerService.CreateFlyoutFormService();
            flyoutService.FormStyle = (form) =>
            {
                var flyout = form as FlyoutDialog;
                flyout.Properties.Style = FlyoutStyle.Popup;
            };
            mvvmContext.RegisterDefaultService("Flyout", flyoutService);
        }
        void InitializeBindings()
        {
            var fluentApi = mvvmContext.OfType<NavigationViewModel>();
            //UI
            //fluentApi.BindCommand(darkThemeBBI, x => x.ChangeTheme);
            // Navigation Items
            //fluentApi.BindCommand(loginButtonItem, x => x.OpenLoginView);
            //fluentApi.SetBinding(usersViewItem, x => x.Visible, x => x.ShowUserCollectionView);
            fluentApi.WithEvent<ElementClickEventArgs>(accordionControl1, nameof(accordionControl1.ElementClick))
                .EventToCommand(x => x.NavigateTo, args => CreateNavigateArgs(args));
            // BreadCrumb Navigation
            fluentApi.SetBinding(breadCrumbEdit1, x => x.SelectedNode, x => x.SelectedNode);
            fluentApi.SetBinding(breadCrumbEdit1, x => x.EditValue, x => x.NavigationPath);
            fluentApi.SetBinding(pnlNavigationBar, x => x.Visible, x => x.NavigationBarVisible);
            var navigationContext = new NavigationContext(breadCrumbEdit1.Properties.Nodes);
            fluentApi.WithEvent(this, nameof(Load))
                .EventToCommand(x => x.Load, (EventArgs args) => navigationContext);
            fluentApi.WithEvent<BreadCrumbNodeClickEventArgs>(breadCrumbEdit1.Properties, nameof(breadCrumbEdit1.Properties.NodeClick))
                .EventToCommand(x => x.NavigateTo, args => CreateNavigateArgs(args));
            // UI synchronization
            accordionControl1.SelectedElement = accPerson;
            fluentApi.SetTrigger(x => x.CurrentViewType, viewType =>
            {
                if (viewType == nameof(PersonListView))
                {
                    accordionControl1.SelectedElement = accPerson;
                }
            });
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
