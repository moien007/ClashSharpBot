/*
 * Clash Sharp Bot
 * 
 * Author : Moien007
 * Desc : AutoIt3 Wrapper (only required function for our bot)
 */

using System;
using System.Runtime.InteropServices;

namespace ClashSharpBot.Base
{
    class AutoIt3Wrapper
    {
        private const string AutoItX3 = "AutoItX3.dll";
        private const bool SetLastError = true;

        [DllImport(AutoItX3, EntryPoint = "AU3_MouseUp", SetLastError = SetLastError)]
        public static extern int MouseUp([MarshalAs(UnmanagedType.LPStr)] string Button = "LEFT");

        [DllImport(AutoItX3, EntryPoint = "AU3_MouseDown", SetLastError = SetLastError)]
        public static extern int MouseDown([MarshalAs(UnmanagedType.LPStr)] string Button = "LEFT");

        [DllImport(AutoItX3, EntryPoint = "AU3_MouseClick", SetLastError = SetLastError)]
        public static extern int MouseClick([MarshalAs(UnmanagedType.LPStr)] string Button = "LEFT", int nX = -2147483647, int nY = -2147483647, int nClicks = 1, int nSpeed = -1);

        [DllImport(AutoItX3, EntryPoint = "AU3_MouseClickDrag", SetLastError = SetLastError)]
        public static extern int MouseClickDrag([MarshalAs(UnmanagedType.LPStr)] string Button, int nX1, int nY1, int nX2, int nY2, int nSpeed = -1);

        [DllImport(AutoItX3, EntryPoint = "AU3_ControlClick", SetLastError = SetLastError)]
        public static extern int ControlClick([MarshalAs(UnmanagedType.LPStr)]string strTitle, [MarshalAs(UnmanagedType.LPStr)]string strText, [MarshalAs(UnmanagedType.LPStr)]string strControl, [MarshalAs(UnmanagedType.LPStr)] string strButton = "LEFT", int nNumClicks = 1, int nX = -2147483647, int nY = -2147483647);

        [DllImport(AutoItX3, EntryPoint = "AU3_PixelGetColor")]
        public static extern int PixelGetColor(int nX, int nY);

        [DllImport(AutoItX3, EntryPoint = "AU3_WinMove", SetLastError = SetLastError)]
        public static extern int WinMove([MarshalAs(UnmanagedType.LPStr)] string strTitle, string strText, int nX, int nY, int nWidth = -1, int nHeight = -1);

        [DllImport(AutoItX3, EntryPoint = "AU3_ControlSend", SetLastError = SetLastError)]
        public static extern int ControlSend([MarshalAs(UnmanagedType.LPStr)] string strTitle, [MarshalAs(UnmanagedType.LPStr)] string strText, [MarshalAs(UnmanagedType.LPStr)] string strControl, [MarshalAs(UnmanagedType.LPStr)] string strSendText, int nMode = 0);
    }
}