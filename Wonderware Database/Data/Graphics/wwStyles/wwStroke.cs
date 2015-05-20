using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
    public class wwStroke : wwStyle
    {
        [AttributeIsXMLAttribute]
        public float miterLimit;
        [AttributeIsXMLAttribute]
        public String endCap;
        [AttributeIsXMLAttribute]
        public System.Windows.Media.PenLineJoin lineJoin;

        public wwStroke()
        {
            PENWIDTH = 1.0f;
			PENCOLOR = String.Empty;
        }

        ~wwStroke()
        {
        }
    }
}
