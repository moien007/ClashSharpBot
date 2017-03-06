/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : BlueStacks Automation 
 */

using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ClashSharpBot.Base;


namespace ClashSharpBot.Bot
{
    class BlueStacks
    {
        static ILogger Logger = Log.GetLogger("BlueStacks");

        public static Process Process  = null;
        public static IntPtr WindowHandle = IntPtr.Zero;
        public static IntPtr ClassHandle = IntPtr.Zero;

        public static bool IsRunning
        {
            get
            {
                if (Process == null) return false;

                Process.Refresh();
                return !Process.HasExited;
            }
        }

        public static bool Init()
        {
            /* 
             * Don't Use Process.GetProcessesByName for Find Bluestacks
             * Because Maybe Exe Name Change's in Different Versions of BlueStacks
             * We Use FindWindow From Windows API 
             */
            

            // Find BlueStacks Window Handle
            WindowHandle = Win32.FindWindow(null, "BlueStacks App Player");

            // if window does not exist
            if (WindowHandle == IntPtr.Zero)
                return false;
            
                // Find bluestacks window class handle
                ClassHandle = Win32.FindWindowEx(WindowHandle, IntPtr.Zero, "BlueStacksApp", null);

                uint ProcessID;

                // Find bluestacks process by it's handle
                Win32.GetWindowThreadProcessId(WindowHandle, out ProcessID);

                Process = Process.GetProcessById(Convert.ToInt32(ProcessID));
                return true;       
        }

        public static Rectangle GetRectangle()
        {
            Rectangle rectangle = new Rectangle();

            Win32.RECT rect;

            if(!Win32.GetWindowRect(new HandleRef(WindowHandle, ClassHandle), out rect))
            {
                rectangle = Rectangle.Empty;
                return rectangle;
            }

            rectangle.X = rect.Left;
            rectangle.Y = rect.Top;
            rectangle.Width = rect.Right - rect.Left + 1;
            rectangle.Height = rect.Bottom - rect.Top + 1;

            return rectangle;
        }

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

        public static Bitmap GetBitmap(Rectangle rect)
        {
            return GetBitmap().Clone(rect, PixelFormat.Format24bppRgb);
        }

        public static bool MouseClick(string Button = "LEFT", int nX = -2147483647, int nY = -2147483647, int nClicks = 1, int nSpeed = -1)
        {
            Logger.Info("Sending mouse click to [{0},{1}]", nX, nY);
            Point pos = GetRectangle().Location;
            return AutoIt3Wrapper.MouseClick(Button, pos.X + nX, pos.Y + nX, nClicks, nSpeed) == 1;
        }

        public static bool MouseClick(Point pos, int nClick = 1, int nSpeed = -1, string Button = "LEFT")
        {
            return MouseClick(Button, pos.X, pos.Y, nClick, nSpeed);
        }

        public static bool MouseUp(string Button = "LEFT")
        {
            Logger.Info("Mouse up");
            return AutoIt3Wrapper.MouseUp(Button) == 1;
        }

        public static bool MouseDown(string Button = "LEFT")
        {
            Logger.Info("Mouse down");
            return AutoIt3Wrapper.MouseDown(Button) == 1;
        }
        
        public static bool MouseDrag(int nX1, int nY1, int nX2, int nY2, int nSpeed = -1, string Button = "LEFT")
        {
            Logger.Info("Dragging mouse from [{0},{1}] to [{2},{3}]", nX1, nY1, nX2, nY2);
            Point pos = GetRectangle().Location;
            return AutoIt3Wrapper.MouseClickDrag(Button, pos.X + nX1, pos.Y + nY1, pos.X + nX2, pos.Y + nY2, nSpeed) == 1;
        }
        
        public static bool MouseDrag(Point source, Point destination, int nSpeed = -1, string Button = "LEFT")
        {
            return MouseDrag(source.X, source.Y, destination.X, destination.Y, nSpeed, Button);
        }
        
        public static Color GetPixelColor(int x, int y)
        {
            Point pos = GetRectangle().Location;
            return Color.FromArgb(AutoIt3Wrapper.PixelGetColor(pos.X + x, pos.Y + y));
        }
        
        public static Color GetPixelColor(Point point)
        {
            return GetPixelColor(point.X, point.Y);
        }
        
        public static bool Send(string strText, int nMode = 0)
        {
            Logger.Debug("Sending \"{0}\"");
            return AutoIt3Wrapper.ControlSend(Process.MainWindowTitle, "", "", strText, nMode) == 1;
        }
        
        public static bool SetPosition(int x, int y)
        {
            Logger.Info("Settings position to {0},{1}", x, y);
            return AutoIt3Wrapper.WinMove(Process.MainWindowTitle, "", x, y) == 1;
        }
        
        public static List<Point> TemplateMatch(Bitmap bitmap, float Similarity = 0.99f) 
        {
            Bitmap BigImage = ImageUtils.ConvertPixelFormat(bitmap, PixelFormat.Format24bppRgb);

            // Lock image bytes (Speed up)
            BitmapData data = BigImage.LockBits(new Rectangle(0, 0, BigImage.Width, BigImage.Height), ImageLockMode.ReadOnly, BigImage.PixelFormat);

            // create template matching algorithm's instance
            Accord.Imaging.ExhaustiveTemplateMatching tm = new Accord.Imaging.ExhaustiveTemplateMatching(Similarity);

            // find all matchings with specified above similarity
            Accord.Imaging.TemplateMatch[] matchings = tm.ProcessImage(BigImage, GetBitmap());

            List<Point> Result = matchings.ToList().Select(s => s.Rectangle.Location).ToList();

            // Unlock image bytes
            BigImage.UnlockBits(data);

            return Result;
        }

        public static bool BitmapExist(Bitmap bitmap, float Similarity = 1.00f)
        {
            return TemplateMatch(bitmap, Similarity).Count > 0;
        }
    }
}
