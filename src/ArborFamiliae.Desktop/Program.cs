using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ArborFamiliae.Desktop.Services;
using DevExpress.Utils;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraLayout;

namespace ArborFamiliae.Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            XtraMessageBoxServiceHelper.RegisterXtraMessageBoxService();
            DevExpress.XtraEditors.WindowsFormsSettings.LoadApplicationSettings();
            //SplashScreenManager.ShowFluentSplashScreen(logoImageOptions: new ImageOptions() {
            //    SvgImage = Properties.Resources.DevExpress_Logo_Mono,
            //    SvgImageColorizationMode = SvgImageColorizationMode.None
            //});
            ToolTipController.DefaultController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            LayoutControl.AllowCustomizationDefaultValue = false;
            DevExpress.XtraEditors.WindowsFormsSettings.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;

            Application.Run(new MainForm());
        }
    }
}