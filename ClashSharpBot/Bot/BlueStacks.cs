/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : BlueStacks Automation Tools
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using ClashSharpBot.Base;

// TODO : Log bluestacks

namespace ClashSharpBot.Bot
{
    class BlueStacks
    {
        static ILogger Logger = Log.GetLogger("BlueStacks");

        public static Process Process  = null;
        public static IntPtr ProcessHandle = IntPtr.Zero;
        public static IntPtr ClassHandle = IntPtr.Zero;

        public static bool Init()
        {
            /* 
             * Don't Use Process.GetProcessesByName for Find Bluestacks
             * Because Maybe Exe Name Change's in Different Versions of BlueStacks
             * We Use FindWindow From Windows API 
             */
            

            // Find BlueStacks Window Handle
            ProcessHandle = Win32.FindWindow(null, "BlueStacks App Player");

            if (ProcessHandle != IntPtr.Zero)
            {
                // Find BlueStacks Class Handle
                ClassHandle = Win32.FindWindowEx(ProcessHandle, IntPtr.Zero, "BlueStacksApp", null);

                uint ProcessID;

                // Find BlueStacks Process By Handle
                Win32.GetWindowThreadProcessId(ProcessHandle, out ProcessID);

                Process = Process.GetProcessById(Convert.ToInt32(ProcessID));
                return true;       
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get Bluestacks Window Rectangle
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetRectangle()
        {
            Rectangle rectangle = new Rectangle();

            Win32.RECT rect;

            if(!Win32.GetWindowRect(new HandleRef(ProcessHandle, ClassHandle), out rect))
            {
                rectangle.X = rect.Left;
                rectangle.Y = rect.Top;
                rectangle.Width = rect.Right - rect.Left + 1;
                rectangle.Height = rect.Bottom - rect.Top + 1;
            }
            else
            {
                rectangle = Rectangle.Empty;
            }

            return rectangle;
        }

        /// <summary>
        /// Get Screenshot of Bluestacks
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetBitmap()
        {
            Rectangle rect = GetRectangle();
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);

            using(Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
            }

            return bmp;
        }

        /// <summary>
        /// Get Screenshot of Bluestacks
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetBitmap(Rectangle rect)
        {
            return GetBitmap().Clone(rect, PixelFormat.Format24bppRgb);
        }

        /// <summary>
        /// Mouse Click
        /// </summary>
        public static bool MouseClick(string Button = "LEFT", int nX = -2147483647, int nY = -2147483647, int nClicks = 1, int nSpeed = -1)
        {
            Logger.Debug("Sending mouse click to {0},{1}", nX, nY);
            Point pos = GetRectangle().Location;
            return AutoIt3Wrapper.MouseClick(Button, pos.X + nX, pos.Y + nX, nClicks, nClicks) == 1;
        }

        /// <summary>
        /// Mouse Click
        /// </summary>
        public static bool MouseClick(Point pos, int nClick = 1, int nSpeed = -1, string Button = "LEFT")
        {
            return AutoIt3Wrapper.MouseClick(Button, pos.X, pos.Y, nClick, nSpeed) == 1;
        }

        /// <summary>
        /// Mouse Click
        /// </summary>
        public static bool MouseClick(int X, int Y, int nClick = 1, int nSpeed = -1, string Button = "LEFT")
        {
            return AutoIt3Wrapper.MouseClick(Button, X, Y, nClick, nSpeed) == 1;
        }


        /// <summary>
        /// Mouse Up
        /// </summary>
        /// <param name="Button"></param>
        public static bool MouseUp(string Button = "LEFT")
        {
            return AutoIt3Wrapper.MouseUp(Button) == 1;
        }

        /// <summary>
        /// Mouse Down
        /// </summary>
        public static bool MouseDown(string Button = "LEFT")
        {
            return AutoIt3Wrapper.MouseDown(Button) == 1;
        }

        /// <summary>
        /// Mouse Drag
        /// </summary>
        public static bool MouseClickDrag(string Button, int nX1, int nY1, int nX2, int nY2, int nSpeed = -1)
        {
            Point pos = GetRectangle().Location;
            return AutoIt3Wrapper.MouseClickDrag(Button, pos.X + nX1, pos.Y + nY1, pos.X + nX2, pos.Y + nY2, nSpeed) == 1;
        }

        /// <summary>
        /// Mouse Drag
        /// </summary>
        public static bool MouseClickDrag(Point source, Point destination, int nSpeed = -1)
        {
            return MouseClickDrag("LEFT", source.X, source.Y, destination.X, destination.Y, nSpeed = -1);
        }

        /// <summary>
        /// Get Pixel
        /// </summary>
        public static Color GetPixelColor(int x, int y)
        {
            Point pos = GetRectangle().Location;
            return Color.FromArgb(AutoIt3Wrapper.PixelGetColor(pos.X + x, pos.Y + y));
        }

        /// <summary>
        /// Get Pixel
        /// </summary>
        public static Color GetPixelColor(Point point)
        {
            Point pos = GetRectangle().Location;
            return Color.FromArgb(AutoIt3Wrapper.PixelGetColor(pos.X + point.X, pos.Y + point.Y));
        }

        /// <summary>
        /// Send Text or Key
        /// </summary>
        public static bool Send(string strText, int nMode = 0)
        {
            return AutoIt3Wrapper.ControlSend(Process.MainWindowTitle, "", "", strText, nMode) == 1;
        }

        /// <summary>
        /// Set BlueStacks Window Position
        /// </summary>
        public static bool SetPosition(int x, int y)
        {
            Logger.Info("Set bluestacks position to {0},{1}", x, y);
            return AutoIt3Wrapper.WinMove(Process.MainWindowTitle, "", x, y) == 1;
        }

        /// <summary>
        ///  Template Matching Using Accord.NET on BlueStacks
        /// </summary>
        public static List<Point> TemplateMatch(Bitmap bitmap, float Similarity = 1.00f) // With This Method You Can Find Image Inside BlueStacks
        {

            /*
             * We Use Accord.NET instead AForge.Net because it's new version of aforge
             * This Code's Is From a Sample, But Im Do Some Fix's
             */

            Bitmap BigImage = ClashSharpBot.Base.ImageUtils.ConvertPixelFormat(bitmap, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // create template matching algorithm's instance
            Accord.Imaging.ExhaustiveTemplateMatching tm = new Accord.Imaging.ExhaustiveTemplateMatching(Similarity);
            // find all matchings with specified above similarity

            Accord.Imaging.TemplateMatch[] matchings = tm.ProcessImage(BigImage, GetBitmap());
            // highlight found matchings

            // Load Bitmap Into Memory (Speed UP)
            BitmapData data = BigImage.LockBits(new Rectangle(0, 0, BigImage.Width, BigImage.Height), ImageLockMode.ReadOnly, BigImage.PixelFormat);

            List<Point> Result = new List<Point>();

            foreach (Accord.Imaging.TemplateMatch m in matchings)
            {
                Result.Add(new System.Drawing.Point(m.Rectangle.X, m.Rectangle.Y));
            }

            // Unload Bitmap From Memory
            BigImage.UnlockBits(data);

            return Result;
        }

        /// <summary>
        /// Check Bitmap Exist on BlueStacks Screen
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static bool BitmapExist(Bitmap bitmap, float Similarity = 1.00f)
        {
            return TemplateMatch(bitmap, Similarity).Count <= 1;
        }
    }
}
