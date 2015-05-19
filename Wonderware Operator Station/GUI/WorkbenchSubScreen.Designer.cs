namespace Wonderware.Operator_Station
{
    partial class WorkbenchSubScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkbenchSubScreen));
            this.contextMenuStripDockPane = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.plantDisplayHierarchyPopupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.g_StatusBar_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelVerticalSplitLine = new System.Windows.Forms.Panel();
            this.panelViewPort = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStripDockPane.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripDockPane
            // 
            this.contextMenuStripDockPane.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plantDisplayHierarchyPopupToolStripMenuItem});
            this.contextMenuStripDockPane.Name = "contextMenuStripDockPane";
            this.contextMenuStripDockPane.Size = new System.Drawing.Size(235, 26);
            // 
            // plantDisplayHierarchyPopupToolStripMenuItem
            // 
            this.plantDisplayHierarchyPopupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("plantDisplayHierarchyPopupToolStripMenuItem.Image")));
            this.plantDisplayHierarchyPopupToolStripMenuItem.Name = "plantDisplayHierarchyPopupToolStripMenuItem";
            this.plantDisplayHierarchyPopupToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.plantDisplayHierarchyPopupToolStripMenuItem.Text = "Plant Display Hierarchy Popup";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g_StatusBar_Label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1135, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // g_StatusBar_Label
            // 
            this.g_StatusBar_Label.Name = "g_StatusBar_Label";
            this.g_StatusBar_Label.Size = new System.Drawing.Size(0, 17);
            // 
            // panelVerticalSplitLine
            // 
            this.panelVerticalSplitLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVerticalSplitLine.BackColor = System.Drawing.Color.Silver;
            this.panelVerticalSplitLine.Location = new System.Drawing.Point(0, 40);
            this.panelVerticalSplitLine.Name = "panelVerticalSplitLine";
            this.panelVerticalSplitLine.Size = new System.Drawing.Size(1135, 2);
            this.panelVerticalSplitLine.TabIndex = 13;
            // 
            // panelViewPort
            // 
            this.panelViewPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelViewPort.BackColor = System.Drawing.Color.Transparent;
            this.panelViewPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelViewPort.Location = new System.Drawing.Point(0, 5);
            this.panelViewPort.Name = "panelViewPort";
            this.panelViewPort.Size = new System.Drawing.Size(1135, 457);
            this.panelViewPort.TabIndex = 16;
            this.panelViewPort.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(415, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 20;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // WorkbenchSubScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1135, 487);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelViewPort);
            this.Controls.Add(this.panelVerticalSplitLine);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkbenchSubScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkbenchSubScreen_FormClosing);
            this.Load += new System.EventHandler(this.Workbench_Load);
            this.Resize += new System.EventHandler(this.WorkbenchSubScreen_Resize);
            this.contextMenuStripDockPane.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel g_StatusBar_Label;
        private System.Windows.Forms.Panel panelVerticalSplitLine;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDockPane;
        private System.Windows.Forms.ToolStripMenuItem plantDisplayHierarchyPopupToolStripMenuItem;
        private System.Windows.Forms.Panel panelViewPort;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}