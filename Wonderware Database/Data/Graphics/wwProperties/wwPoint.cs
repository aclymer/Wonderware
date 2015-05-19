using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
	public class wwPoint : XMLPersistedObject
	{
		public wwPoint()
		{
		}

		public wwPoint(float x, float y)
		{
			X = x;
			Y = y;
		}

		~wwPoint()
		{
		}

		// Attributes

		[AttributeIsXMLAttribute()]
		public float X;
		[AttributeIsXMLAttribute()]
		public float Y;

		// Properties

		// Sub Elements
	}
}
