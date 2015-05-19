using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Wonderware.Management;

namespace Wonderware.Data
{
    public class wwMarker : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public Point point;
        [AttributeIsXMLAttribute]
        public float size;

        public wwMarker()
        {
        }

        public override void SyncData(Database p_Database)
        {
            base.SyncData(p_Database);
            m_Geometry = new RectangleGeometry(new Rect(point.X - size / 2.0, point.Y - size / 2.0, size / 2.0, size / 2.0));
        }

        public override void Render(DrawingContext dc)
        {
            Brush l_AlmostInvisibleBrush = new SolidColorBrush(Color.FromArgb(1,255,255,255));
            Pen l_AlmostInvisiblePen = new Pen(l_AlmostInvisibleBrush, 1);
            dc.DrawGeometry(l_AlmostInvisibleBrush, l_AlmostInvisiblePen, m_Geometry);
        }
    }
}
