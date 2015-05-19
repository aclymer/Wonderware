using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwGradient : wwStyle
    {
        [AttributeIsXMLAttribute]
        public Color color1;
        [AttributeIsXMLAttribute]
        public Color color2;
        [AttributeIsXMLAttribute]
        public System.Windows.Point point1;
        [AttributeIsXMLAttribute]
        public System.Windows.Point point2;
        [AttributeIsXMLAttribute]
        public bool cyclic;
        [AttributeIsXMLAttribute]
        public bool reverse_patch;

        public wwGradient()
        {
        }

        ~wwGradient()
        {
        }
    }
}
