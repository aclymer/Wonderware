using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwSpline : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public string points;
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public float smoothness;
        [AttributeIsXMLAttribute]
        public int flags;
        [AttributeIsXMLAttribute]
        public float lineWidth;

        public wwSpline()
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
