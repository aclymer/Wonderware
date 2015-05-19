namespace Wonderware.Operator_Station
{
    partial class MonitorForm
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
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelLastRefresh = new System.Windows.Forms.Label();
            this.labelAverageRefresh = new System.Windows.Forms.Label();
            this.labelNumberSamples = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelLastRedraw = new System.Windows.Forms.Label();
            this.labelAverageRedraw = new System.Windows.Forms.Label();
            this.labelRedrawSamples = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(12, 145);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(426, 23);
            this.buttonReset.TabIndex = 0;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelLastRefresh
            // 
            this.labelLastRefresh.AutoSize = true;
            this.labelLastRefresh.Location = new System.Drawing.Point(20, 38);
            this.labelLastRefresh.Name = "labelLastRefresh";
            this.labelLastRefresh.Size = new System.Drawing.Size(98, 13);
            this.labelLastRefresh.TabIndex = 1;
            this.labelLastRefresh.Text = "Last Refresh : 0 ms";
            // 
            // labelAverageRefresh
            // 
            this.labelAverageRefresh.AutoSize = true;
            this.labelAverageRefresh.Location = new System.Drawing.Point(20, 63);
            this.labelAverageRefresh.Name = "labelAverageRefresh";
            this.labelAverageRefresh.Size = new System.Drawing.Size(118, 13);
            this.labelAverageRefresh.TabIndex = 2;
            this.labelAverageRefresh.Text = "Average Refresh : 0 ms";
            // 
            // labelNumberSamples
            // 
            this.labelNumberSamples.AutoSize = true;
            this.labelNumberSamples.Location = new System.Drawing.Point(20, 88);
            this.labelNumberSamples.Name = "labelNumberSamples";
            this.labelNumberSamples.Size = new System.Drawing.Size(112, 13);
            this.labelNumberSamples.TabIndex = 3;
            this.labelNumberSamples.Text = "Number of samples : 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelLastRefresh);
            this.groupBox1.Controls.Add(this.labelNumberSamples);
            this.groupBox1.Controls.Add(this.labelAverageRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 121);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GetData";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelRedrawSamples);
            this.groupBox2.Controls.Add(this.labelLastRedraw);
            this.groupBox2.Controls.Add(this.labelAverageRedraw);
            this.groupBox2.Location = new System.Drawing.Point(227, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 121);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Redraw";
            // 
            // labelLastRedraw
            // 
            this.labelLastRedraw.AutoSize = true;
            this.labelLastRedraw.Location = new System.Drawing.Point(20, 38);
            this.labelLastRedraw.Name = "labelLastRedraw";
            this.labelLastRedraw.Size = new System.Drawing.Size(98, 13);
            this.labelLastRedraw.TabIndex = 1;
            this.labelLastRedraw.Text = "Last Refresh : 0 ms";
            // 
            // labelAverageRedraw
            // 
            this.labelAverageRedraw.AutoSize = true;
            this.labelAverageRedraw.Location = new System.Drawing.Point(20, 63);
            this.labelAverageRedraw.Name = "labelAverageRedraw";
            this.labelAverageRedraw.Size = new System.Drawing.Size(118, 13);
            this.labelAverageRedraw.TabIndex = 2;
            this.labelAverageRedraw.Text = "Average Refresh : 0 ms";
            // 
            // labelRedrawSamples
            // 
            this.labelRedrawSamples.AutoSize = true;
            this.labelRedrawSamples.Location = new System.Drawing.Point(20, 88);
            this.labelRedrawSamples.Name = "labelRedrawSamples";
            this.labelRedrawSamples.Size = new System.Drawing.Size(112, 13);
            this.labelRedrawSamples.TabIndex = 4;
            this.labelRedrawSamples.Text = "Number of samples : 0";
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 180);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(466, 214);
            this.MinimumSize = new System.Drawing.Size(466, 214);
            this.Name = "MonitorForm";
            this.Text = "Refresh Rate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelLastRefresh;
        private System.Windows.Forms.Label labelAverageRefresh;
        private System.Windows.Forms.Label labelNumberSamples;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelLastRedraw;
        private System.Windows.Forms.Label labelAverageRedraw;
        private System.Windows.Forms.Label labelRedrawSamples;
    }
}