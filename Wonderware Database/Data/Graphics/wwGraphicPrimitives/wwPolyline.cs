using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wonderware.Management;
using System.Diagnostics;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class wwPolyline : GraphicPrimitive
	{
		public List<wwPoint> POINTS;

		public wwPolyline()
		{
			POINTS = new List<wwPoint>();
		}

		public override void SyncData(Database p_Database)
		{
			base.SyncData(p_Database);
			m_Geometry = Grapher.GetGeometryForIlvPoints(POINTS, false);
		}

		override public void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			m_Geometry = Grapher.GetGeometryForIlvPoints(POINTS, false);
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
			if (POINTS.Count == 0)
			{
				Debug.WriteLine("The IlvPolygon has no points. It will not be rendered.", "RENDER");
				return;
			}
			Pen l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);
			l_StrokePen.LineJoin = PenLineJoin.Round;
			l_StrokePen.StartLineCap = PenLineCap.Round;
			l_StrokePen.EndLineCap = PenLineCap.Round;
			dc.DrawGeometry(null, l_StrokePen, m_Geometry);
			base.Render(dc);
		}
	}
}
