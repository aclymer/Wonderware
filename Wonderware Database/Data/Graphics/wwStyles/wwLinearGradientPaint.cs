using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwLinearGradientPaint : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Point start;
        [AttributeIsXMLAttribute]
        public Point end;
        [AttributeIsXMLAttribute]
        public int spread;
        [AttributeIsXMLAttribute]
        public bool adapt;
        [AttributeIsXMLAttribute]
        public List<double> stops;
        [AttributeIsXMLAttribute]
        public List<Color> colors;
        [AttributeIsXMLAttribute]
        public float inter;

        public wwLinearGradientPaint()
        {
            Debug.Assert(true);
        }

        ~wwLinearGradientPaint()
        {
            //if (stops != null)
            //{
            //    stops.Clear();
            //}
            //stops = null;
            //if (colors != null)
            //{
            //    colors.Clear();
            //}
            //colors = null;
        }
    }
}
