using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wonderware.Data
{
	public class wwFont : wwStyle
	{
		[AttributeIsXMLAttribute]
		public string family;
		[AttributeIsXMLAttribute]
		public string style;
		[AttributeIsXMLAttribute]
		public float size;
		[AttributeIsXMLAttribute]
		public string align;

		public wwFont()
		{
			family = string.Empty;
			style = string.Empty;
			size = 0.0f;
			align = string.Empty;
		}

		public wwFont(string sFamily, string sStyle, float fSize, string fAlign)
		{
			family = sFamily.ToLower();
			style = sStyle.ToLower();
			size = fSize;
			align = fAlign.ToLower();
		}

		~wwFont()
		{
			family = null;
			style = null;
			align = null;
		}

		public FormattedText GetFormattedText(String p_sText)
		{
			if (style == "bold")
			{
				return new FormattedText(p_sText, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface(new FontFamily(family), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal), Math.Round(size * 4 / 3), Brushes.Black);
			}
			if (style == "normal")
			{
				return new FormattedText(p_sText, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface(new FontFamily(family), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal), Math.Round(size * 4 / 3), Brushes.Black);
			}
			else
			{
				return new FormattedText(p_sText, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface(new FontFamily(family), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal), Math.Round(size * 4 / 3), Brushes.Black);
			}
		}

		public TextAlignment SetTextAlignment()
		{
			switch (align)
			{
				case "right":
					return TextAlignment.Right;
				case "left":
					return TextAlignment.Left;
				case "center":
				default:
					return TextAlignment.Center;
			}
		}

		static public FormattedText GetDefaultFormattedText(String p_sText)
		{
			return new FormattedText(p_sText, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface(new FontFamily("System"), FontStyles.Normal, FontWeights.Light, FontStretches.Normal), 13, Brushes.Black);
		}
	}
}
