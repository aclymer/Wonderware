using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class wwRectangle : GraphicPrimitive
	{
		public wwRectangle()
		{
		}

		~wwRectangle()
		{
		}

		private Brush l_FillBrush;
		private Pen l_StrokePen;

		// Attributes

		// Properties

		// Sub Elements

		//
		// Helper Functions
		//

		public override void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			m_Geometry = new RectangleGeometry(new Rect(new Point(DIMENSION.LEFT, DIMENSION.TOP), new Size(DIMENSION.WIDTH, DIMENSION.HEIGHT)));
		}

		public override void Render(DrawingContext dc)
		{

			if (PENSTYLE == "none")
				l_StrokePen = null;
			else if (l_StrokePen == null)
			{
				l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);
				l_StrokePen.LineJoin = PenLineJoin.Miter;
				l_StrokePen.Freeze();
			}

			if (FILLSTYLE == "none")
				l_FillBrush = null;
			else if (l_FillBrush == null)
			{
				l_FillBrush = new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(FILLCOLOR));
				l_FillBrush.Freeze();
			}

			dc.DrawGeometry(l_FillBrush, l_StrokePen, m_Geometry);
			base.Render(dc);
		}
	}
}
