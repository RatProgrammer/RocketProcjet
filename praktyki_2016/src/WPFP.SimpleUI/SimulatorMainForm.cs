using System;
using System.Windows.Forms;
using WPFP.CommunicationLayer.Interfaces;

namespace WPFP.SimpleUI
{
    public partial class SimulatorMainForm : Form, ISimpleView
    {
        private readonly ISimpleCore _simpleCore;

        public SimulatorMainForm(ISimpleCore core)
        {
            _simpleCore = core;
            InitializeComponent();
        }

        public void DisplayOnUi(string formattedStateResponse)
        {
            var text = string.Format("{0}  - {1} \n", DateTime.Now, formattedStateResponse) ;
            rtbOutput.AppendText(text);
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {

            string fileName = @"actionsMacro.txt";
            //string fileName = @"combination.txt";
            _simpleCore.PerformMacroFromFile(fileName);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            _simpleCore.PerformAction(txtAction.Text);
        }

        private void SimulatorMainForm_Load(object sender, EventArgs e)
        {
            _simpleCore.DisplayStartInfo();
        }
    }
}
