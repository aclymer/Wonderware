using Wonderware.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wonderware.Process_Connection;
using Wonderware.Management;
using System.Diagnostics;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Drawing;

namespace Wonderware.Operator_Station
{
    partial class WorkbenchSubScreen : WeifenLuo.WinFormsUI.Docking.FloatWindow
    {
        private void Workbench_Load(object sender, EventArgs e)
        {
        }

        public override Rectangle DisplayingRectangle
        {
            get
            {
                return new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width, ClientRectangle.Height - statusStrip1.Height);
            }
        }

        public WorkbenchSubScreen(DockPanel dockPanel, DockPane pane)
            : base(dockPanel, pane)
        {
            Init();
        }

        public WorkbenchSubScreen(DockPanel dockPanel, DockPane pane, System.Drawing.Rectangle bounds)
            : base(dockPanel, pane, bounds)
        {
            Init();
        }

        void Init()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            ShowInTaskbar = true;
            Owner = null;
			BackColor = Color.LightGray;
            DoubleClickTitleBarToDock = false;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void buttonPDH_Click_1(object sender, EventArgs e)
        {
        }

        private void WorkbenchSubScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void UpdateGUI()
        {
        }

        private void WorkbenchSubScreen_Resize(object sender, EventArgs e)
        {
            //RepositionMainDisplay();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            //RepositionMainDisplay();
        }

        private void RepositionMainDisplay()
        {
            //double l_dMenuStripCenter = menuStripMain.Width / 2.0;
            //double l_dMainDisplayCenter = flowLayoutPanel1.Width / 2.0;
            //flowLayoutPanel1.Location = new System.Drawing.Point(System.Convert.ToInt32(l_dMenuStripCenter - l_dMainDisplayCenter), flowLayoutPanel1.Location.Y);
        }

        private void buttonAlarmSystemDisplay_Click(object sender, EventArgs e)
        {
        }
    }
}
