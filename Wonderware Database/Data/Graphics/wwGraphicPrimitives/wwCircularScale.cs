using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwCircularScale : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public System.Drawing.RectangleF rectangle;
        [AttributeIsXMLAttribute]
        public float stepSize;
        [AttributeIsXMLAttribute]
        public float subStepSize;
        [AttributeIsXMLAttribute]
        public int numberOfSubSteps;
        [AttributeIsXMLAttribute]
        public float min;
        [AttributeIsXMLAttribute]
        public float max;
        [AttributeIsXMLAttribute]
        public float format;
        [AttributeIsXMLAttribute]
        public int numberOfSteps;
        [AttributeIsXMLAttribute]
        public bool inside;
        [AttributeIsXMLAttribute]
        public float start;
        [AttributeIsXMLAttribute]
        public float range;

        public wwCircularScale()
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
