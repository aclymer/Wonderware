using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wonderware.Operator_Station
{
    public partial class MonitorForm : Form
    {
        public MonitorForm()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Workbench.LastRefreshTime = 0.0;
            Workbench.TotalRefreshTime = 0.0;
            Workbench.AverageRefreshTime = 0.0;
            Workbench.Samples = 0.0;
            Workbench.LastRedrawTime = 0.0;
            Workbench.TotalRedrawTime = 0.0;
            Workbench.AverageRedrawTime = 0.0;
            Workbench.RedrawSamples = 0.0;
        }

        public void UpdateGUI()
        {
            labelAverageRefresh.Text = "Average refresh : " + System.Math.Round(Workbench.AverageRefreshTime, 6).ToString() + " sec"; ;
            labelLastRefresh.Text = "Last refresh : " + System.Math.Round(Workbench.LastRefreshTime, 6).ToString() + " sec";
            labelNumberSamples.Text = "Number of samples : " + Workbench.Samples.ToString(); ;
            labelLastRedraw.Text = "Last redraw : " + System.Math.Round(Workbench.LastRedrawTime, 6).ToString() + " sec"; ;
            labelAverageRedraw.Text = "Average redraw : " + System.Math.Round(Workbench.AverageRedrawTime, 6).ToString() + " sec";
            labelRedrawSamples.Text = "Number of samples : " + Workbench.RedrawSamples.ToString(); ;
        }
    }
}
