using WeifenLuo.WinFormsUI.Docking;

namespace Wonderware.Operator_Station
{
    partial class Workbench
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

        private WeifenLuo.WinFormsUI.Docking.DockPanel g_Main_DockPanel;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel g_StatusBar_Label;
        private System.Windows.Forms.ToolStripMenuItem processConnectionSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem dataPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxDataPath;
        private System.Windows.Forms.ToolStripMenuItem connectedToServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBoxServerPort;
        private System.Windows.Forms.ToolStripMenuItem connectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxServerIP;
        private System.Windows.Forms.ToolStripMenuItem refreshRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxRefreshRate;
        private System.Windows.Forms.ToolStripMenuItem monitorToolStripMenuItem;
        private System.Windows.Forms.Panel panelVerticalSplitLine;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workbench));
            this.g_Main_DockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.processConnectionSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxDataPath = new System.Windows.Forms.ToolStripTextBox();
            this.connectedToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxServerIP = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxServerPort = new System.Windows.Forms.ToolStripMenuItem();
            this.connectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxRefreshRate = new System.Windows.Forms.ToolStripTextBox();
            this.monitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_AllHMIDiagramsLoaded = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.g_StatusBar_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelVerticalSplitLine = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStripMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // g_Main_DockPanel
            // 
            this.g_Main_DockPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_Main_DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_Main_DockPanel.Location = new System.Drawing.Point(0, 0);
            this.g_Main_DockPanel.Name = "g_Main_DockPanel";
            this.g_Main_DockPanel.ShowAutoHideContentOnHover = false;
            this.g_Main_DockPanel.Size = new System.Drawing.Size(1136, 474);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.g_Main_DockPanel.Skin = dockPanelSkin1;
            this.g_Main_DockPanel.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.AutoSize = false;
            this.menuStripMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.g_AllHMIDiagramsLoaded});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1136, 40);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.exitToolStripMenuItem,
            this.toolStripSeparator3,
            this.processConnectionSetupToolStripMenuItem});
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(37, 36);
            this.applicationsToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(155, 6);
            // 
            // processConnectionSetupToolStripMenuItem
            // 
            this.processConnectionSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataPathToolStripMenuItem,
            this.connectedToServerToolStripMenuItem});
            this.processConnectionSetupToolStripMenuItem.Name = "processConnectionSetupToolStripMenuItem";
            this.processConnectionSetupToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.processConnectionSetupToolStripMenuItem.Text = "Simulator Setup";
            this.processConnectionSetupToolStripMenuItem.DropDownOpening += new System.EventHandler(this.processConnectionSetupToolStripMenuItem_DropDownOpening);
            // 
            // dataPathToolStripMenuItem
            // 
            this.dataPathToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxDataPath});
            this.dataPathToolStripMenuItem.Name = "dataPathToolStripMenuItem";
            this.dataPathToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.dataPathToolStripMenuItem.Text = "Data Path";
            // 
            // toolStripTextBoxDataPath
            // 
            this.toolStripTextBoxDataPath.Name = "toolStripTextBoxDataPath";
            this.toolStripTextBoxDataPath.ReadOnly = true;
            this.toolStripTextBoxDataPath.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxDataPath.TextChanged += new System.EventHandler(this.toolStripTextBoxDataPath_TextChanged);
            // 
            // connectedToServerToolStripMenuItem
            // 
            this.connectedToServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverIPToolStripMenuItem,
            this.toolStripTextBoxServerPort,
            this.connectedToolStripMenuItem,
            this.reconnectToolStripMenuItem,
            this.refreshRateToolStripMenuItem,
            this.monitorToolStripMenuItem});
            this.connectedToServerToolStripMenuItem.Name = "connectedToServerToolStripMenuItem";
            this.connectedToServerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.connectedToServerToolStripMenuItem.Text = "Process Connection";
            // 
            // serverIPToolStripMenuItem
            // 
            this.serverIPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxServerIP});
            this.serverIPToolStripMenuItem.Name = "serverIPToolStripMenuItem";
            this.serverIPToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.serverIPToolStripMenuItem.Text = "ServerIP";
            // 
            // toolStripTextBoxServerIP
            // 
            this.toolStripTextBoxServerIP.Name = "toolStripTextBoxServerIP";
            this.toolStripTextBoxServerIP.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxServerIP.TextChanged += new System.EventHandler(this.toolStripTextBoxServerIP_TextChanged);
            // 
            // toolStripTextBoxServerPort
            // 
            this.toolStripTextBoxServerPort.Name = "toolStripTextBoxServerPort";
            this.toolStripTextBoxServerPort.Size = new System.Drawing.Size(136, 22);
            this.toolStripTextBoxServerPort.Text = "ServerPort";
            // 
            // connectedToolStripMenuItem
            // 
            this.connectedToolStripMenuItem.Name = "connectedToolStripMenuItem";
            this.connectedToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.connectedToolStripMenuItem.Text = "Connected";
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
            // 
            // refreshRateToolStripMenuItem
            // 
            this.refreshRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxRefreshRate});
            this.refreshRateToolStripMenuItem.Name = "refreshRateToolStripMenuItem";
            this.refreshRateToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.refreshRateToolStripMenuItem.Text = "RefreshRate";
            // 
            // toolStripTextBoxRefreshRate
            // 
            this.toolStripTextBoxRefreshRate.Name = "toolStripTextBoxRefreshRate";
            this.toolStripTextBoxRefreshRate.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxRefreshRate.TextChanged += new System.EventHandler(this.toolStripTextBoxRefreshRate_TextChanged);
            // 
            // monitorToolStripMenuItem
            // 
            this.monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            this.monitorToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.monitorToolStripMenuItem.Text = "Monitor";
            this.monitorToolStripMenuItem.Click += new System.EventHandler(this.monitorToolStripMenuItem_Click);
            // 
            // g_AllHMIDiagramsLoaded
            // 
            this.g_AllHMIDiagramsLoaded.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.g_AllHMIDiagramsLoaded.AutoSize = false;
            this.g_AllHMIDiagramsLoaded.DropDownWidth = 600;
            this.g_AllHMIDiagramsLoaded.MaxDropDownItems = 20;
            this.g_AllHMIDiagramsLoaded.Name = "g_AllHMIDiagramsLoaded";
            this.g_AllHMIDiagramsLoaded.Size = new System.Drawing.Size(600, 23);
            this.g_AllHMIDiagramsLoaded.Sorted = true;
            this.g_AllHMIDiagramsLoaded.SelectedIndexChanged += new System.EventHandler(this.g_AllHMIDiagramsLoaded_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g_StatusBar_Label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1136, 22);
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
            this.panelVerticalSplitLine.Size = new System.Drawing.Size(1136, 2);
            this.panelVerticalSplitLine.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(422, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 19;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // Workbench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1136, 474);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelVerticalSplitLine);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.g_Main_DockPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "Workbench";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wonderware Workbench";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Workbench_Load);
            this.Resize += new System.EventHandler(this.Workbench_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripComboBox g_AllHMIDiagramsLoaded;
    }
}