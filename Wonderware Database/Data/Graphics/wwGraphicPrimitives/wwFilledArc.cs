using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwFilledArc : GraphicPrimitive
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

        public wwFilledArc()
        {
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
