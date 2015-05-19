using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwRadialGradientPaint : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public System.Windows.Point center;
        [AttributeIsXMLAttribute]
        public System.Windows.Point focal;
        [AttributeIsXMLAttribute]
        public float radius;
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

        public wwRadialGradientPaint()
        {
        }

        ~wwRadialGradientPaint()
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
