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
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjkxMzMzOUAzMjMzMmUzMDJlMzBKK3Q5RVVFZy84WVUzREFUdEU5Y0x1aHFib0dmVFE3MU5OQkJJa295L2c4PQ==");
            
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
