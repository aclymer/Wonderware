using Wonderware.Data;
using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wonderware.Operator_Station
{
	public partial class HMIDiagramFrameworkElement : BaseFrameworkElement
	{
		public Database m_Database;
		private HMIDiagram m_HMIDiagram;
		//private bool BackgroundDrawn = false;
		GraphicPrimitiveDrawingVisual SelectedGraphicPrimitiveDrawingVisual;
		private double m_dZoom;
		private double m_dScaleX = 1.0;
		private double m_dScaleY = 1.0;
		TransformGroup m_TransformGroup;
		MatrixTransform m_MainTransform;

		public HMIDiagramFrameworkElement(HMIDiagram p_HMIDiagram, Database p_Database)
		{
			m_TransformGroup = new TransformGroup();
			m_MainTransform = new MatrixTransform(1.0, 0.0, 0.0, 1.0, 1.0, 1.0);
			m_Database = p_Database;
			Init(p_HMIDiagram);
			Zoom = 1.0;
			this.MouseWheel += PlantDisplayFrameworkElement_MouseWheel;
		}

		~HMIDiagramFrameworkElement()
		{
		}

		public override void Dispose()
		{
			m_Database = null;
			m_HMIDiagram = null;
			SelectedGraphicPrimitiveDrawingVisual = null;
			this.MouseWheel -= PlantDisplayFrameworkElement_MouseWheel;
			this.RenderTransform = null;
			if (m_TransformGroup != null)
			{
				m_TransformGroup.Children.Clear();
			}
			m_TransformGroup = null;
			m_MainTransform = null;
			base.Dispose();
		}

		public void SetScaling(double p_dScaleX, double p_dScaleY)
		{
			m_dScaleX = p_dScaleX;
			m_dScaleY = p_dScaleY;
			FireZoomChanged();
		}

		public double Zoom
		{
			set
			{
				if (m_dZoom != value)
				{
					if (value > 2.0)
					{
						if (m_dZoom != 2.0)
						{
							m_dZoom = 2.0;
							FireZoomChanged();
						}
					}
					else
					{
						if (value < 0.5)
						{
							if (m_dZoom != 0.5)
							{
								m_dZoom = 0.5;
								FireZoomChanged();
							}
						}
						else
						{
							m_dZoom = value;
							FireZoomChanged();
						}
					}
				}
			}
			get
			{
				return m_dZoom;
			}
		}

		private void FireZoomChanged()
		{
			this.RenderTransform = new MatrixTransform(m_dZoom * m_dScaleX, 0.0, 0.0, m_dZoom * m_dScaleY, 1.0, 1.0);
		}

		void PlantDisplayFrameworkElement_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				double l_dZoomDelta = 0.0;
				if (e.Delta < 0)
				{
					l_dZoomDelta = -0.05;
				}
				else
				{
					l_dZoomDelta = +0.05;
				}
				Zoom = Zoom + l_dZoomDelta;
			}
		}

		public void Init(HMIDiagram p_HMIDiagram)
		{
			DateTime l_Monitor = DateTime.Now;
			m_HMIDiagram = p_HMIDiagram;
			m_HMIDiagram.SyncGraphics(m_Database);
			for (int i = 0; i < m_HMIDiagram.GraphicObjects.Count; i++)//(GraphicObject l_GraphicObject in m_HMIDiagram.GraphicObjects)
			{
				GraphicObject l_GraphicObject = m_HMIDiagram.GraphicObjects[i];
				HMIDiagram l_HMIDiagram = l_GraphicObject as HMIDiagram;
				if (l_HMIDiagram != null)
				{
					foreach (GraphicObject s_GraphicObject in l_HMIDiagram.GraphicObjects)
					{
						m_HMIDiagram.GraphicObjects.Add(s_GraphicObject);
					}
				}
			}
			foreach (GraphicObject l_GraphicObject in m_HMIDiagram.GraphicObjects)
			{
				GraphicPrimitive l_GraphicPrimitive = l_GraphicObject as GraphicPrimitive;
				if (l_GraphicPrimitive != null)
				{
					try
					{
						GraphicPrimitiveDrawingVisual l_PictogramDrawingVisual = new GraphicPrimitiveDrawingVisual(l_GraphicPrimitive);
						Children.Add(l_PictogramDrawingVisual);
					}
					catch (Exception e)
					{
						Debug.WriteLine("When trying to construct a GraphicPrimitive for a HMIDiagram the following exception was thrown: " + e.Message, "EXCEPTION");
					}
				}
			}
			//SetBounds();
			foreach (GraphicPrimitiveDrawingVisual l_GraphicPrimitiveDrawingVisual in Children)
			{
			}
			Draw();
		}

		protected override void OnRender(DrawingContext dc)
		{
			base.OnRender(dc);
		}

		public override void SetBounds()
		{
			m_TransformGroup.Children.Clear();
			m_TransformGroup.Children.Add(m_MainTransform);
			foreach (BaseDrawingVisual l_BaseDrawingVisual in Children)
			{
				l_BaseDrawingVisual.SetBounds(m_TransformGroup);
			}
			m_TransformGroup.Children.Remove(m_MainTransform);
		}

		public override void Draw()
		{
			m_TransformGroup.Children.Clear();
			m_TransformGroup.Children.Add(m_MainTransform);
			foreach (BaseDrawingVisual l_BaseDrawingVisual in Children)
			{
				l_BaseDrawingVisual.Draw(m_TransformGroup, Layers, false, true, 0, false);
			}
			m_TransformGroup.Children.Remove(m_MainTransform);
		}

		protected override void VisualSelected(BaseDrawingVisual p_ClickedVisual, System.Drawing.Point p_ClickPosition)
		{
			if (SelectedGraphicPrimitiveDrawingVisual != null)
			{
				System.Windows.MessageBox.Show(p_ClickedVisual.GetGraphicPrimitiveDrawingVisual().GraphicPrimitive.ID);
				//SelectedGraphicPrimitiveDrawingVisual.Highlight = false;
			}

			if (Workbench.Instance != null)
			{
				Workbench.Instance.FocusedHMIDiagram = this.m_HMIDiagram;
			}

			if (p_ClickedVisual != null)
			{
				GraphicPrimitiveDrawingVisual l_GraphicPrimitiveDrawingVisual = p_ClickedVisual.GetGraphicPrimitiveDrawingVisual();

				if (l_GraphicPrimitiveDrawingVisual != null &&
					l_GraphicPrimitiveDrawingVisual.GraphicPrimitive != null)// && l_GraphicPrimitiveDrawingVisual.GraphicPrimitive.ID.Contains("button"))
				{
					SelectedGraphicPrimitiveDrawingVisual = l_GraphicPrimitiveDrawingVisual;
					//SelectedGraphicPrimitiveDrawingVisual.Blink(true);// = true;
				}
			}
		}

		protected override void VisualClicked(BaseDrawingVisual p_ClickedVisual, System.Drawing.Point p_ClickPosition)
		{
		}

		protected override void VisualDoubleClicked(BaseDrawingVisual p_ClickedVisual, System.Drawing.Point p_ClickPosition)
		{
			GraphicPrimitiveDrawingVisual l_GraphicPrimitiveDrawingVisual = p_ClickedVisual as GraphicPrimitiveDrawingVisual;
			if (l_GraphicPrimitiveDrawingVisual != null)
			{
			}

			if (l_GraphicPrimitiveDrawingVisual != null)
			{
				if (l_GraphicPrimitiveDrawingVisual != null &&
					l_GraphicPrimitiveDrawingVisual.GraphicPrimitive != null)
				{
				}
				
			}
			Draw();
		}

		public GraphicPrimitiveDrawingVisual GetGraphicPrimitiveDrawingVisual(GraphicPrimitive p_GraphicPrimitive)
		{
			foreach (GraphicPrimitiveDrawingVisual l_GraphicPrimitiveDrawingVisual in Children)
			{
				if (l_GraphicPrimitiveDrawingVisual.GraphicPrimitive == p_GraphicPrimitive)
				{
					return l_GraphicPrimitiveDrawingVisual;
				}
			}
			return null;
		}
	}
}
