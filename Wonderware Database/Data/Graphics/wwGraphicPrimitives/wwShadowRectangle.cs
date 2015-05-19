using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwShadowRectangle : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public System.Drawing.RectangleF rectangle;
        [AttributeIsXMLAttribute]
        public float radius;
        [AttributeIsXMLAttribute]
        public int flags;
        [AttributeIsXMLAttribute]
        public float thickness;
        [AttributeIsXMLAttribute]
        public float shadowPosition;

        public wwShadowRectangle()
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
