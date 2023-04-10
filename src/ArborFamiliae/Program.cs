using DevExpress.Skins;
using DevExpress.UserSkins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ArborFamiliae
{
    internal static class Program
    {

        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DatabaseSelectionForm databaseSelectionForm = new DatabaseSelectionForm();
            Application.Run(databaseSelectionForm);


            
        }
    }
}
