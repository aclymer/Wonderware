using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwIcon : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public System.Drawing.RectangleF rectangle;
        [AttributeIsXMLAttribute]
        public String location;
        [AttributeIsXMLAttribute]
        public bool keepAspectRatioIfNoAutoResize;
        [AttributeIsXMLAttribute]
        public bool autoResize;
        [AttributeIsXMLAttribute]
        public bool resetIconSizeBeforeAspectRatioCheck;

        public wwIcon()
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
