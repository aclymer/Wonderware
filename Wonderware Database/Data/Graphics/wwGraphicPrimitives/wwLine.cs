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
	public class wwLine : GraphicPrimitive
	{
		public wwLine()
		{
			POINTS = new List<wwPoint>();
		}

		~wwLine()
		{
			POINTS = null;
		}

		private List<wwPoint> POINTS;
		private wwPoint l_Point;
		private Pen l_StrokePen;

		public override void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			m_Geometry = new LineGeometry(new Point(POINTS[0].X, POINTS[0].Y), new Point(POINTS[1].X, POINTS[1].Y));
		}

		public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
		{
			base.AddSubElementObject(p_SubElementObject);
			l_Point = p_SubElementObject as wwPoint;

			if (l_Point != null)
			{
				POINTS.Add(l_Point);
			}
		}

		public override void Render(DrawingContext dc)
		{

			if (PENSTYLE == "none")
				l_StrokePen = null;
			else
			{
				l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);
				l_StrokePen.Freeze();
			}

			dc.DrawGeometry(null, l_StrokePen, m_Geometry);

			base.Render(dc);
		}
	}
}
