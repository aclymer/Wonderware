using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwTransformedGraphic : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public bool owner;
        [AttributeIsXMLAttribute]
        public String transformer;

        public wwTransformedGraphic()
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
