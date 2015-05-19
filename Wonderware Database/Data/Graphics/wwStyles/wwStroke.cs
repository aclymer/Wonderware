using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
    public class wwStroke : wwStyle
    {
        public float miterLimit;

        [AttributeIsXMLAttribute]
		public float PENWIDTH;
		[AttributeIsXMLAttribute]
		public String PENSTYLE;
		[AttributeIsXMLAttribute]
		public String PENCOLOR;
        [AttributeIsXMLAttribute]
        public String endCap;
        [AttributeIsXMLAttribute]
        public String lineJoin;

        public wwStroke()
        {
            lineWidth = 1.0f;
        }

        ~wwStroke()
        {
        }
    }
}
