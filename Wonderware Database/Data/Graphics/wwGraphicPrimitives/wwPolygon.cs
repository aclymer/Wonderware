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
