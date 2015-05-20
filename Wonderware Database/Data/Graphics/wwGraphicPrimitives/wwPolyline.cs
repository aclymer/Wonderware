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
		public wwPolyline()
		{
			POINTS = new List<wwPoint>();
		}

		~wwPolyline()
		{
			POINTS = null;
		}

		private List<wwPoint> POINTS;
		private wwPoint l_Point;
		private Pen l_StrokePen;

		override public void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			m_Geometry = Grapher.GetGeometryForIlvPoints(POINTS, false);
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
			if (POINTS.Count == 0)
			{
				Debug.WriteLine("The IlvPolygon has no points. It will not be rendered.", "RENDER");
				return;
			}

			if (PENSTYLE == "none")
				l_StrokePen = null;
			else
			{
				l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);
				l_StrokePen.LineJoin = PenLineJoin.Round;
				l_StrokePen.StartLineCap = PenLineCap.Round;
				l_StrokePen.EndLineCap = PenLineCap.Round;
				l_StrokePen.Freeze();
			}

			if (m_Geometry != null)
				dc.DrawGeometry(null, l_StrokePen, m_Geometry);

			base.Render(dc);
		}
	}
}
