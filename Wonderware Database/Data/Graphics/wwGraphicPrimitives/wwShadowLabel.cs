using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwShadowLabel : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public System.Drawing.RectangleF rectangle;
        [AttributeIsXMLAttribute]
        public int flags;
        [AttributeIsXMLAttribute]
        public float thickness;
        [AttributeIsXMLAttribute]
        public float shadowPosition;
        [AttributeIsXMLAttribute]
        public String label;
        [AttributeIsXMLAttribute]
        public bool antialiasing;
        [AttributeIsXMLAttribute]
        public float radius;

        public wwShadowLabel()
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
