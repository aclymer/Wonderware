using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Wonderware.Management;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Wonderware.Data
{
    public class wwReliefRectangle : GraphicPrimitive
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
        public int corners;
        [AttributeIsXMLAttribute]
        public float thickness;
        [AttributeIsXMLAttribute]
        public string toolTip;

        public wwReliefRectangle()
        {
        }

        ~wwReliefRectangle()
        {
        }

        public override void SyncData(Database p_Database)
        {
            base.SyncData(p_Database);
            Rect l_Rect = new Rect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            m_Geometry = new RectangleGeometry(l_Rect);
        }

        override public void SyncGraphics(Database p_Database)
        {
            base.SyncGraphics(p_Database);
        }

        public override void Render(DrawingContext dc)
        {
            Brush l_BackgroundBrush = new SolidColorBrush(background);
            System.Drawing.Color backgroundColorD = Grapher.FromMediaColorToDrawingColor(background);
            System.Drawing.Color lightBackgroundColorD = System.Windows.Forms.ControlPaint.Light(backgroundColorD);
            Color lightBackground = Grapher.FromDrawingColorToMediaColor(lightBackgroundColorD);
            Pen l_LightBackgroundPen = new Pen(new SolidColorBrush(lightBackground), thickness);
            System.Drawing.Color darkBackgroundColorD = System.Windows.Forms.ControlPaint.Dark(backgroundColorD);
            Color darkBackground = Grapher.FromDrawingColorToMediaColor(darkBackgroundColorD);
            Pen l_DarkBackgroundPen = new Pen(new SolidColorBrush(darkBackground), thickness);
            dc.DrawGeometry(l_BackgroundBrush, l_DarkBackgroundPen, m_Geometry);
            dc.DrawLine(l_LightBackgroundPen, m_Geometry.Transform.Transform((m_Geometry as RectangleGeometry).Rect.TopLeft), m_Geometry.Transform.Transform((m_Geometry as RectangleGeometry).Rect.TopRight));
            dc.DrawLine(l_LightBackgroundPen, m_Geometry.Transform.Transform((m_Geometry as RectangleGeometry).Rect.TopLeft), m_Geometry.Transform.Transform((m_Geometry as RectangleGeometry).Rect.BottomLeft));
            base.Render(dc);
        }
    }
}
