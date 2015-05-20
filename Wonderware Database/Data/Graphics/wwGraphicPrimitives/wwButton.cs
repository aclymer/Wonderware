using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class wwButton : GraphicPrimitive
	{
		public wwButton()
		{
			l_FillBrush = new List<Brush>();
			l_StrokePen = new List<Pen>();
			l_Highlight = new List<Point>();
		}

		~wwButton()
		{
			m_Text = null;
		}

		// Attributes
		[AttributeIsXMLAttribute]
		public String TEXTSTRING;
		[AttributeIsXMLAttribute]
		public String FONT;
		[AttributeIsXMLAttribute]
		public float FONTSIZE;
		[AttributeIsXMLAttribute]
		public String FONTSTYLE;
		[AttributeIsXMLAttribute]
		public String FONTWEIGHT;
		[AttributeIsXMLAttribute]
		public bool UNDERLINE;

		// Properties

		// Sub Elements

		private FormattedText	m_Text;
		private Point			m_CurrentLocation;
		private List<Brush>		l_FillBrush;
		private List<Pen>		l_StrokePen;
		private List<Point>		l_Highlight;

		public override bool IsSubElement(String p_sName)
		{
			base.IsSubElement(p_sName);

			switch (p_sName)
			{
				case "BEHAVIORS":
				case "EVENTS":
				case "OPENWINDOW":
				case "WINDOWURL":
					return true;
				default:
					return base.IsSubElement(p_sName);
			}
		}

		public override XMLPersistedObject GetSubElementObject(String p_sName)
		{
			base.GetSubElementObject(p_sName);

			switch (p_sName)
			{
				case "BEHAVIORS":
				case "EVENTS":
				case "OPENWINDOW":
				case "WINDOWURL":
				default:
					return base.GetSubElementObject(p_sName);
			}
		}

		//
		// Helper Functions
		//

		private void SyncText()
		{
			wwFont l_Font = new wwFont(FONT, FONTWEIGHT, FONTSIZE, "center");
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
			m_Text.SetForegroundBrush(new SolidColorBrush(Grapher.FromDrawingColorStrToMediaColor("rgb(0, 0, 0)")));
			m_Text.TextAlignment = TextAlignment.Center;
			m_CurrentLocation = new Point(DIMENSION.LEFT + DIMENSION.WIDTH / 2, DIMENSION.TOP + (DIMENSION.HEIGHT - m_Text.Extent) / 2);
		}

		public override void SyncGraphics(Database p_Database)
		{
			m_Geometry = new RectangleGeometry(new Rect(DIMENSION.LEFT, DIMENSION.TOP, DIMENSION.WIDTH, DIMENSION.HEIGHT));
			
			l_Highlight.Clear();
			l_Highlight.Add(new Point(DIMENSION.LEFT, DIMENSION.TOP));
			l_Highlight.Add(new Point(DIMENSION.LEFT, DIMENSION.TOP + DIMENSION.HEIGHT));
			l_Highlight.Add(new Point(DIMENSION.LEFT + DIMENSION.WIDTH, DIMENSION.TOP));
			l_Highlight.Add(new Point(DIMENSION.LEFT + DIMENSION.WIDTH, DIMENSION.TOP + DIMENSION.HEIGHT));
			l_Highlight.Add(new Point(DIMENSION.LEFT + 1, DIMENSION.TOP + 1)); 
			l_Highlight.Add(new Point(DIMENSION.LEFT + DIMENSION.WIDTH - 1, DIMENSION.TOP + 1));
			l_Highlight.Add(new Point(DIMENSION.LEFT + 1, DIMENSION.TOP + DIMENSION.HEIGHT - 1));
			l_Highlight.Add(new Point(DIMENSION.LEFT + DIMENSION.WIDTH - 1, DIMENSION.TOP + DIMENSION.HEIGHT - 1));
			SyncText();
			base.SyncGraphics(p_Database);
		}

		public override void Render(DrawingContext dc)
		{						
			l_FillBrush.Clear();
			l_FillBrush.Add(new SolidColorBrush(System.Windows.Media.Color.FromRgb(  0,  0,  0)));	// Base Layer (black)
			l_FillBrush.Add(new SolidColorBrush(System.Windows.Media.Color.FromRgb(186,186,186)));	// Top Layer  (light grey)

			l_StrokePen.Clear();
			l_StrokePen.Add(new Pen(new SolidColorBrush(System.Windows.Media.Color.FromRgb(  0,  0,  0)), 1.0));	// Base Layer (black)
			l_StrokePen.Add(new Pen(new SolidColorBrush(System.Windows.Media.Color.FromRgb(255,255,255)), 1.0));	// Highlight  (white)	
			l_StrokePen.Add(new Pen(new SolidColorBrush(System.Windows.Media.Color.FromRgb(128,128,128)), 1.0));	// Shadow	  (grey)
			l_StrokePen[0].StartLineCap = PenLineCap.Flat;
			l_StrokePen[0].EndLineCap = PenLineCap.Flat;
			l_StrokePen[0].LineJoin = PenLineJoin.Miter;
			l_StrokePen[1].StartLineCap = PenLineCap.Flat;
			l_StrokePen[1].EndLineCap = PenLineCap.Flat;
			l_StrokePen[1].LineJoin = PenLineJoin.Miter;
			l_StrokePen[2].StartLineCap = PenLineCap.Flat;
			l_StrokePen[2].EndLineCap = PenLineCap.Flat;
			l_StrokePen[2].LineJoin = PenLineJoin.Miter;

			dc.DrawGeometry(l_FillBrush[1], l_StrokePen[1], m_Geometry);
			dc.DrawLine(l_StrokePen[1], l_Highlight[0], l_Highlight[1]);
			dc.DrawLine(l_StrokePen[1], l_Highlight[0], l_Highlight[2]);
			dc.DrawLine(l_StrokePen[2], l_Highlight[3], l_Highlight[1]);
			dc.DrawLine(l_StrokePen[2], l_Highlight[3], l_Highlight[2]);
			dc.DrawLine(l_StrokePen[1], l_Highlight[4], l_Highlight[5]);
			dc.DrawLine(l_StrokePen[1], l_Highlight[4], l_Highlight[6]);
			dc.DrawLine(l_StrokePen[2], l_Highlight[7], l_Highlight[5]);
			dc.DrawLine(l_StrokePen[2], l_Highlight[7], l_Highlight[6]);
			dc.DrawRectangle(null, l_StrokePen[0], m_Geometry.GetRenderBounds(l_StrokePen[1]));// new Rect(DIMENSION.LEFT, DIMENSION.TOP, DIMENSION.WIDTH, DIMENSION.HEIGHT));
			
			dc.DrawText(m_Text, m_CurrentLocation);
			base.Render(dc);
		}
	}
}
