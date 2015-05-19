using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwArc : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public System.Drawing.RectangleF rectangle;
        [AttributeIsXMLAttribute]
        public int flags;
        [AttributeIsXMLAttribute]
        public float startAngle;
        [AttributeIsXMLAttribute]
        public float deltaAngle;

        private PathFigure m_Figure;
        private ArcSegment m_Segment;

        public wwArc()
        {
        }

        ~wwArc()
        {
            m_Figure = null;
            m_Segment = null;
        }

        public override void SyncData(Database p_Database)
        {
            base.SyncData(p_Database);
            m_Figure = new PathFigure();
            m_Segment = new ArcSegment();
        }

        public override void Render(DrawingContext dc)
        {
        }

        public override void SetBounds(TransformGroup p_TransformGroup)
        {
        }

        public override void ApplyRenderBounds(TransformGroup p_TransformGroup)
        {
        }
    }
}
