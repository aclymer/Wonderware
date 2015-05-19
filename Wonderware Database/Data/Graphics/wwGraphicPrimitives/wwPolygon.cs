using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class wwPolygon : GraphicPrimitive
	{

		public List<wwPoint> POINTS;

		public wwPolygon()
		{
			POINTS = new List<wwPoint>();
		}
		
		// Attributes

		// Properties

		// Sub Elements

		public override void SyncData(Database p_Database)
		{
			base.SyncData(p_Database);
			//m_Geometry = Grapher.GetGeometryForIlvPoints(POINTS, true);
		}

		public override void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			m_Geometry = Grapher.GetGeometryForIlvPoints(POINTS, true);
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
			Brush l_FullBrush = new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(FILLCOLOR));
			Pen l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);
			l_StrokePen.
			dc.DrawGeometry(l_FullBrush, l_StrokePen, m_Geometry);
			base.Render(dc);
		}
	}
}
