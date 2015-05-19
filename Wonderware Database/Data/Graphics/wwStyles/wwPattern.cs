using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class wwPattern : wwStyle
    {
        [AttributeIsXMLAttribute]
        public Color fg;
        [AttributeIsXMLAttribute]
        public Color bg;
        [AttributeIsXMLAttribute]
        public int type; // << LEAVE THIS HERE

        DirectoryInfo PatternsDirectoryInfo;

        public wwPattern()
        {
            bg = Color.FromArgb(0, 255, 255, 255);
            PatternsDirectoryInfo = new DirectoryInfo(Database.RootDataDirectory + "\\Patterns");
        }

        ~wwPattern()
        {
            PatternsDirectoryInfo = null;
        }

        public override void SyncGraphics(Database p_Database)
        {
            base.SyncGraphics(p_Database);
            if (BitmapSource == null)
            {
                Debug.Assert(true);
            }
        }

        public System.Windows.Media.Imaging.BitmapSource BitmapSource
        {
            get
            {
                if (m_BitmapSource == null)
                {
                    System.Drawing.Bitmap l_OriginalBitmap = null;
                    switch (type)
                    {
                        case 66:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\66_SMALL_CHESSBOARD.png");
                            break;
                        case 44:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\44_UP_BLACK_DIAGONAL.png");
                            break;
                        case 27:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\27_DARK_HORIZONTAL.png");
                            break;
                        case 12:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\12_DOWN_LIGHT_DIAGONAL.png");
                            break;
                        case 50:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\50_BRICKS_HORIZONTAL.png");
                            break;
                        case 34:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\34_DOWN_DIAGONAL.png");
                            break;
                        case 8:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\8_GRAY_70.png");
                            break;
                        case 6:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\6_GRAY_50.png");
                            break;
                        case 16:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\16_LIGHT_VERTICAL.png");
                            break;
                        case 18:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\18_LIGHT_HORIZONTAL.png");
                            break;
                        case 24:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\24_SMALL_GRID.png");
                            break;
                        case 9:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\9_GRAY_75.png");
                            break;
                        case 49:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\49_WAFFER.png");
                            break;
                        case 40:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\40_DIAGONAL_GRID.png");
                            break;
                        case 17:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\17_NARROW_VERTICAL.png");
                            break;
                        case 25:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\25_LARGE_GRID.png");
                            break;
                        case 31:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\31_NARROW_DARK_VERTICAL.png");
                            break;
                        case 19:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\19_NARROW_HORIZONTAL.png");
                            break;
                        case 43:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\43_DOWN_BLACK_DIAGONAL.png");
                            break;
                        default:
                            l_OriginalBitmap = new System.Drawing.Bitmap(PatternsDirectoryInfo.FullName + @"\43_DOWN_BLACK_DIAGONAL.png");
                            break;
                    }
                    System.Drawing.Bitmap l_NewBitmap = l_OriginalBitmap.Clone(new System.Drawing.Rectangle(0, 0, l_OriginalBitmap.Width, l_OriginalBitmap.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    for (int Xcount = 0; Xcount < l_NewBitmap.Width; Xcount++)
                    {
                        for (int Ycount = 0; Ycount < l_NewBitmap.Height; Ycount++)
                        {
                            System.Drawing.Color l_Pixel = l_NewBitmap.GetPixel(Xcount, Ycount);
                            if (l_Pixel.ToArgb() == System.Drawing.Color.White.ToArgb())
                            {
                                l_NewBitmap.SetPixel(Xcount, Ycount, System.Drawing.Color.FromArgb(bg.A, bg.R, bg.G, bg.B));
                            }
                            else
                            {
                                l_NewBitmap.SetPixel(Xcount, Ycount, System.Drawing.Color.FromArgb(fg.A, fg.R, fg.G, fg.B));
                            }
                        }
                    }
                    var hBitmap = l_NewBitmap.GetHbitmap();
                    m_BitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                }
                return m_BitmapSource;
            }
        }
        private System.Windows.Media.Imaging.BitmapSource m_BitmapSource;
    }

}
