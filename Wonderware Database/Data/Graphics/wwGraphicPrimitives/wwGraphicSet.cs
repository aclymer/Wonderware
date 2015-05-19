using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class wwGraphicSet : GraphicPrimitive
	{
		public wwGraphicSet()
		{
		}

		~wwGraphicSet()
		{
		}

		public override void SetBounds(TransformGroup p_TransformGroup)
		{
		}
		
		public override XMLPersistedObject GetSubElementObject(String p_sName)
		{
			switch (p_sName)
			{
				case "DIMENSION":
					return new wwDimension();
				case "RECTANGLE":
					return new wwRectangle();
				case "ROUNDRECTANGLE":
					return new wwRoundRectangle();
				case "POLYGON":
					return new wwPolygon();
				case "POLYLINE":
					return new wwPolyline();
				case "LINE":
					return new wwLine();
				case "ELLIPSE":
					return new wwEllipse();
				case "BUTTON":
					return new wwButton();
				default:
					return base.GetSubElementObject(p_sName);
			}
		}

		public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
		{
			wwDimension l_Dimension = p_SubElementObject as wwDimension;

			if (l_Dimension != null)
			{
				DIMENSION = l_Dimension;
			}
			else 
			{
				base.AddSubElementObject(p_SubElementObject);
			}
		}

		public override void ApplyRenderBounds(TransformGroup p_TransformGroup)
		{
		}

		public override void Render(DrawingContext dc)
		{
			base.Render(dc);
		}

	}
}
