using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Wonderware.Data
{
	public class wwEllipse : GraphicPrimitive
	{
		public wwEllipse()
		{
		}

		~wwEllipse()
		{
		}

		public override void SyncData(Database p_Database)
		{
			base.SyncData(p_Database);
			//m_Geometry = new EllipseGeometry(new Rect(new Point(DIMENSION.LEFT, DIMENSION.TOP), new Size(DIMENSION.WIDTH, DIMENSION.HEIGHT)));
		}

		public override void SyncGraphics(Database p_Database)
		{
			m_Geometry = new EllipseGeometry(new Rect(new Point(DIMENSION.LEFT, DIMENSION.TOP), new Size(DIMENSION.WIDTH, DIMENSION.HEIGHT)));
			base.SyncGraphics(p_Database);
		}

		public override void Render(DrawingContext dc)
		{
			Brush l_FillBrush = new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(FILLCOLOR));
			Pen l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);

			if (PENSTYLE == "none")
				l_StrokePen = null;
			if (FILLSTYLE == "none")
				l_FillBrush = null;

			dc.DrawGeometry(l_FillBrush, l_StrokePen, m_Geometry);
			base.Render(dc);
		}
	}

}
