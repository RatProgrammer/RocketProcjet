using System;
using System.Windows.Forms;
using WPFP.Core;

namespace WPFP.SimpleUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var core = new SimpleCore();
            var simulatorMainForm = new SimulatorMainForm(core);
            core.Form = simulatorMainForm;
            Application.Run(simulatorMainForm);
        }
    }
}
