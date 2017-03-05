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

        /// <summary>
        /// Create New Instance of ColorPoint
        /// </summary>
        /// <param name="color"></param>
        /// <param name="point"></param>
        public ColorPoint(Color color, Point point)
        {
            this.Point = point;
            this.Color = color;
        }

        /// <summary>
        /// Create New Instance of ColorPoint
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ColorPoint(Color color, int x, int y)
        {
            this.Point = new Point(x, y);
            this.Color = color;
        }

        /// <summary>
        /// Create New Instance of ColorPoint
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ColorPoint(string hex, int x, int y)
        {
            this.Point = new Point(x, y);
            this.Color = ImageUtils.Hex2Color(hex);
        }

        /// <summary>
        /// Create New Instance of ColorPoint
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ColorPoint(string hex, Point point)
        {
            this.Point = point;
            this.Color = ImageUtils.Hex2Color(hex);
        }

        public bool Exist
        {
            get
            {
                return BlueStacks.GetPixelColor(this.Point).Equals(this.Color);
            }
        }
    }
}
