using System.Drawing;
using Wonderware.Data;
using System.Windows.Forms;
using Wonderware.Management;
using WeifenLuo.WinFormsUI.Docking;
using System;
using System.Collections.Generic;

namespace Wonderware.Operator_Station
{
	public partial class HMIDiagramDockContent : DockContent, IDynamicDataGraphic
	{
		public HMIDiagram m_HMIDiagram;
		private Control m_HMIDiagramControl;
		private int DefaultWidth = 1600;
		private int DefaultHeight = 900;

		public HMIDiagramDockContent(HMIDiagram p_HMIDiagram, Database p_Database)
		{
			InitializeComponent();
			m_HMIDiagram = p_HMIDiagram;
			Text = p_HMIDiagram.ID;
			SuspendLayout();
			m_HMIDiagramControl = new HMIDiagramElementHost(m_HMIDiagram, p_Database);
			m_HMIDiagramControl.Dock = DockStyle.Fill;
			m_HMIDiagramControl.BackColor = Grapher.FromDrawingColorStrToDrawingColor(m_HMIDiagram.BGCOLOR);
			m_HMIDiagramControl.SetBounds((int)m_HMIDiagram.DIMENSION.LEFT, (int)m_HMIDiagram.DIMENSION.TOP, (int)m_HMIDiagram.DIMENSION.WIDTH, (int)m_HMIDiagram.DIMENSION.HEIGHT);
			m_HMIDiagramControl.SizeChanged += m_PlantDisplayControl_SizeChanged;
			Controls.Add(m_HMIDiagramControl);
			ZoomToVisible();
			ResumeLayout(false);
			PerformLayout();
			HScroll = true;
			VScroll = true;
		}

		~HMIDiagramDockContent()
		{
			m_HMIDiagram = null;
			m_HMIDiagramControl = null;
		}

		void m_PlantDisplayControl_SizeChanged(object sender, EventArgs e)
		{
			ZoomToVisible();
		}

		private void ZoomToVisible()
		{
			HMIDiagramElementHost l_PlantDisplayElementHost = m_HMIDiagramControl as HMIDiagramElementHost;
			if (l_PlantDisplayElementHost != null)
			{
				double l_dScaleX = 1.0;// (double)m_HMIDiagramControl.Size.Width / (double)DefaultWidth;
				double l_dScaleY = 1.0;//(double)m_HMIDiagramControl.Size.Height / (double)DefaultHeight;
				l_PlantDisplayElementHost.PlantDisplayFrameworkElement.SetScaling(l_dScaleX, l_dScaleY);
			}
		}

		private void PlantDisplayDockContent_Shown(object sender, EventArgs e)
		{
			HMIDiagramElementHost l_pdElementHost = m_HMIDiagramControl as HMIDiagramElementHost;
			if (l_pdElementHost != null)
			{
				l_pdElementHost.PlantDisplayFrameworkElement.FinishedContruction = true;
			}
		}

		public virtual void UpdateGUI()
		{
			IDynamicDataGraphic l_DynamicDataGraphic = m_HMIDiagramControl as IDynamicDataGraphic;
			if (l_DynamicDataGraphic != null)
			{
				l_DynamicDataGraphic.UpdateGUI();
			}
		}

		public virtual void Draw()
		{
			IDynamicDataGraphic l_DynamicDataGraphic = m_HMIDiagramControl as IDynamicDataGraphic;
			if (l_DynamicDataGraphic != null)
			{
				l_DynamicDataGraphic.Draw();
			}
		}
	}
}
