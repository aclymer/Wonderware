using Wonderware.Data;
using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wonderware.Operator_Station
{
    public partial class LaunchDialog : Form
    {
        public LaunchDialog(String p_sDatabasePath)
        {
            InitializeComponent();
            DatabasePath = p_sDatabasePath;
            Database = new Database();
            Done = false;
            Success = false;
        }

        public Database Database;
        public String DatabasePath;

        private void LaunchDialog_Load(object sender, EventArgs e)
        {

        }

        private void LaunchDialog_Shown(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Loading Wonderware Database files ...";
            m_LoadAsyncTask = new Task(() => Database.LoadAsync(DatabasePath));
            m_LoadAsyncTask.Start();
            m_LoadAsyncTimer = new Timer();
            m_LoadAsyncTimer.Interval = 100;
            m_LoadAsyncTimer.Start();
            ClearAllProgressBars();
            m_LoadAsyncTimer.Tick += LoadAsyncTimer_Tick;
        }

        private Task m_LoadAsyncTask;
        private Timer m_LoadAsyncTimer;

        void LoadAsyncTimer_Tick(object sender, EventArgs e)
        {
            if (m_LoadAsyncTask != null)
            {
                if (m_LoadAsyncTask.IsCompleted == true)
                {
                    if (m_LoadAsyncTask.Status == TaskStatus.RanToCompletion && m_LoadAsyncTask.Exception == null)
                    {
                        Success = true;
                        m_LoadAsyncTimer.Stop();
                        this.Invoke(new InvokeOnGUIThread(this.SetAllProgressBars));
                        this.Invoke(new InvokeOnGUIThread(this.OnFinishLaunch));
                    }
                    else
                    {
                        m_LoadAsyncTimer.Stop();
                        this.Invoke(new InvokeOnGUIThread(this.SetAllProgressBars));
                        this.Invoke(new InvokeOnGUIThread(this.OnFinishLaunch));
                    }
                    m_LoadAsyncTask = null;
                    Done = true;
                    this.Close();
                    return;
                }
                this.Invoke(new InvokeOnGUIThread(this.SetAllProgressBars));
            }
        }

        public bool Done;
        public bool Success;
        private delegate void InvokeOnGUIThread();

        private void OnFinishLaunch()
        {
            if (Success == true)
            {
                this.toolStripStatusLabel1.Text = "Done";
            }
            else
            {
                this.toolStripStatusLabel1.Text = "Error";
            }
        }

        private void SetAllProgressBars()
        {
            SetProgressBarAndCount(progressBarFunctionDiagrams, labelFunctionDiagrams_count, Database.HMIDiagramsCount, Database.HMIDiagramsTotal);
        }

        private void ClearAllProgressBars()
        {
            SetProgressBarAndCount(progressBarFunctionDiagrams, labelFunctionDiagrams_count, 0, 100);
        }

        private void SetProgressBarAndCount(ProgressBar p_ProgressBar, Label p_Label, int p_iCount, int p_iTotal)
        {
            p_ProgressBar.Minimum = 0;
            p_ProgressBar.Maximum = p_iTotal;
            p_ProgressBar.Value = p_iCount;
            p_Label.Text = p_iCount + "/" + p_iTotal;
        }

        private void LaunchDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Done == false)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
