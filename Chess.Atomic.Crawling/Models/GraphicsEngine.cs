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
        //public static Color PixelEmptyWhite = Color.FromArgb(255, 192, 220, 192);
        //public static Color PixelEmptyBlack = Color.FromArgb(255, 192, 128, 128);
        public static Color PixelLastMoveWhite = Color.FromArgb(255, 205, 210, 106);
        public static Color PixelLastMoveBlack = Color.FromArgb(255, 170, 162, 58);
        public static Color PixelWhite = Color.FromArgb(255, 255, 255, 255);
        public static Color PixelBlack = Color.FromArgb(255, 0, 0, 0);

        public const int size = 64;


        public static Bitmap CaptureScreen()
        {
            using (Bitmap bmpScreenCapture = new Bitmap(512, 512))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(223, 178, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);
                }

                
                return (Bitmap)bmpScreenCapture.Clone();
            }
        }

        public static bool ScanBoard(Bitmap bmp, ref int[] board, ref Move highlighted, bool whiteTowin)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                bool firstLastMove = true;

                for (int x = 0; x < 8; ++x)
                {
                    for (int y = 0; y < 8; ++y)
                    {
                        int ind = whiteTowin ? (7 - x) * 8 + (7 - y) : (x * 8 + y);

                        var pix1 = bmp.GetPixel(y * size + 25, x * size + 33);
                        var pix2 = bmp.GetPixel(y * size + 38, x * size + 33);

                        var pixLastMove = bmp.GetPixel(y * size + 5, x * size + 5);

                        board[ind] = (int)SquareState.empty;
                        if (pixLastMove == PixelLastMoveBlack || pixLastMove == PixelLastMoveWhite) 
                        {
                            if (firstLastMove)
                            {
                                highlighted.moveFrom.x = y;
                                highlighted.moveFrom.y = x;

                                firstLastMove = false;
                            }
                            else
                            {
                                highlighted.moveTo.x = y;
                                highlighted.moveTo.y = x;
                            }
                        }
                        if (pix1 == PixelWhite && pix2 == PixelWhite) board[ind] = (int)SquareState.white;
                        if (pix1 == PixelBlack && pix2 == PixelBlack) board[ind] = (int)SquareState.black;

                    }
                }
            }

            return true; // CheckBoard(board);
        }

        //static bool CheckBoard(int[] board)
        //{
        //    bool res = true;

        //    int countWhite = 0;
        //    int countBlack = 0;

        //    for (int i = 0; i < board.Length; ++i)
        //    {
        //        if (board[i] == 1) ++countWhite;
        //        if (board[i] == 2) ++countBlack;
        //    }

        //    if (countWhite > 16 || countBlack > 16) return false;

        //    return res;
        //}
    }
}