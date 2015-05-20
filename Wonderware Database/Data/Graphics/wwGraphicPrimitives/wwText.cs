using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using Wonderware.Management;
using System.Windows.Media;
using System.Globalization;
using System.Windows;
using System.Diagnostics;

namespace Wonderware.Data
{
	public class wwText : GraphicPrimitive
	{
		public wwText()
		{
			PHRASEID = String.Empty;
			TEXTSTRING = String.Empty;
			TEXTCOLOR = String.Empty;
			TEXTJUSTIFY = String.Empty;
			FONT = String.Empty;
			FONTSTYLE = String.Empty;
			FONTWEIGHT = String.Empty;
			FONTSIZE = 0;
			UNDERLINE = false;
			m_Text = null;
			l_sText = String.Empty;
		}

		~wwText()
		{
			PHRASEID = null;
			TEXTSTRING = null;
			TEXTCOLOR = null;
			TEXTJUSTIFY = null;
			FONT = null;
			FONTSTYLE = null;
			FONTWEIGHT = null;
			m_Text = null;
			l_sText = null;
		}

		[AttributeIsXMLAttribute]
		public String PHRASEID;
		[AttributeIsXMLAttribute]
		public String TEXTSTRING;
		[AttributeIsXMLAttribute]
		public String TEXTCOLOR;
		[AttributeIsXMLAttribute]
		public String TEXTJUSTIFY;
		[AttributeIsXMLAttribute]
		public String FONT;
		[AttributeIsXMLAttribute]
		public String FONTSTYLE;
		[AttributeIsXMLAttribute]
		public String FONTWEIGHT;
		[AttributeIsXMLAttribute]
		public float FONTSIZE;
		[AttributeIsXMLAttribute]
		public bool UNDERLINE;

		private wwFont l_Font;
		private String l_sText;
		private FormattedText m_Text;
		private Point l_Location, m_CurrentLocation;
		private MatrixTransform l_RootTransform, l_TranslateTransform1, l_ScaleTransform, l_TranslateTransform2, l_RenderTransform;
		private RotateTransform l_Rotate;

		private void SyncText()
		{
			l_Font = new wwFont(FONT, FONTWEIGHT, FONTSIZE, TEXTJUSTIFY);
			l_sText = String.Empty;
			l_sText = TEXTSTRING;

			if (l_sText == null || l_sText == String.Empty)
			{
				l_sText = " ";
			}

			if (m_Text == null || m_Text.Text != l_sText)
				m_Text = l_Font.GetFormattedText(l_sText);

			m_Text.SetForegroundBrush(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(TEXTCOLOR)));
			m_Text.TextAlignment = l_Font.SetTextAlignment();
		}

		public override void SetBounds(TransformGroup p_TransformGroup)
		{
			SyncText();
			OriginalBounds = new Rect(DIMENSION.LEFT, DIMENSION.TOP, DIMENSION.WIDTH, DIMENSION.HEIGHT);
			l_RootTransform = new MatrixTransform(p_TransformGroup.Value);
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
			switch (this.TEXTJUSTIFY)
			{
				case "center":
					l_Location = new Point((DIMENSION.WIDTH / 2) + DIMENSION.LEFT, DIMENSION.TOP);
					break;
				case "right":
					l_Location = new Point(DIMENSION.WIDTH + DIMENSION.LEFT, DIMENSION.TOP);
					break;
				default:
					l_Location = new Point(DIMENSION.LEFT, DIMENSION.TOP);
					break;
			}

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

			l_RenderTransform = new MatrixTransform(p_TransformGroup.Value);
			m_CurrentLocation = l_RenderTransform.Transform(l_Location);

			if (RootBounds != RenderBounds)
			{
				p_TransformGroup.Children.Remove(l_TranslateTransform1);
				p_TransformGroup.Children.Remove(l_ScaleTransform);
				p_TransformGroup.Children.Remove(l_TranslateTransform2);
			}
		}

		public override void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			SyncText();
		}

		public override void Render(DrawingContext dc)
		{
			dc.DrawText(m_Text, m_CurrentLocation);
			l_Rotate = new RotateTransform(ROTATION * 90);
			dc.PushTransform(l_Rotate);
			base.Render(dc);
		}
	}
}
