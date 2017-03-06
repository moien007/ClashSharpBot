/*
 * Clash Sharp Bot
 * 
 * Author : Moien007
 * Desc : Platform invoke
 */

using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

internal class Win32
{
    private const string USER32 = "user32.dll";
    private const string KERNEL32 = "kernel32.dll";
    private const bool SetLastError = true;

    [DllImport(USER32, SetLastError = SetLastError)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport(USER32, SetLastError = SetLastError)]
    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string className, string lpszWindow);

    [DllImport(USER32, SetLastError = SetLastError)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

    [DllImport(USER32, SetLastError = SetLastError)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

    [DllImport(USER32, SetLastError = SetLastError)]
    public static extern IntPtr GetForegroundWindow();

    [DllImport(USER32, SetLastError = SetLastError)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }
}