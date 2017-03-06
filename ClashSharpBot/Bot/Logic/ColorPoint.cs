/*
 * Clash Sharp Bot Project
 * 
 * Auther : Moien007
 * Desc : Color and Point, For Check Pixel Exist On Screen(BlueStacks)
 */

using System.Drawing;
using ClashSharpBot.Base;

namespace ClashSharpBot.Bot
{
    public class ColorPoint // or PixelPoint
    {
        public Point Point;
        public Color Color;
        
        public ColorPoint(Color color, Point point)
        {
            this.Point = point;
            this.Color = color;
        }

        public ColorPoint(Color color, int x, int y)
        {
            this.Point = new Point(x, y);
            this.Color = color;
        }

        public ColorPoint(string hex, int x, int y)
        {
            this.Point = new Point(x, y);
            this.Color = ImageUtils.Hex2Color(hex);
        }

        public ColorPoint(string hex, Point point)
        {
            this.Point = point;
            this.Color = ImageUtils.Hex2Color(hex);
        }
        
        public bool Present
        {
            get
            {
                return BlueStacks.GetPixelColor(this.Point).Equals(this.Color);
            }
        }
    }
}
