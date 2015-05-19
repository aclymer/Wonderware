using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
	public class wwExpression : XMLPersistedObject
	{
		public wwExpression()
		{
			EXPRSTR = String.Empty;
			BINDEXPR = String.Empty;
			CONNIDSEXPR = String.Empty;
		}

		~wwExpression()
		{
		}

		// Attributes

		[AttributeIsXMLAttribute]
		public String EXPRSTR;
		[AttributeIsXMLAttribute]
		public String BINDEXPR;
		[AttributeIsXMLAttribute]
		public String CONNIDSEXPR;
	}
}
