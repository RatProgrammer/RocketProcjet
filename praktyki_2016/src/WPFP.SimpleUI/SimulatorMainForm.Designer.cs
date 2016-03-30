namespace WPFP.SimpleUI
{
    partial class SimulatorMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.grpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(12, 12);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(357, 292);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(232, 17);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(119, 23);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnLoadFile);
            this.grpControl.Controls.Add(this.txtAction);
            this.grpControl.Controls.Add(this.btnExecute);
            this.grpControl.Location = new System.Drawing.Point(12, 310);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(357, 83);
            this.grpControl.TabIndex = 2;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Control Panel";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFile.Location = new System.Drawing.Point(232, 54);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(119, 23);
            this.btnLoadFile.TabIndex = 4;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(7, 20);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(204, 20);
            this.txtAction.TabIndex = 3;
            this.txtAction.Text = "Marketing 100";
            // 
            // SimulatorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 404);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.rtbOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SimulatorMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimulatorMainForm";
            this.Load += new System.EventHandler(this.SimulatorMainForm_Load);
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtAction;
    }
}

