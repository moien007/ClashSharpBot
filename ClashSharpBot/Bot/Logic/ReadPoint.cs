using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;


namespace ClashSharpBot.Bot.Logic
{
    public class ReadPoint
    {
        public Rectangle Rectangle { get; set; }

        public int X => Rectangle.X;
        public int Y => Rectangle.Y;
        public int Width => Rectangle.Width;
        public int Height => Rectangle.Height;

        public ReadPoint()
        {
            Rectangle = Rectangle.Empty;
        }

        public ReadPoint(Rectangle rect)
        {
            Rectangle = rect;
        }

        public ReadPoint(Point pos, Size size)
        {
            Rectangle = new Rectangle(pos, size);
        }

        public ReadPoint(int x, int y, int width, int height)
        {
            Rectangle = new Rectangle(x, y, width, height);
        }

        public string ReadText()
        {
            return OCR.ReadText(Rectangle);
        }

        public int ReadNumber()
        {
            return OCR.ReadNumber(Rectangle);
        }
    }
}
