using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ArborFamiliae.Hybrid
{
    internal static class Program
    {
        #if DEBUG
        [DllImport( "kernel32.dll" )]
        static extern bool AttachConsole( int dwProcessId );
        private const int ATTACH_PARENT_PROCESS = -1;
        #endif
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ3MzI4NEAzMjMxMmUzMTJlMzMzNU1wUnBEOGRENWFNb3grdFhyclhiWjV4bHlNUnFTdWVJbC9nZTk1WEdXRE09");
            
            #if DEBUG
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole( ATTACH_PARENT_PROCESS );
            #endif
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
