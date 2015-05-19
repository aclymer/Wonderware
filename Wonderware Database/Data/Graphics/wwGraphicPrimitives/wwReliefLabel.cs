using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwReliefLabel : wwReliefRectangle
    {
        [AttributeIsXMLAttribute]
        public String label;
        [AttributeIsXMLAttribute]
        public bool zoomable;

        private FormattedText m_Text;
        private Point m_CurrentLocation;

        public wwReliefLabel()
        {
        }

        ~wwReliefLabel()
        {
            m_Text = null;
        }

        public override void SyncGraphics(Database p_Database)
        {
            base.SyncGraphics(p_Database);
            //if (font != null)
            //{
            //    Font l_Font = this.GetGrapher().GetObjectFromId(font) as Font;
            //}
            SyncText();
        }

        private void SyncText()
        {
            wwFont l_Font = null;
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

        public override void ApplyRenderBounds(TransformGroup p_TransformGroup)
        {
            base.ApplyRenderBounds(p_TransformGroup);
            ApplyTextLocation(p_TransformGroup);
        }

        protected void ApplyTextLocation(TransformGroup p_TransformGroup)
        {
            SyncText();
            m_CurrentLocation = m_Geometry.Transform.Transform(new Point(rectangle.X + rectangle.Width / 2.0, rectangle.Y + rectangle.Height / 2.0));
        }

        public override void Render(DrawingContext dc)
        {
            base.Render(dc);
            dc.DrawText(m_Text, new Point(m_CurrentLocation.X - m_Text.Width / 2.0, m_CurrentLocation.Y - m_Text.Height / 2.0));
        }
    }
}
