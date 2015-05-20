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
			Brush l_FillBrush = new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(FILLCOLOR));
			Pen l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), (double) PENWIDTH);
			l_StrokePen.LineJoin = PenLineJoin.Miter;
			
			if (PENSTYLE == "none")
				l_StrokePen = null;
			if (FILLSTYLE == "none")
				l_FillBrush = null;

			dc.DrawGeometry(l_FillBrush, l_StrokePen, m_Geometry);
			base.Render(dc);
		}
	}
}
