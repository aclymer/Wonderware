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
    public class wwZoomableLabel : GraphicPrimitive
    {
        [AttributeIsXMLAttribute]
        public Color foreground;
        [AttributeIsXMLAttribute]
        public String label;
        [AttributeIsXMLAttribute]
        public int flags;
        [AttributeIsXMLAttribute]
        public Color strokeColor;
        [AttributeIsXMLAttribute]
        public Color fillColor;
        [AttributeIsXMLAttribute]
        public float justification;
        [AttributeIsXMLAttribute]
        public Color backColor;
        [AttributeIsXMLAttribute]
        public String pattern;
        [AttributeIsXMLAttribute]
        public String spattern;
        [AttributeIsXMLAttribute]
        public float multilineSpacing;
        [AttributeIsXMLAttribute]
        public float leftMargin;
        [AttributeIsXMLAttribute]
        public float rightMargin;
        [AttributeIsXMLAttribute]
        public float bottomMargin;
        [AttributeIsXMLAttribute]
        public float topMargin;
        [AttributeIsXMLAttribute]
        public String stroke;
        [AttributeIsXMLAttribute]
        public List<String> labels;
        [AttributeIsXMLAttribute]
        public Color fillPaint;
        [AttributeIsXMLAttribute]
        public Color backgroundPaint;
        [AttributeIsXMLAttribute]
        public bool keepOriginalCenter;
        [AttributeIsXMLAttribute]
        public bool mustCenterOnPoint;
        [AttributeIsXMLAttribute]
        public bool mustCenterX;

        private FormattedText m_Text;
        public Point OriginalCenter;
        private Point m_CurrentLocation;

        public wwZoomableLabel()
        {
            Type l_Type = typeof(List<String>);
        }

        ~wwZoomableLabel()
        {
            m_Text = null;
            if (labels != null)
            {
                labels.Clear();
            }
        }

        public override void SyncGraphics(Database p_Database)
        {
            base.SyncGraphics(p_Database);
            //if (pattern != null)
            //{
            //    Pattern l_Pattern = this.GetGrapher().GetObjectFromId(pattern) as Pattern;
            //    Children.Add(l_Pattern.GetCopy());
            //}
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
            //Transformer l_IlvTransformer = new Transformer(transform);
            //OriginalBounds = new Rect(l_IlvTransformer.TransX, l_IlvTransformer.TransY - m_Text.Baseline * l_IlvTransformer.ScaleY, m_Text.Width, m_Text.Height);
            //if (keepOriginalCenter == true)
            //{
            //    OriginalCenter = new Point((OriginalBounds.Left + OriginalBounds.Right) / 2.0, (OriginalBounds.Bottom + OriginalBounds.Top) / 2.0);
            //}
            //MatrixTransform l_RootTransform = new MatrixTransform(p_TransformGroup.Value);
            //RootBounds = l_RootTransform.TransformBounds(OriginalBounds);
            //RenderBounds = RootBounds;
        }

        public override void ApplyRenderBounds(TransformGroup p_TransformGroup)
        {
            ApplyTextLocation(p_TransformGroup);
        }

        protected void ApplyTextLocation(TransformGroup p_TransformGroup)
        {
            SyncText();
            //Transformer l_IlvTransformer = new Transformer(transform);
            //Point l_Location = new Point(l_IlvTransformer.TransX, l_IlvTransformer.TransY - m_Text.Baseline * l_IlvTransformer.ScaleY);
            //if (keepOriginalCenter == true)
            //{
            //    l_Location = new Point(OriginalCenter.X - m_Text.Width / 2.0, l_IlvTransformer.TransY - 10);
            //}
            //MatrixTransform l_TranslateTransform1 = null;
            //MatrixTransform l_ScaleTransform = null;
            //MatrixTransform l_TranslateTransform2 = null;
            //if (RootBounds != RenderBounds)
            //{
            //    int l_iCurrentTransformCount = p_TransformGroup.Children.Count;
            //    l_TranslateTransform2 = new MatrixTransform(1.0, 0.0, 0.0, 1.0, RenderBounds.X, RenderBounds.Y);
            //    p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_TranslateTransform2);
            //    l_ScaleTransform = new MatrixTransform(RenderBounds.Width / RootBounds.Width, 0.0, 0.0, RenderBounds.Height / RootBounds.Height, 0.0, 0.0);
            //    p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_ScaleTransform);
            //    l_TranslateTransform1 = new MatrixTransform(1.0, 0.0, 0.0, 1.0, -RootBounds.X, -RootBounds.Y);
            //    p_TransformGroup.Children.Insert(l_iCurrentTransformCount, l_TranslateTransform1);
            //}
            //MatrixTransform l_RenderTransform = new MatrixTransform(p_TransformGroup.Value);
            //m_CurrentLocation = l_RenderTransform.Transform(l_Location);
            //if (RootBounds != RenderBounds)
            //{
            //    p_TransformGroup.Children.Remove(l_TranslateTransform1);
            //    p_TransformGroup.Children.Remove(l_ScaleTransform);
            //    p_TransformGroup.Children.Remove(l_TranslateTransform2);
            //}
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
            if (labels != null)
            {
                l_sText = String.Empty;
                foreach (String l_sLabel in labels)
                {
                    l_sText += l_sLabel + "\r\n";
                }
            }
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
            Transformer l_IlvTransformer = null;// new Transformer(transform);
            if (l_IlvTransformer != null)
            {
                if (mustCenterOnPoint == true)
                {
                    dc.PushTransform(new TranslateTransform(m_CurrentLocation.X - m_Text.Width / 2.0, m_CurrentLocation.Y - m_Text.Height / 2.0));
                }
                else if (mustCenterX == true)
                {
                    dc.PushTransform(new TranslateTransform(m_CurrentLocation.X - m_Text.Width / 2.0, m_CurrentLocation.Y));
                }
                else
                {
                    dc.PushTransform(new TranslateTransform(m_CurrentLocation.X, m_CurrentLocation.Y));
                }
                dc.PushTransform(new ScaleTransform(l_IlvTransformer.ScaleX, l_IlvTransformer.ScaleY));
                dc.DrawText(m_Text, new Point(0.0, 0.0));
                dc.Pop();
                dc.Pop();
            }
            else
            {
                dc.DrawText(m_Text, m_CurrentLocation);
            }
        }
    }
}
