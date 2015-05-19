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

		private FormattedText m_Text;
		private Point m_CurrentLocation;

		public wwText()
		{
		}

		~wwText()
		{
			m_Text = null;
		}

		public override void SyncGraphics(Database p_Database)
		{
			base.SyncGraphics(p_Database);
			SyncText();
		}

		private void SyncText()
		{
			wwFont l_Font = new wwFont(FONT, FONTWEIGHT, FONTSIZE, TEXTJUSTIFY);
			String l_sText = String.Empty;
			l_sText = TEXTSTRING;
			if (l_sText == null || l_sText == String.Empty)
			{
				l_sText = " ";
			}
			if (m_Text == null || m_Text.Text != l_sText)
			{
				m_Text = l_Font.GetFormattedText(l_sText);
				/*
				if (l_Font != null)
				{
					m_Text = l_Font.GetFormattedText(l_sText);
				}
				else
				{
					m_Text = wwFont.GetDefaultFormattedText(l_sText);
				}
				*/
			}
			m_Text.SetForegroundBrush(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor(TEXTCOLOR)));
			m_Text.TextAlignment = l_Font.SetTextAlignment();
		}

		public override void SetBounds(TransformGroup p_TransformGroup)
		{
			SyncText();
			OriginalBounds = new Rect(DIMENSION.LEFT, DIMENSION.TOP, DIMENSION.WIDTH, DIMENSION.HEIGHT);
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
			Point l_Location;
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

		public override void Render(DrawingContext dc)
		{
			RotateTransform l_Rotate = new RotateTransform(ROTATION * 90);
			dc.PushTransform(l_Rotate);
			dc.DrawText(m_Text, m_CurrentLocation);
			base.Render(dc);
		}
	}
}
