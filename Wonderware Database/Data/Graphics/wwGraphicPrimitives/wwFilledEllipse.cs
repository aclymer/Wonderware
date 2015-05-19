using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class wwFilledEllipse : wwEllipse
	{
		public wwFilledEllipse()
		{
		}

		~wwFilledEllipse()
		{
		}
		/*
		public override void Render(DrawingContext dc)
		{
			Brush l_FillBrush = new SolidColorBrush(foreground);
			Pen l_StrokePen = new Pen(new SolidColorBrush(foreground), 1.0);
			dc.DrawGeometry(l_FillBrush, l_StrokePen, m_Geometry);
		}
		*/
	}
}
