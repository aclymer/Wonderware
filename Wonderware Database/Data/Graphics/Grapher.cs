using System;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using Wonderware.Management;

namespace Wonderware.Data
{
	public class Grapher
	{
		public Grapher()
		{
		}

		~Grapher()
		{
		}

		static public Point GetPointFrom(string p_sPointF)
		{
			String[] l_aXY = p_sPointF.Trim().Split(' ');
			Debug.WriteLineIf(l_aXY.Length != 2, "The point format is not what was expected. It should be 'x y'", Database.ErrorTitle);
			if (l_aXY.Length == 2)
			{
				float x = float.Parse(l_aXY[0]);
				float y = float.Parse(l_aXY[1]);
				return new Point(x, y);
			}
			return new Point(0, 0);
		}

		static public Geometry GetGeometryForIlvPoints(List<wwPoint> l_Points, bool bClosedFigure)
		{            
			//Debug.WriteLine("The graphics primitive has " + l_Points.Count + " points.", Database.InfoTitle);
			PathFigure l_pFigure = new PathFigure();
			l_pFigure.IsClosed = bClosedFigure;
			if (l_Points.Count > 0)
			{
				l_pFigure.StartPoint = new Point(l_Points[0].X, l_Points[0].Y);
				if (l_Points.Count > 1)
				{
					Point[] pointArray = new Point[l_Points.Count - 1];
					for (int index = 1; index < l_Points.Count; ++index)
					{
						pointArray[index - 1] = new Point(l_Points[index].X, l_Points[index].Y);
					}
					l_pFigure.Segments.Add((PathSegment)new PolyLineSegment((IEnumerable<Point>)pointArray, true));
				}
			}
			PathFigureCollection l_pFigures = new PathFigureCollection() { l_pFigure };
			PathGeometry l_pGeometry = new PathGeometry(l_pFigures);
			return l_pGeometry;
		}

		static public Geometry GetGeometryForIlvGeneralPath(String p_sPath)
		{
			List<float> l_fValues = new List<float>();
			List<char> l_cValueTypes = new List<char>();
			String l_sSubString = String.Empty;
			String l_sPoint = String.Empty;
			for (int i = 0; i < p_sPath.Length; i++)
			{
				char l_cCurrent = p_sPath[i];
				char l_cNext = (i<=p_sPath.Length-2?p_sPath[i+1]:p_sPath[i]);
				if (l_cCurrent == 'M') // Start Point
				{
					l_cValueTypes.Add('M');
				}
				else if (l_cCurrent == 'z' && l_cNext == 'M') // Close previous and start next
				{
					l_cValueTypes.Add('X');
					i++;
				}
				else if (l_cCurrent == 'C') // Cubic Beizer Curve
				{
					l_cValueTypes.Add('C');
				}
				else if (l_cCurrent == 'z') // Close Curve
				{
					l_cValueTypes.Add('z');
				}
				else if (l_cCurrent == 'L') // Line Segment
				{
					l_cValueTypes.Add('L');
				}
				else if (l_cCurrent == 'Q') // Line Segment
				{
					l_cValueTypes.Add('Q');
				}
				else if (l_cCurrent == ' ') // Next Point
				{
				}
				else
				{
					l_sPoint += l_cCurrent;
					if (i < p_sPath.Length - 1)
					{
						continue;
					}
				}
				if (l_sPoint != String.Empty)
				{
					float l_fValue = System.Convert.ToSingle(l_sPoint);
					l_fValues.Add(l_fValue);
					l_sPoint = String.Empty;
				}
			}
			Debug.WriteLineIf(l_fValues.Count % 2 != 0, "The path prop doesn't contain an even number of point values", Database.ErrorTitle);
			Point[] l_Points = new Point[l_fValues.Count / 2];
			System.Drawing.Drawing2D.PathPointType[] l_ePointTypes = new System.Drawing.Drawing2D.PathPointType[l_Points.Length];
			for (int i = 0; i < l_Points.Length; i++)
			{
				l_Points[i] = new Point(l_fValues[i * 2], l_fValues[i * 2 + 1]);
			}
			PathFigureCollection l_pFigures = new PathFigureCollection();
			PathFigure l_pFigure = null;
			if (l_Points.Length > 0)
			{
				int iPointsIndex = 0;
				for (int iChar = 0; iChar < l_cValueTypes.Count; iChar++)
				{
					switch (l_cValueTypes[iChar])
					{
						case 'M':
						{
							if (l_pFigure != null)
							{
								l_pFigures.Add(l_pFigure);
							}
							l_pFigure = new PathFigure();
							l_pFigure.StartPoint = l_Points[iPointsIndex];
							iPointsIndex += 1;
						}
						break;
						case 'X':
						{
							l_pFigure.IsClosed = true;
							if (l_pFigure != null)
							{
								l_pFigures.Add(l_pFigure);
							}
							l_pFigure = new PathFigure();
							l_pFigure.StartPoint = l_Points[iPointsIndex];
							iPointsIndex += 1;
						}
						break;
						case 'L':
						{
							LineSegment l_lSegment = new LineSegment(l_Points[iPointsIndex], true);
							l_pFigure.Segments.Add(l_lSegment);
							iPointsIndex += 1;
						}
						break;
						case 'C':
						{
							List<Point> l_ThreePoints = new List<Point>();
							for (int di = 0; di < 3; di++)
							{
								l_ThreePoints.Add(l_Points[iPointsIndex + di]);
							}
							BezierSegment l_bSegment = new BezierSegment(l_ThreePoints[0], l_ThreePoints[1], l_ThreePoints[2], true);
							l_pFigure.Segments.Add(l_bSegment);
							iPointsIndex +=3;
						}
						break;
						case 'Q':
						{
							List<Point> l_ThreePoints = new List<Point>();
							for (int di = 0; di < 2; di++)
							{
								l_ThreePoints.Add(l_Points[iPointsIndex + di]);
							}
							QuadraticBezierSegment l_bSegment = new QuadraticBezierSegment(l_ThreePoints[0], l_ThreePoints[1], true);
							l_pFigure.Segments.Add(l_bSegment);
							iPointsIndex += 2;
						}
						break;
						case 'z':
						{
							l_pFigure.IsClosed = true;
						}
						break;
						default:
						break;
					}//switch
				}
			}
			if (l_pFigure != null)
			{
				l_pFigures.Add(l_pFigure);
			}
			PathGeometry l_pGeometry = new PathGeometry(l_pFigures);
			return l_pGeometry;
		}

		static public Brush GetGradientBrush(wwGradient p_Gradient, System.Windows.Rect p_RenderBounds)
		{
			Brush l_Brush = null;
			if (p_Gradient != null)
			{
				Color l_Color1 = p_Gradient.color1;
				Color l_Color2 = p_Gradient.color2;
				if (p_Gradient.reverse_patch == true)
				{
					l_Color1 = p_Gradient.color2;
					l_Color2 = p_Gradient.color1;
				}
				Point l_PointF1 = new Point(p_Gradient.point1.X / 96.0, p_Gradient.point1.Y / 96.0);
				Point l_PointF2 = new Point(p_Gradient.point2.X / 96.0, p_Gradient.point2.Y / 96.0);
				l_Brush = new LinearGradientBrush(l_Color1, l_Color2, l_PointF1, l_PointF2);
				(l_Brush as LinearGradientBrush).MappingMode = BrushMappingMode.RelativeToBoundingBox;
				if (p_Gradient.cyclic == true)
				{
					(l_Brush as LinearGradientBrush).SpreadMethod = System.Windows.Media.GradientSpreadMethod.Reflect;
				}
			}
			return l_Brush;
		}

		static public Brush GetPatternBrush(wwPattern p_Pattern, System.Windows.Rect p_RenderBounds)
		{
			Brush l_Brush = null;
			if (p_Pattern != null)
			{
				Color l_ColorForeground = p_Pattern.fg;
				Color l_ColorBackground = p_Pattern.bg;
				
				l_Brush = new ImageBrush(p_Pattern.BitmapSource);
				(l_Brush as ImageBrush).TileMode = TileMode.Tile;
				(l_Brush as ImageBrush).Viewport = new Rect(0.0, 0.0, p_Pattern.BitmapSource.PixelWidth, p_Pattern.BitmapSource.PixelHeight);
				(l_Brush as ImageBrush).ViewportUnits = BrushMappingMode.Absolute;
				(l_Brush as ImageBrush).Viewbox = new Rect(0.0, 0.0, p_Pattern.BitmapSource.PixelWidth, p_Pattern.BitmapSource.PixelHeight);
				(l_Brush as ImageBrush).ViewboxUnits = BrushMappingMode.Absolute;
			}
			return l_Brush;
		}

		static public Brush GetRadialGradientBrush(wwRadialGradientPaint p_RadialGradientPaint, System.Windows.Rect p_RenderBounds)
		{
			Brush l_Brush = null;
			if (p_RadialGradientPaint != null && 
				p_RadialGradientPaint.colors != null &&
				p_RadialGradientPaint.stops != null)
			{
				Color l_Color1 = p_RadialGradientPaint.colors[0];
				Color l_Color2 = p_RadialGradientPaint.colors[1];
				Point l_PointCenter = new Point(p_RadialGradientPaint.center.X, p_RadialGradientPaint.center.Y);
				Point l_PointFocal = new Point(p_RadialGradientPaint.focal.X, p_RadialGradientPaint.focal.Y);
				double l_dRadius = System.Convert.ToDouble(p_RadialGradientPaint.radius);
				l_Brush = new RadialGradientBrush();
				(l_Brush as RadialGradientBrush).MappingMode = BrushMappingMode.RelativeToBoundingBox;
				(l_Brush as RadialGradientBrush).Center = l_PointCenter;
				(l_Brush as RadialGradientBrush).GradientOrigin = l_PointFocal;
				(l_Brush as RadialGradientBrush).RadiusX = l_dRadius;
				(l_Brush as RadialGradientBrush).RadiusY = l_dRadius;
				switch (p_RadialGradientPaint.spread)
				{
					case 1:
						(l_Brush as RadialGradientBrush).SpreadMethod= GradientSpreadMethod.Pad;
						break;
					case 2:
						(l_Brush as RadialGradientBrush).SpreadMethod= GradientSpreadMethod.Reflect;
						break;
					case 3:
						(l_Brush as RadialGradientBrush).SpreadMethod= GradientSpreadMethod.Repeat;
						break;
					default:
						break;
				}
				for (int iter = 0; iter < p_RadialGradientPaint.colors.Count; iter++)
				{
					Color l_cColor =p_RadialGradientPaint.colors[iter];
					double l_dStop =p_RadialGradientPaint.stops[iter];
					(l_Brush as RadialGradientBrush).GradientStops.Add(new GradientStop(l_cColor, l_dStop));
				}
				(l_Brush as RadialGradientBrush).Freeze();
			}
			return l_Brush;
		}

		static public Brush GetLinearGradientBrush(wwLinearGradientPaint p_LinearGradientPaint, System.Windows.Rect p_RenderBounds)
		{
			Brush l_Brush = null;
			if (p_LinearGradientPaint != null &&
				p_LinearGradientPaint.colors != null &&
				p_LinearGradientPaint.stops != null)
			{
				Color l_Color1 = p_LinearGradientPaint.colors[0];
				Color l_Color2 = p_LinearGradientPaint.colors[1];
				Point l_PointStart = new Point(p_RenderBounds.X + p_LinearGradientPaint.start.X * p_RenderBounds.Width, p_RenderBounds.Y + p_LinearGradientPaint.start.Y * p_RenderBounds.Height);
				Point l_PointEnd = new Point(p_RenderBounds.X + p_LinearGradientPaint.end.X * p_RenderBounds.Width, p_RenderBounds.Y + p_LinearGradientPaint.end.Y * p_RenderBounds.Height);
				l_Brush = new LinearGradientBrush();
				(l_Brush as LinearGradientBrush).MappingMode = BrushMappingMode.Absolute;
				(l_Brush as LinearGradientBrush).StartPoint = l_PointStart;
				(l_Brush as LinearGradientBrush).EndPoint = l_PointEnd;
				switch (p_LinearGradientPaint.spread)
				{
					case 1:
						(l_Brush as LinearGradientBrush).SpreadMethod = GradientSpreadMethod.Pad;
						break;
					case 2:
						(l_Brush as LinearGradientBrush).SpreadMethod = GradientSpreadMethod.Reflect;
						break;
					case 3:
						(l_Brush as LinearGradientBrush).SpreadMethod = GradientSpreadMethod.Repeat;
						break;
					default:
						break;
				}
				for (int iter = 0; iter < p_LinearGradientPaint.colors.Count; iter++)
				{
					Color l_cColor = p_LinearGradientPaint.colors[iter];
					double l_dStop = p_LinearGradientPaint.stops[iter];
					(l_Brush as LinearGradientBrush).GradientStops.Add(new GradientStop(l_cColor, l_dStop));
				}
				(l_Brush as LinearGradientBrush).Freeze();
			}
			return l_Brush;
		}

		public static Color FromDrawingColorStrToMediaColor(string l_sDrawingColor)
		{
			System.Drawing.Color l_Color = FromDrawingColorStrToDrawingColor(l_sDrawingColor);
			return FromDrawingColorToMediaColor(l_Color);
		}

		public static System.Drawing.Color FromDrawingColorStrToDrawingColor(string l_sDrawingColor)
		{
			if (l_sDrawingColor.StartsWith("rgb(") == true &&
				l_sDrawingColor.EndsWith(")") == true)
			{
				String l_sRGBColor = l_sDrawingColor.Substring(4, l_sDrawingColor.Length - 5);
				String[] l_RGB = l_sRGBColor.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
				if (l_RGB.Length == 3)
				{
					int l_iR = 0;
					int l_iG = 0;
					int l_iB = 0;
					if (Int32.TryParse(l_RGB[0], out l_iR) == true &&
						Int32.TryParse(l_RGB[1], out l_iG) == true &&
						Int32.TryParse(l_RGB[2], out l_iB) == true)
					{
						return System.Drawing.Color.FromArgb(l_iR, l_iG, l_iB);
					}
				}
			}
			return System.Drawing.Color.Magenta;
		}

		public static Color FromDrawingColorToMediaColor(System.Drawing.Color l_Color)
		{
			return Color.FromArgb(l_Color.A, l_Color.R, l_Color.G, l_Color.B);
		}

		public static System.Drawing.Color FromMediaColorToDrawingColor(Color l_Color)
		{
			return System.Drawing.Color.FromArgb(l_Color.A, l_Color.R, l_Color.G, l_Color.B);
		}

	}
}
