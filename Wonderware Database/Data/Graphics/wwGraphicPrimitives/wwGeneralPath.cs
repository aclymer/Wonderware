using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Wonderware.Management;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Wonderware.Data
{
    public class wwGeneralPath : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public String path;
        [AttributeIsXMLAttribute]
        public String windingRule;
        [AttributeIsXMLAttribute]
        public bool strokeOn;
        [AttributeIsXMLAttribute]
        public Color strokeColor;
        [AttributeIsXMLAttribute]
        public bool fillOn;
        [AttributeIsXMLAttribute]
        public Color fillColor;
        [AttributeIsXMLAttribute]
        public float justification;
        [AttributeIsXMLAttribute]
        public bool movePoint;
        [AttributeIsXMLAttribute]
        public String stroke;
        [AttributeIsXMLAttribute]
        public String gradient;
        [AttributeIsXMLAttribute]
        public String sgradient;
        [AttributeIsXMLAttribute]
        public float maxwidth;
        [AttributeIsXMLAttribute]
        public String toolTip;
        [AttributeIsXMLAttribute]
        public Color strokePaint;
        [AttributeIsXMLAttribute]
        public Color fillPaint;
        [AttributeIsXMLAttribute]
        public bool absolutePaint;
        [AttributeIsXMLAttribute]
        public String pattern;
        [AttributeIsXMLAttribute]
        public String spattern;
        [AttributeIsXMLAttribute]
        public String ppaint;
        [AttributeIsXMLAttribute]
        public bool contains;
        [AttributeIsXMLAttribute]
        public bool zoomPaint;
        [AttributeIsXMLAttribute]
        public float maximumStrokeWidth = 3.0f;

        public wwGeneralPath()
        {
        }

        public override void SyncData(Database p_Database)
        {
            base.SyncData(p_Database);
            m_Geometry = Grapher.GetGeometryForIlvGeneralPath(path);
        }

        override public void SyncGraphics(Database p_Database)
        {
            base.SyncGraphics(p_Database);
            //if (stroke != null)
            //{
            //    Stroke l_Stroke = this.GetGrapher().GetObjectFromId(stroke) as Stroke;
            //    Children.Add(l_Stroke.GetCopy());
            //}
            //if (gradient != null)
            //{
            //    Gradient l_Gradient = this.GetGrapher().GetObjectFromId(gradient) as Gradient;
            //    Children.Add(l_Gradient.GetCopy());
            //}
            //if (pattern != null)
            //{
            //    Pattern l_Pattern = this.GetGrapher().GetObjectFromId(pattern) as Pattern;
            //    Children.Add(l_Pattern.GetCopy());
            //}
            //if (ppaint != null)
            //{
            //    RadialGradientPaint l_RadialGradientPaint = this.GetGrapher().GetObjectFromId(ppaint) as RadialGradientPaint;
            //    if (l_RadialGradientPaint != null)
            //    {
            //        Children.Add(l_RadialGradientPaint.GetCopy());
            //    }
            //    LinearGradientPaint l_LinearGradientPaint = this.GetGrapher().GetObjectFromId(ppaint) as LinearGradientPaint;
            //    if (l_LinearGradientPaint != null)
            //    {
            //        Children.Add(l_LinearGradientPaint.GetCopy());
            //    }
            //}
            // assuming ppaint cannot be referenced like gradient/pattern/stroke. WRONG !
            fillPaint = fillColor;
            strokePaint = strokeColor;
        }

        private wwRadialGradientPaint GetRadialGradient()
        {
            //foreach (IlvObject l_Child in this.Children)
            //{
            //    RadialGradientPaint l_RadialGradientPaint = l_Child as RadialGradientPaint;
            //    if (l_RadialGradientPaint != null)
            //    {
            //        return l_RadialGradientPaint;
            //    }
            //}
            return null;
        }

        private wwLinearGradientPaint GetLinearGradient()
        {
            //foreach (IlvObject l_Child in this.Children)
            //{
            //    LinearGradientPaint l_LinearGradientPaint = l_Child as LinearGradientPaint;
            //    if (l_LinearGradientPaint != null)
            //    {
            //        return l_LinearGradientPaint;
            //    }
            //}
            return null;
        }

        public override void Render(DrawingContext dc)
        {
            wwStroke l_Stroke = new wwStroke();// GetObjectFromId(stroke) as Stroke;
            wwGradient l_Gradient = new wwGradient(); //GetObjectFromId(gradient) as Gradient;
            wwPattern l_Pattern = new wwPattern(); //GetObjectFromId(pattern) as Pattern;
            wwRadialGradientPaint l_RadialGradientPaint = GetRadialGradient();
            wwLinearGradientPaint l_LinearGradientPaint = GetLinearGradient();
            Brush l_CurrentFillBrush = Brushes.Transparent;
            Pen l_CurrentStrokePen = new Pen(Brushes.Black, 0.0);
            if (windingRule == "evenodd")
            {
                (m_Geometry as PathGeometry).FillRule = FillRule.EvenOdd;
            }
            else
            {
                (m_Geometry as PathGeometry).FillRule = FillRule.Nonzero;
            }
            if (fillOn == true)
            {
                l_CurrentFillBrush = MakeFillBrush(l_Pattern, l_Gradient, l_RadialGradientPaint, l_LinearGradientPaint, RenderBounds);
            }
            if (strokeOn == true)
            {
                l_CurrentStrokePen = MakeStrokePen(l_Stroke, new SolidColorBrush(strokePaint));
            }
            dc.DrawGeometry(l_CurrentFillBrush, l_CurrentStrokePen, m_Geometry);
            base.Render(dc);
        }

        private Pen MakeStrokePen(wwStroke l_Stroke, Brush l_StrokeBrush)
        {
            int l_iWidth = (l_Stroke != null ? (int)l_Stroke.lineWidth : 1);
            Pen l_StrokePen = new Pen(l_StrokeBrush, l_iWidth);
            if (l_Stroke != null)
            {
                l_StrokePen.EndLineCap = PenLineCap.Flat;
                if (l_Stroke.endCap != null)
                {
                    switch (l_Stroke.endCap)
                    {
                        case "Round":
                        case "Butt":
                            l_StrokePen.EndLineCap = PenLineCap.Round;
                            break;
                        default:
                            break;
                    }
                }
                l_StrokePen.LineJoin = PenLineJoin.Miter;
                if (l_Stroke.lineJoin != null)
                {
                    switch (l_Stroke.lineJoin)
                    {
                        case "Round":
                            l_StrokePen.LineJoin = PenLineJoin.Round;
                            break;
                        default:
                            break;
                    }
                }
                l_StrokePen.MiterLimit = l_Stroke.miterLimit;
                l_StrokePen.Thickness = l_Stroke.lineWidth;
            }
            return l_StrokePen;
        }

        private Brush MakeFillBrush(wwPattern l_Pattern, wwGradient l_Gradient, wwRadialGradientPaint l_RadialGradientPaint, wwLinearGradientPaint l_LinearGradientPaint, System.Windows.Rect p_RenderBounds)
        {
            if (gradient != null && gradient != string.Empty && l_Gradient != null)
            {
                return Grapher.GetGradientBrush(l_Gradient, p_RenderBounds);
            }
            if (pattern != null && pattern != string.Empty && l_Pattern != null)
            {
                return Grapher.GetPatternBrush(l_Pattern, p_RenderBounds);
            }
            if (l_RadialGradientPaint != null)
            {
                return Grapher.GetRadialGradientBrush(l_RadialGradientPaint, p_RenderBounds);
            }
            if (l_LinearGradientPaint != null)
            {
                return Grapher.GetLinearGradientBrush(l_LinearGradientPaint, p_RenderBounds);
            }
            return new SolidColorBrush(fillPaint);
        }
    }
}
