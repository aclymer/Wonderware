using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
	public class wwVisibility : wwStyle
	{
		public wwVisibility()
		{
		}

		[AttributeIsXMLAttribute]
		public String VISIBLESTATE;

		public override bool IsSubElement(string p_sName)
		{
			switch (p_sName)
			{
				case "EXPRESSION":
					return true;
				default:
					return base.IsSubElement(p_sName);
			}
		}

		public override XMLPersistedObject GetSubElementObject(string p_sName)
		{
			switch (p_sName)
			{
				case "EXPRESSION":
					return new wwExpression();
				default:
					return base.GetSubElementObject(p_sName);
			}
		}
	}
}
