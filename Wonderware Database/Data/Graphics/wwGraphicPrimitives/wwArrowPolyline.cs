using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwArrowPolyline : wwPolyline
    {
        [AttributeIsXMLAttribute]
        public bool usingAllLines;
        [AttributeIsXMLAttribute]
        public float arrowPosition;

        public wwArrowPolyline()
        {
        }

        ~wwArrowPolyline()
        {
        }
    }
}
