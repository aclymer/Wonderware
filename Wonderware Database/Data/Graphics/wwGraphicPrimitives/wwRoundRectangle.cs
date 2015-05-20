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
	public class wwRoundRectangle : wwRectangle
	{
		public wwRoundRectangle()
		{
			CORNERDIMENSION = new wwSize();
			l_CornerRadii = new wwSize();
		}

		~wwRoundRectangle()
		{
			CORNERDIMENSION = null;
			l_CornerRadii = null;
		}

		public wwSize CORNERDIMENSION;
		private Brush l_FillBrush;
		private Pen l_StrokePen;
		private wwSize l_CornerRadii;

		// Attributes

		// Properties

		// Sub Elements

		public override bool IsSubElement(String p_sName)
		{
			switch (p_sName)
			{
				case "CORNERDIMENSION":
				case "DIMENSION":
					return true;
				default:
					return base.IsSubElement(p_sName);
			}
		}

		public override XMLPersistedObject GetSubElementObject(String p_sName)
		{
			switch (p_sName)
			{
				case "CORNERDIMENSION":
					return new wwSize();
				case "DIMENSION":
					return new wwDimension();
				default:
					return base.GetSubElementObject(p_sName);
			}
		}

		public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
		{			
			base.AddSubElementObject(p_SubElementObject);
			l_CornerRadii = p_SubElementObject as wwSize;

			if (l_CornerRadii != null)
			{
				CORNERDIMENSION = l_CornerRadii;
			}
		}

		//
		// Helper Functions
		//

		public override void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			m_Geometry = new RectangleGeometry(new Rect(new Point(DIMENSION.LEFT, DIMENSION.TOP), new Size(DIMENSION.WIDTH, DIMENSION.HEIGHT)), CORNERDIMENSION.WIDTH / 2, CORNERDIMENSION.HEIGHT / 2);
		}

		public override void Render(DrawingContext dc)
		{
			if (PENSTYLE == "none")
				l_StrokePen = null;
			else if (l_StrokePen == null)
			{
				l_StrokePen = new Pen(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(PENCOLOR)), PENWIDTH);
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
