using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.Data
{
    public class wwStrokeStyle : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public float lineWidth;
        [AttributeIsXMLAttribute]
        public String endCap;
        [AttributeIsXMLAttribute]
        public String miterLimit;

        public wwStrokeStyle()
        {
        }

        ~wwStrokeStyle()
        {
        }
    }
}
