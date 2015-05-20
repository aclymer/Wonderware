using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Wonderware.Management;
using System.Diagnostics;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class GraphicPrimitive : GraphicObject
	{
		public GraphicPrimitive()
		{
			visible = true;
		}

		~GraphicPrimitive()
		{
			m_Geometry = null;
		}

		//
		// Graphic properties
		//

		public Geometry m_Geometry;
		public System.Windows.Rect OriginalBounds;
		public System.Windows.Rect RootBounds;
		public System.Windows.Rect RenderBounds;
		public bool visible;
		public Color background;

		public virtual System.Windows.Rect GetBounds()
		{
			System.Windows.Rect l_CombinedBounds = new System.Windows.Rect(new System.Windows.Point(DIMENSION.LEFT, DIMENSION.TOP), new System.Windows.Size(DIMENSION.WIDTH, DIMENSION.HEIGHT));
			return l_CombinedBounds;
		}

		public virtual System.Windows.Rect GetVisibleBounds()
		{
			System.Windows.Rect l_CombinedBounds = new System.Windows.Rect(new System.Windows.Point(DIMENSION.LEFT, DIMENSION.TOP), new System.Windows.Size(DIMENSION.WIDTH, DIMENSION.HEIGHT));
			return l_CombinedBounds;
		}

		public override void SyncData(Database p_Database)
		{
		}

		public override void SyncGraphics(Database p_Database)
		{
		}

		public virtual void Render(DrawingContext dc)
		{
			TranslateTransform l_Translate = new TranslateTransform((Parent as HMIDiagram).DIMENSION.LEFT, (Parent as HMIDiagram).DIMENSION.TOP);
			dc.PushTransform(l_Translate);
		}

		public virtual void SetBounds(TransformGroup p_TransformGroup)
		{
			OriginalBounds = m_Geometry.GetRenderBounds(new Pen(Brushes.Black, 1.0));
			MatrixTransform l_RootTransform = new MatrixTransform(p_TransformGroup.Value);			
			RootBounds = l_RootTransform.TransformBounds(m_Geometry.GetRenderBounds(new Pen(Brushes.Black, 1.0)));
			RenderBounds = RootBounds;
		}

		public virtual void ApplyRenderBounds(TransformGroup p_TransformGroup)
		{
			if (m_Geometry != null)
				ApplyRenderBounds(p_TransformGroup, m_Geometry);
			else
				Debug.WriteLine("Geometry object is null: " + this.ID);
		}

		private void ApplyRenderBounds(TransformGroup p_TransformGroup, Geometry l_Geometry)
		{
			MatrixTransform l_TranslateTransform1 = null;
			MatrixTransform l_ScaleTransform = null;
			MatrixTransform l_TranslateTransform2 = null;

			int l_iCurrentTransformCount = p_TransformGroup.Children.Count;
			if (RootBounds != RenderBounds)
			{
				l_TranslateTransform2 = new MatrixTransform(1.0, 0.0, 0.0, 1.0, RenderBounds.X, RenderBounds.Y);
				p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_TranslateTransform2);
				l_ScaleTransform = new MatrixTransform(RenderBounds.Width / RootBounds.Width, 0.0, 0.0, RenderBounds.Height / RootBounds.Height, 0.0, 0.0);
				p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_ScaleTransform);
				l_TranslateTransform1 = new MatrixTransform(1.0, 0.0, 0.0, 1.0, -RootBounds.X, -RootBounds.Y);
				p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_TranslateTransform1);
			}
			MatrixTransform l_RenderTransform = new MatrixTransform(p_TransformGroup.Value);
			l_Geometry.Transform = l_RenderTransform;
			if (RootBounds != RenderBounds)
			{
				p_TransformGroup.Children.Remove(l_TranslateTransform1);
				p_TransformGroup.Children.Remove(l_ScaleTransform);
				p_TransformGroup.Children.Remove(l_TranslateTransform2);
			}
		}
	}
}
