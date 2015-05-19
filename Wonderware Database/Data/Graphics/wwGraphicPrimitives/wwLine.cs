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
		public Point from;
		public Point to;
		public List<wwPoint> POINTS;

		public wwLine()
		{
			POINTS = new List<wwPoint>();
		}

		public override void SyncData(Database p_Database)
		{
			base.SyncData(p_Database);
			//from = new Point(POINTS[0].X, POINTS[0].Y);
			//to = new Point(POINTS[1].X, POINTS[1].Y);
			//m_Geometry = new LineGeometry(from, to);
		}

		public override void SyncGraphics(Database p_Database)
		{
			from = new Point(POINTS[0].X, POINTS[0].Y);
			to = new Point(POINTS[1].X, POINTS[1].Y);
			m_Geometry = new LineGeometry(from, to);
			base.SyncGraphics(p_Database);
		}

		public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
		{
			base.AddSubElementObject(p_SubElementObject);

			wwPoint l_Point = p_SubElementObject as wwPoint;

			if (l_Point != null)
			{
				POINTS.Add(l_Point);
			}
		}

		public override void Render(DrawingContext dc)
		{
			Pen l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);
			dc.DrawGeometry(null, l_StrokePen, m_Geometry);
			base.Render(dc);
		}
	}
}
