using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
	public class wwSize : XMLPersistedObject
	{
		public wwSize()
		{
		}

		// Attributes
		[AttributeIsXMLAttribute()]
		public float WIDTH;
		[AttributeIsXMLAttribute()]
		public float HEIGHT;

		// Properties

		// Sub Elements
	}
}
