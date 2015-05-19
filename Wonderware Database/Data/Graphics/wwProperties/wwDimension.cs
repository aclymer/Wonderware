using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
	public class wwDimension : XMLPersistedObject
	{
		public wwDimension()
		{
		}

		public wwDimension(float x, float y, float w, float h)
		{
			LEFT = x; TOP = y; WIDTH = w; HEIGHT = h;
		}

		~wwDimension()
		{
		}

		// Attributes

		[AttributeIsXMLAttribute]
		public float LEFT;
		[AttributeIsXMLAttribute]
		public float TOP;
		[AttributeIsXMLAttribute]
		public float WIDTH;
		[AttributeIsXMLAttribute]
		public float HEIGHT;

		// Methods

		public System.Windows.Rect ToRect()
		{
			return new System.Windows.Rect(LEFT, TOP, WIDTH, HEIGHT);
		}

		public System.Windows.Media.RectangleGeometry ToRectangleGeometry()
		{
			return new System.Windows.Media.RectangleGeometry(this.ToRect());
		}
	}
}
