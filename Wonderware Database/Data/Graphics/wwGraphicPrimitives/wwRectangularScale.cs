using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwRectangularScale : GraphicPrimitive
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
        public string format;//ie '0.#'
        [AttributeIsXMLAttribute]
        public int numberOfSteps;
        [AttributeIsXMLAttribute]
        public float originPosition;
        [AttributeIsXMLAttribute]
        public float labelsPosition;
        [AttributeIsXMLAttribute]
        public bool labelsCentered;

        public wwRectangularScale()
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
