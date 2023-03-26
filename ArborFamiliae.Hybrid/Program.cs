using System;
using System.Collections.Generic;
using System.Linq;
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
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTMwNTI4OEAzMjMwMmUzNDJlMzBKSlRkazlnU2YxY2Yrek5iNUFMWWtBbnBOUVNFb3B1MXhHeEgvUzJoRVNrPQ==");
            
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
