using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class GraphicsEngine
    {
        public static Color PixelEmptyWhite = Color.FromArgb(255, 192, 220, 192);
        public static Color PixelEmptyBlack = Color.FromArgb(255, 192, 128, 128);
        //public static Color PixelEmptyLastMove = 
        public static Color PixelWhite = Color.FromArgb(255, 255, 255, 255);
        public static Color PixelBlack = Color.FromArgb(255, 0, 0, 0);

        public const int size = 64;


        public static Bitmap CaptureScreen()
        {
            using (Bitmap bmpScreenCapture = new Bitmap(512, 512))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(256, 175, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);

                    //// Create pen.
                    //Pen blackPen = new Pen(Color.Black, 3);

                    //// Create points that define line.
                    //Point point1 = new Point(100, 100);
                    //Point point2 = new Point(500, 100);

                    //// Draw line to screen.
                    //g.DrawLine(blackPen, point1, point2);

                    bmpScreenCapture.Save("experiment1.png", ImageFormat.Png);
                }

                
                return (Bitmap)bmpScreenCapture.Clone();
            }
        }

        public static bool ScanBoard(Bitmap bmp, ref int[] board)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int v = 0; v < 8; ++v)
                {
                    for (int h = 0; h < 8; ++h)
                    {
                        var pix1 = bmp.GetPixel(h * size + 25, v * size + 33);
                        var pix2 = bmp.GetPixel(h * size + 38, v * size + 33);

                        board[v * 8 + h] = -1;
                        if (pix1 == PixelWhite && pix2 == PixelWhite) board[v * 8 + h] = 1;
                        if (pix1 == PixelBlack && pix2 == PixelBlack) board[v * 8 + h] = 2;

                    }
                }
            }

            return CheckBoard(board);
        }

        static bool CheckBoard(int[] board)
        {
            bool res = true;

            int countWhite = 0;
            int countBlack = 0;

            for (int i = 0; i < board.Length; ++i)
            {
                if (board[i] == 1) ++countWhite;
                if (board[i] == 2) ++countBlack;
            }

            if (countWhite > 16 || countBlack > 16) return false;

            return res;
        }
    }
}