/*
 * Clash Sharp Bot
 * 
 * Author : Moien007
 * Desc : AutoItX3 Wrapper (Only Required Functions for Bot) For Use Autoit Without Install\Register
 *        
 */

using System;
using System.Runtime.InteropServices;

namespace ClashSharpBot.Base
{
    class AutoIt3Wrapper
    {
        /// <summary>
        /// Mouse Up
        /// </summary>
        /// <param name="Button"></param>
        /// <returns></returns>
        [DllImport("AutoItX3.dll", EntryPoint = "AU3_MouseUp", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MouseUp([MarshalAs(UnmanagedType.LPStr)] string Button = "LEFT");

        /// <summary>
        /// Mouse Down
        /// </summary>
        /// <param name="Button"></param>
        /// <returns></returns>
        [DllImport("AutoItX3.dll", EntryPoint = "AU3_MouseDown", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MouseDown([MarshalAs(UnmanagedType.LPStr)] string Button = "LEFT");


        /// <summary>
        /// Send Mouse Click
        /// </summary>
        [DllImport("AutoItX3.dll", EntryPoint = "AU3_MouseClick", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MouseClick([MarshalAs(UnmanagedType.LPStr)] string Button = "LEFT", int nX = -2147483647, int nY = -2147483647, int nClicks = 1, int nSpeed = -1);

        /// <summary>
        /// Send Mouse Drag
        /// </summary>
        [DllImport("AutoItX3.dll", EntryPoint = "AU3_MouseClickDrag", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MouseClickDrag([MarshalAs(UnmanagedType.LPStr)] string Button, int nX1, int nY1, int nX2, int nY2, int nSpeed = -1);

        /// <summary>
        /// Click on Control
        /// </summary>
        [DllImport("AutoItX3.dll", EntryPoint = "AU3_ControlClick", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int ControlClick([MarshalAs(UnmanagedType.LPStr)]string strTitle, [MarshalAs(UnmanagedType.LPStr)]string strText, [MarshalAs(UnmanagedType.LPStr)]string strControl, [MarshalAs(UnmanagedType.LPStr)] string strButton = "LEFT", int nNumClicks = 1, int nX = -2147483647, int nY = -2147483647);

        /// <summary>
        /// Get Pixel Color on Screen
        /// </summary>

        [DllImport("AutoItX3.dll", EntryPoint = "AU3_PixelGetColor")]
        public static extern int PixelGetColor(int nX, int nY);

        /// <summary>
        /// Move Window
        /// </summary>
        [DllImport("AutoItX3.dll", EntryPoint = "AU3_WinMove", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int WinMove([MarshalAs(UnmanagedType.LPStr)] string strTitle, string strText, int nX, int nY, int nWidth = -1, int nHeight = -1);


        /// <summary>
        /// Send Text or Key
        /// </summary>
        [DllImport("AutoItX3.dll", EntryPoint = "AU3_ControlSend", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int ControlSend([MarshalAs(UnmanagedType.LPStr)] string strTitle, [MarshalAs(UnmanagedType.LPStr)] string strText, [MarshalAs(UnmanagedType.LPStr)] string strControl, [MarshalAs(UnmanagedType.LPStr)] string strSendText, int nMode = 0);


    }
}