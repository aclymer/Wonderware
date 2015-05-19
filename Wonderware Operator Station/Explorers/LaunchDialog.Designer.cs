namespace Wonderware.Operator_Station
{
    partial class LaunchDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchDialog));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFunctionDiagrams_count = new System.Windows.Forms.Label();
            this.labelFunctionDiagrams = new System.Windows.Forms.Label();
            this.progressBarFunctionDiagrams = new System.Windows.Forms.ProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 70);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(549, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "hello";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // labelFunctionDiagrams_count
            // 
            this.labelFunctionDiagrams_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFunctionDiagrams_count.AutoSize = true;
            this.labelFunctionDiagrams_count.ForeColor = System.Drawing.Color.Black;
            this.labelFunctionDiagrams_count.Location = new System.Drawing.Point(492, 23);
            this.labelFunctionDiagrams_count.Name = "labelFunctionDiagrams_count";
            this.labelFunctionDiagrams_count.Size = new System.Drawing.Size(13, 13);
            this.labelFunctionDiagrams_count.TabIndex = 61;
            this.labelFunctionDiagrams_count.Text = "0";
            // 
            // labelFunctionDiagrams
            // 
            this.labelFunctionDiagrams.AutoSize = true;
            this.labelFunctionDiagrams.ForeColor = System.Drawing.Color.Black;
            this.labelFunctionDiagrams.Location = new System.Drawing.Point(27, 23);
            this.labelFunctionDiagrams.Name = "labelFunctionDiagrams";
            this.labelFunctionDiagrams.Size = new System.Drawing.Size(74, 13);
            this.labelFunctionDiagrams.TabIndex = 60;
            this.labelFunctionDiagrams.Text = "HMI Diagrams";
            // 
            // progressBarFunctionDiagrams
            // 
            this.progressBarFunctionDiagrams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarFunctionDiagrams.ForeColor = System.Drawing.Color.Violet;
            this.progressBarFunctionDiagrams.Location = new System.Drawing.Point(128, 17);
            this.progressBarFunctionDiagrams.Name = "progressBarFunctionDiagrams";
            this.progressBarFunctionDiagrams.Size = new System.Drawing.Size(352, 23);
            this.progressBarFunctionDiagrams.TabIndex = 59;
            // 
            // LaunchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 92);
            this.Controls.Add(this.labelFunctionDiagrams_count);
            this.Controls.Add(this.labelFunctionDiagrams);
            this.Controls.Add(this.progressBarFunctionDiagrams);
            this.Controls.Add(this.statusStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(565, 126);
            this.MinimumSize = new System.Drawing.Size(565, 126);
            this.Name = "LaunchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulator Workbench";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaunchDialog_FormClosing);
            this.Load += new System.EventHandler(this.LaunchDialog_Load);
            this.Shown += new System.EventHandler(this.LaunchDialog_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label labelFunctionDiagrams_count;
        private System.Windows.Forms.Label labelFunctionDiagrams;
        private System.Windows.Forms.ProgressBar progressBarFunctionDiagrams;
    }
}