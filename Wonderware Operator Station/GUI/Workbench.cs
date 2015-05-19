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

namespace Wonderware.Operator_Station
{
	partial class Workbench : Form
	{
		static public Workbench Instance;
		static public int RefreshRate = 500;
		static public double Samples = 0;
		static public double TotalRefreshTime = 0;
		static public double AverageRefreshTime = 0;
		static public double LastRefreshTime = 0;
		static public double RedrawSamples = 0;
		static public double TotalRedrawTime = 0;
		static public double AverageRedrawTime = 0;
		static public double LastRedrawTime = 0;
		static public String ServerIP = "localhost";
		static public String ServerPort = "15951";
		private Database m_Wonderware_Database;
		private System.Threading.Timer UpdateDataTimer;
		private bool Busy = false;
		private string m_sDatabasePath;
		private Dictionary<HMIDiagram, HMIDiagramDockContent> m_HMIDiagramViews;
		public HMIDiagram FocusedHMIDiagram;
		private MonitorForm MonitorForm;

		public Workbench(Database p_Database)
		{
			Init(p_Database);
			g_Main_DockPanel.Extender.FloatWindowFactory = new CustomFloatWindowFactory();
			Debug.Assert(Instance == null, "Only one instance of Workbench allowed");
			Instance = this;
		}

		void Init(Database p_Database)
		{
			InitializeComponent();
			m_sDatabasePath = p_Database.m_RootPath.FullName;
			Debug.WriteLine("Database path for Workbench is :" + m_sDatabasePath, Database.InfoTitle);
			m_Wonderware_Database = p_Database;
			m_HMIDiagramViews = new Dictionary<HMIDiagram, HMIDiagramDockContent>();
		}

		private void Workbench_Load(object sender, EventArgs e)
		{
			TimerCallback l_UpdateData = UpdateData;
			UpdateDataTimer = new System.Threading.Timer(l_UpdateData);
			UpdateDataTimer.Change(5000, RefreshRate);
			g_StatusBar_Label.Text = String.Empty;
			foreach (HMIDiagram l_HMIDiagram in m_Wonderware_Database.GetHMIDiagrams().Values)
			{
				g_AllHMIDiagramsLoaded.Items.Add(l_HMIDiagram.ID);
			}
		}

		private void UpdateData(Object stateInfo)
		{
			if (Busy == false && this.IsDisposed == false)
			{
				Busy = true;

				Stopwatch l_TimeRefresh = new Stopwatch();
				l_TimeRefresh.Start();
				ProcessConnectionClient.Instance.GetData();
				l_TimeRefresh.Stop();
				LastRefreshTime = l_TimeRefresh.ElapsedTicks / System.Convert.ToDouble(Stopwatch.Frequency);
				TotalRefreshTime += LastRefreshTime;
				Samples++;
				AverageRefreshTime = TotalRefreshTime / Samples;

				Stopwatch l_TimeRedraw = new Stopwatch();
				l_TimeRedraw.Start();
				try
				{
					this.Invoke(new EventHandler(Draw));
					this.Invoke(new EventHandler(UpdateGUI));
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Workbench Draw() / UpdateGUI() exception occured : " + ex.Message, Database.InfoTitle);
				}
				l_TimeRedraw.Stop();
				LastRedrawTime = l_TimeRedraw.ElapsedTicks / System.Convert.ToDouble(Stopwatch.Frequency);
				TotalRedrawTime += LastRedrawTime;
				RedrawSamples++;
				AverageRedrawTime = TotalRedrawTime / RedrawSamples;

				Busy = false;
			}
		}

		private void UpdateGUI(Object sender, EventArgs l_EventArgs)
		{
			try
			{
				foreach (HMIDiagramDockContent l_PlantDisplayDockContent in m_HMIDiagramViews.Values)
				{
					if (l_PlantDisplayDockContent.DockState != DockState.Float &&
						l_PlantDisplayDockContent != g_Main_DockPanel.ActiveDocument)
					{
						continue; // only draw visible doc content
					}
					if (l_PlantDisplayDockContent.DockState == DockState.Float &&
						l_PlantDisplayDockContent.FloatPane.ActiveContent != l_PlantDisplayDockContent)
					{
						continue; // only draw visible doc content
					}
					IDynamicDataGraphic l_DynamicDataGraphic = l_PlantDisplayDockContent as IDynamicDataGraphic;
					if (l_DynamicDataGraphic != null)
					{
						l_DynamicDataGraphic.UpdateGUI();
					}
				}
				if (MonitorForm != null)
				{
					MonitorForm.UpdateGUI();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Unknown exceptino occured during GUIUpdate() : " + ex.Message);
			}
		}

		private void Draw(Object sender, EventArgs l_EventArgs)
		{
			try
			{
				foreach (HMIDiagramDockContent l_PlantDisplayDockContent in m_HMIDiagramViews.Values)
				{
					if (l_PlantDisplayDockContent.DockState != DockState.Float &&
						l_PlantDisplayDockContent != g_Main_DockPanel.ActiveDocument)
					{
						continue; // only draw visible doc content
					}
					if (l_PlantDisplayDockContent.DockState == DockState.Float &&
						l_PlantDisplayDockContent.FloatPane.ActiveContent != l_PlantDisplayDockContent)
					{
						continue; // only draw visible doc content
					}
					IDynamicDataGraphic l_DynamicDataGraphic = l_PlantDisplayDockContent as IDynamicDataGraphic;
					if (l_DynamicDataGraphic != null)
					{
						l_DynamicDataGraphic.Draw();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Unknown exceptino occured during Draw() : " + ex.Message);
			}
		}

		public Database Database
		{
			get { return m_Wonderware_Database; }
		}

		public HMIDiagram GetHMIDiagram(String p_sID)
		{
			return m_Wonderware_Database.GetHMIDiagram(p_sID);
		}

		public void SwitchHMIDiagram(String p_sID)
		{
			HMIDiagram l_HMIDiagram = GetHMIDiagram(p_sID);
			if (l_HMIDiagram != null)
			{
				AddHMIDiagramView(l_HMIDiagram);
				long l_iMemoryAllocated = GC.GetTotalMemory(true);
				GC.Collect();
			}
		}

		private bool ContainsHMIDiagramViewViewFor(HMIDiagram p_HMIDiagram)
		{
			return m_HMIDiagramViews.ContainsKey(p_HMIDiagram);
		}

		public HMIDiagramDockContent GetHMIDiagramView(HMIDiagram p_HMIDiagram)
		{
			if (ContainsHMIDiagramViewViewFor(p_HMIDiagram) == true)
			{
				return m_HMIDiagramViews[p_HMIDiagram];
			}
			return null;
		}

		private void AddHMIDiagramView(HMIDiagram p_HMIDiagram)
		{
			HMIDiagramDockContent l_HMIDiagramView = GetHMIDiagramView(p_HMIDiagram);
			if (l_HMIDiagramView == null)
			{
				l_HMIDiagramView = new HMIDiagramDockContent(p_HMIDiagram, m_Wonderware_Database);
				l_HMIDiagramView.FormClosed += plantDisplayView_FormClosed;
				l_HMIDiagramView.Disposed += plantDisplayView_Disposed;
				m_HMIDiagramViews[p_HMIDiagram] = l_HMIDiagramView;
			}
			if (FocusedHMIDiagram != null)
			{
				HMIDiagramDockContent l_Focused_HMIDiagramView = GetHMIDiagramView(FocusedHMIDiagram);
				if (l_Focused_HMIDiagramView != null &&
					l_Focused_HMIDiagramView.IsHidden == false &&
					l_Focused_HMIDiagramView.IsFloat == true &&
					l_Focused_HMIDiagramView.FloatPane != null)
				{
					l_HMIDiagramView.Show(g_Main_DockPanel, DockState.Float);
					l_HMIDiagramView.DockTo(l_Focused_HMIDiagramView.FloatPane, DockStyle.Fill, -1);
					l_HMIDiagramView.Activate();
				}
				else
				{
					l_HMIDiagramView.Show(g_Main_DockPanel, DockState.Document);
				}
			}
			else
			{
				l_HMIDiagramView.Show(g_Main_DockPanel, DockState.Document);
			}
		}

		void plantDisplayView_Disposed(object sender, EventArgs e)
		{
			HMIDiagramDockContent plantDisplayView = sender as HMIDiagramDockContent;
			if (plantDisplayView != null)
			{
			}
		}

		void plantDisplayView_FormClosed(object sender, FormClosedEventArgs e)
		{
			HMIDiagramDockContent plantDisplayView = sender as HMIDiagramDockContent;
			if (plantDisplayView != null)
			{
				plantDisplayView.Dispose();
				m_HMIDiagramViews.Remove(plantDisplayView.m_HMIDiagram);
				GC.Collect();
				long l_iMemoryAllocated = GC.GetTotalMemory(true);
				File.AppendAllText("test.csv", l_iMemoryAllocated + "\r\n");
			}
		}

		private void processConnectionSetupToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			toolStripTextBoxServerIP.Text = ServerIP;
			toolStripTextBoxServerPort.Text = "Port: " + ServerPort;
			toolStripTextBoxDataPath.Text = m_sDatabasePath;
			if (ProcessConnectionClient.Instance.TestConnection() == true)
			{
				connectedToolStripMenuItem.Checked = true;
				connectedToolStripMenuItem.Text = "Connected";
				reconnectToolStripMenuItem.Enabled = false;
			}
			else
			{
				connectedToolStripMenuItem.Text = "Server Down";
				reconnectToolStripMenuItem.Enabled = true;
				connectedToolStripMenuItem.Checked = false;
			}
			connectedToolStripMenuItem.Enabled = false;
			toolStripTextBoxRefreshRate.Text = RefreshRate.ToString();
		}

		private void toolStripTextBoxDataPath_TextChanged(object sender, EventArgs e)
		{
		}

		private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessConnectionClient.Instance.ReconnectConnectToServer();
		}

		private void toolStripTextBoxServerIP_TextChanged(object sender, EventArgs e)
		{
			ServerIP = toolStripTextBoxServerIP.Text;
		}

		private void toolStripTextBoxRefreshRate_TextChanged(object sender, EventArgs e)
		{
			int l_iRefreshRate = RefreshRate;
			if (int.TryParse(toolStripTextBoxRefreshRate.Text, out l_iRefreshRate) == true)
			{
				RefreshRate = l_iRefreshRate;
				if (UpdateDataTimer != null)
				{
					UpdateDataTimer.Change(5000, RefreshRate);
				}
			}
		}

		private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MonitorForm = new MonitorForm();
			MonitorForm.TopMost = true;
			MonitorForm.Show();
		}

		private void Workbench_Resize(object sender, EventArgs e)
		{
			RepositionMainDisplay();
		}

		private void flowLayoutPanel1_Resize(object sender, EventArgs e)
		{
			RepositionMainDisplay();
		}

		private void RepositionMainDisplay()
		{
			double l_dMenuStripCenter = menuStripMain.Width / 2.0;
			double l_dMainDisplayCenter = flowLayoutPanel1.Width / 2.0;
			flowLayoutPanel1.Location = new System.Drawing.Point(System.Convert.ToInt32(l_dMenuStripCenter - l_dMainDisplayCenter), flowLayoutPanel1.Location.Y);
		}

		private void Workbench_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonIandC_Click(object sender, EventArgs e)
		{

		}

		private void toolStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

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

		private void g_AllHMIDiagramsLoaded_SelectedIndexChanged(object sender, EventArgs e)
		{
			String l_sSelectedHMIDiagram = g_AllHMIDiagramsLoaded.SelectedItem as String;
			if (l_sSelectedHMIDiagram != null)
			{
				SwitchHMIDiagram(l_sSelectedHMIDiagram);
			}
		}

	}
}
