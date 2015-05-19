using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using Wonderware.Management;
using System.Windows.Media;
using System.Globalization;
using System.Windows;

namespace Wonderware.Data
{
    public class wwLabel : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public Point center;
        [AttributeIsXMLAttribute]
        public String label;
        [AttributeIsXMLAttribute]
        public bool antialiasing;

        private FormattedText m_Text;
        private Point m_CurrentLocation;

        public wwLabel()
        {
        }

        ~wwLabel()
        {
            m_Text = null;
        }

        public override void SyncGraphics(Database p_Database)
        {
            base.SyncGraphics(p_Database);
            //if (font != null)
            //{
            //    Font l_Font = this.GetGrapher().GetObjectFromId(font) as Font;
            //    Children.Add(l_Font.GetCopy());
            //}
            SyncText();
        }

        public override void SetBounds(TransformGroup p_TransformGroup)
        {
            SyncText();
            OriginalBounds = new Rect(center.X - m_Text.Width / 2.0, center.Y - m_Text.Height / 2.0, m_Text.Width, m_Text.Height);
            MatrixTransform l_RootTransform = new MatrixTransform(p_TransformGroup.Value);
            RootBounds = l_RootTransform.TransformBounds(OriginalBounds);
            RenderBounds = RootBounds;
        }

        public override void ApplyRenderBounds(TransformGroup p_TransformGroup)
        {
            ApplyTextLocation(p_TransformGroup);
        }

        protected void ApplyTextLocation(TransformGroup p_TransformGroup)
        {
            SyncText();
            Point l_Location = new Point(center.X - m_Text.Width / 2.0, center.Y - m_Text.Height / 2.0);
            MatrixTransform l_TranslateTransform1 = null;
            MatrixTransform l_ScaleTransform = null;
            MatrixTransform l_TranslateTransform2 = null;
            if (RootBounds != RenderBounds)
            {
                int l_iCurrentTransformCount = p_TransformGroup.Children.Count;
                l_TranslateTransform2 = new MatrixTransform(1.0, 0.0, 0.0, 1.0, RenderBounds.X, RenderBounds.Y);
                p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_TranslateTransform2);
                l_ScaleTransform = new MatrixTransform(RenderBounds.Width / RootBounds.Width, 0.0, 0.0, RenderBounds.Height / RootBounds.Height, 0.0, 0.0);
                p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_ScaleTransform);
                l_TranslateTransform1 = new MatrixTransform(1.0, 0.0, 0.0, 1.0, -RootBounds.X, -RootBounds.Y);
                p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_TranslateTransform1);
            }
            MatrixTransform l_RenderTransform = new MatrixTransform(p_TransformGroup.Value);
            m_CurrentLocation = l_RenderTransform.Transform(l_Location);
            if (RootBounds != RenderBounds)
            {
                p_TransformGroup.Children.Remove(l_TranslateTransform1);
                p_TransformGroup.Children.Remove(l_ScaleTransform);
                p_TransformGroup.Children.Remove(l_TranslateTransform2);
            }
        }

        private void SyncText()
        {
            wwFont l_Font = null;
            //foreach (IlvObject l_ChildObject in this.Children)
            //{
            //    l_Font = l_ChildObject as Font;
            //    if (l_Font != null)
            //    {
            //        break;
            //    }
            //}
            String l_sText = label;
            if (l_sText == null || l_sText == String.Empty)
            {
                l_sText = " ";
            }
            if (m_Text == null || m_Text.Text != l_sText)
            {
                if (l_Font != null)
                {
                    m_Text = l_Font.GetFormattedText(l_sText);
                }
                else
                {
                    m_Text = wwFont.GetDefaultFormattedText(l_sText);
                }
            }
        }

        public override void Render(DrawingContext dc)
        {
            dc.DrawText(m_Text, m_CurrentLocation);
        }

    }
}
