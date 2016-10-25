/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : Color Points (PixelPoint)
 *        Pixels On -> Village(Home Screen), Game Window's, MessageBox's and More
 */

using System;
using System.Drawing;

using ClashSharpBot.Bot.CoC;

namespace ClashSharpBot.Bot
{
    class ColorPoints
    {
        //public static ColorPoint TestColorPoint = new ColorPoint(Color.Khaki, 10, 10);   TEST

        // The Pixel Exist When Zoom Out
        public static ColorPoint Village_ZoomOut = new ColorPoint(Color.Empty, Point.Empty);

        // The Pixel Exist When User Have Dark Elixir (A Pixel of Dark Elixir Picture on The Top Left)
        public static ColorPoint Village_Resource_DarkElixir = new ColorPoint(Color.Empty, Point.Empty);

        // The Pixel Exist When User Earn Achivment (Red Color on Achivment Button)
        public static ColorPoint Village_Achivment_Exist = new ColorPoint(Color.Empty, Point.Empty);

        // The Pixel in Loading Screen
        public static ColorPoint LoadingScreen = new ColorPoint(Color.Empty, Point.Empty);

        // The Pixel Exist When Select Barracks1 and more
        public static ColorPoint Window_Army_Barracks1 = new ColorPoint(Color.Empty, Point.Empty);
        public static ColorPoint Window_Army_Barracks2 = new ColorPoint(Color.Empty, Point.Empty);
        public static ColorPoint Window_Army_Barracks3 = new ColorPoint(Color.Empty, Point.Empty);
        public static ColorPoint Window_Army_Barracks4 = new ColorPoint(Color.Empty, Point.Empty);

        // The Pixel Exist When Disable Shield and Attack MessageBox Shown
        public static ColorPoint MessageBox_DisableShield = new ColorPoint(Color.Empty, Point.Empty);
    }
}
