namespace Wonderware.Operator_Station
{
    partial class HMIDiagramDockContent
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
                HMIDiagramElementHost l_PlantDisplayElementHost = m_HMIDiagramControl as HMIDiagramElementHost;
                if (l_PlantDisplayElementHost != null)
                {
                    l_PlantDisplayElementHost.DisposeChildren();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HMIDiagramDockContent));
            this.contextMenuStripPlantDisplay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFaceplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInConfigurationModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosticViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forcePortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigate_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.leftInHierarchyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upInHierarchyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downInHierarchyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightInHierarchyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plantDisplayHierarchyPopupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPlantDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripPlantDisplay
            // 
            this.contextMenuStripPlantDisplay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFaceplateToolStripMenuItem,
            this.openInConfigurationModeToolStripMenuItem,
            this.pointViewToolStripMenuItem,
            this.diagnosticViewToolStripMenuItem,
            this.aSDToolStripMenuItem,
            this.forcePortsToolStripMenuItem,
            this.notesToolStripMenuItem,
            this.diagramVersionToolStripMenuItem,
            this.navigate_ToolStripMenuItem,
            this.view_ToolStripMenuItem,
            this.toolStripSeparator1,
            this.windowToolStripMenuItem,
            this.plantDisplayHierarchyPopupToolStripMenuItem});
            this.contextMenuStripPlantDisplay.Name = "contextMenuStripPlantDisplay";
            this.contextMenuStripPlantDisplay.Size = new System.Drawing.Size(240, 274);
            // 
            // openFaceplateToolStripMenuItem
            // 
            this.openFaceplateToolStripMenuItem.Enabled = false;
            this.openFaceplateToolStripMenuItem.Name = "openFaceplateToolStripMenuItem";
            this.openFaceplateToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openFaceplateToolStripMenuItem.Text = "Open Faceplate ...";
            // 
            // openInConfigurationModeToolStripMenuItem
            // 
            this.openInConfigurationModeToolStripMenuItem.Enabled = false;
            this.openInConfigurationModeToolStripMenuItem.Name = "openInConfigurationModeToolStripMenuItem";
            this.openInConfigurationModeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openInConfigurationModeToolStripMenuItem.Text = "Open in Configuration Mode ...";
            // 
            // pointViewToolStripMenuItem
            // 
            this.pointViewToolStripMenuItem.Enabled = false;
            this.pointViewToolStripMenuItem.Name = "pointViewToolStripMenuItem";
            this.pointViewToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.pointViewToolStripMenuItem.Text = "Point View ...";
            // 
            // diagnosticViewToolStripMenuItem
            // 
            this.diagnosticViewToolStripMenuItem.Enabled = false;
            this.diagnosticViewToolStripMenuItem.Name = "diagnosticViewToolStripMenuItem";
            this.diagnosticViewToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.diagnosticViewToolStripMenuItem.Text = "Diagnostic View ...";
            // 
            // aSDToolStripMenuItem
            // 
            this.aSDToolStripMenuItem.Enabled = false;
            this.aSDToolStripMenuItem.Name = "aSDToolStripMenuItem";
            this.aSDToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.aSDToolStripMenuItem.Text = "ASD ...";
            // 
            // forcePortsToolStripMenuItem
            // 
            this.forcePortsToolStripMenuItem.Enabled = false;
            this.forcePortsToolStripMenuItem.Name = "forcePortsToolStripMenuItem";
            this.forcePortsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.forcePortsToolStripMenuItem.Text = "Force Ports ...";
            // 
            // notesToolStripMenuItem
            // 
            this.notesToolStripMenuItem.Enabled = false;
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            this.notesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.notesToolStripMenuItem.Text = "Notes ...";
            // 
            // diagramVersionToolStripMenuItem
            // 
            this.diagramVersionToolStripMenuItem.Enabled = false;
            this.diagramVersionToolStripMenuItem.Name = "diagramVersionToolStripMenuItem";
            this.diagramVersionToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.diagramVersionToolStripMenuItem.Text = "Diagram Version ...";
            // 
            // navigate_ToolStripMenuItem
            // 
            this.navigate_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.leftInHierarchyToolStripMenuItem,
            this.upInHierarchyToolStripMenuItem,
            this.downInHierarchyToolStripMenuItem,
            this.rightInHierarchyToolStripMenuItem});
            this.navigate_ToolStripMenuItem.Name = "navigate_ToolStripMenuItem";
            this.navigate_ToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.navigate_ToolStripMenuItem.Text = "Navigate";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // leftInHierarchyToolStripMenuItem
            // 
            this.leftInHierarchyToolStripMenuItem.Enabled = false;
            this.leftInHierarchyToolStripMenuItem.Name = "leftInHierarchyToolStripMenuItem";
            this.leftInHierarchyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.leftInHierarchyToolStripMenuItem.Text = "Left in Hierarchy";
            // 
            // upInHierarchyToolStripMenuItem
            // 
            this.upInHierarchyToolStripMenuItem.Enabled = false;
            this.upInHierarchyToolStripMenuItem.Name = "upInHierarchyToolStripMenuItem";
            this.upInHierarchyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.upInHierarchyToolStripMenuItem.Text = "Up in Hierarchy";
            // 
            // downInHierarchyToolStripMenuItem
            // 
            this.downInHierarchyToolStripMenuItem.Enabled = false;
            this.downInHierarchyToolStripMenuItem.Name = "downInHierarchyToolStripMenuItem";
            this.downInHierarchyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.downInHierarchyToolStripMenuItem.Text = "Down in Hierarchy";
            // 
            // rightInHierarchyToolStripMenuItem
            // 
            this.rightInHierarchyToolStripMenuItem.Enabled = false;
            this.rightInHierarchyToolStripMenuItem.Name = "rightInHierarchyToolStripMenuItem";
            this.rightInHierarchyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.rightInHierarchyToolStripMenuItem.Text = "Right in Hierarchy";
            // 
            // view_ToolStripMenuItem
            // 
            this.view_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fitToPageToolStripMenuItem});
            this.view_ToolStripMenuItem.Name = "view_ToolStripMenuItem";
            this.view_ToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.view_ToolStripMenuItem.Text = "View";
            // 
            // fitToPageToolStripMenuItem
            // 
            this.fitToPageToolStripMenuItem.Enabled = false;
            this.fitToPageToolStripMenuItem.Name = "fitToPageToolStripMenuItem";
            this.fitToPageToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.fitToPageToolStripMenuItem.Text = "Fit to Page";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveWindowToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // moveWindowToolStripMenuItem
            // 
            this.moveWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenAToolStripMenuItem,
            this.screenBToolStripMenuItem});
            this.moveWindowToolStripMenuItem.Name = "moveWindowToolStripMenuItem";
            this.moveWindowToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.moveWindowToolStripMenuItem.Text = "Move Window";
            // 
            // screenAToolStripMenuItem
            // 
            this.screenAToolStripMenuItem.Enabled = false;
            this.screenAToolStripMenuItem.Name = "screenAToolStripMenuItem";
            this.screenAToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.screenAToolStripMenuItem.Text = "Screen A";
            // 
            // screenBToolStripMenuItem
            // 
            this.screenBToolStripMenuItem.Enabled = false;
            this.screenBToolStripMenuItem.Name = "screenBToolStripMenuItem";
            this.screenBToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.screenBToolStripMenuItem.Text = "Screen B";
            // 
            // plantDisplayHierarchyPopupToolStripMenuItem
            // 
            this.plantDisplayHierarchyPopupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("plantDisplayHierarchyPopupToolStripMenuItem.Image")));
            this.plantDisplayHierarchyPopupToolStripMenuItem.Name = "plantDisplayHierarchyPopupToolStripMenuItem";
            this.plantDisplayHierarchyPopupToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.plantDisplayHierarchyPopupToolStripMenuItem.Text = "Plant Display Hierarchy Popup";
            // 
            // PlantDisplayDockContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ContextMenuStrip = this.contextMenuStripPlantDisplay;
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PlantDisplayDockContent";
            this.ShowIcon = false;
            this.Text = "Plant Display";
            this.Shown += new System.EventHandler(this.PlantDisplayDockContent_Shown);
            this.contextMenuStripPlantDisplay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripPlantDisplay;
        private System.Windows.Forms.ToolStripMenuItem openFaceplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInConfigurationModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagnosticViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forcePortsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagramVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigate_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem leftInHierarchyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upInHierarchyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downInHierarchyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightInHierarchyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plantDisplayHierarchyPopupToolStripMenuItem;
    }
}