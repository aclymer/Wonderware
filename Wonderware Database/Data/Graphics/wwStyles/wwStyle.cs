using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
    public class wwStyle : GraphicPrimitive
    {
        public wwStyle()
        {
        }

        ~wwStyle()
        {
        }

		public override bool IsSubElement(string p_sName)
		{
			return false;
		}
    }
}
