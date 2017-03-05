/*
 * Clash Sharp Bot Project
 * 
 * Author : Moien007
 * Desc : 
 */

using System.Drawing;

namespace ClashSharpBot.Bot.Logic
{
    public class Button
    {
        public Rectangle Rect
        {
            get;
            private set;
        }
        public Bitmap ButtonImage
        {
            get;
            private set;
        }

        /// <summary>
        /// Create new Instance of Button
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Button(Rectangle rect)
        {
            Rect = rect;
            ButtonImage = null;
        }

        /// <summary>
        /// Create new Instance of Button
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Button(int x, int y, int width, int height)
        {
            Rect = new Rectangle(x, y, width, height);
            ButtonImage = null;
        }

        /// <summary>
        /// Create new Instance of Button By Image
        /// </summary>
        /// <param name="image"></param>
        public Button(Bitmap image)
        {
            ButtonImage = image;
            Rect = Rectangle.Empty;
        }

        /// <summary>
        /// Click Button
        /// </summary>
        public bool Click()
        {
            Point btnStartPoint, btnEndPoint;

            // Use Point
            if(Rect != Rectangle.Empty)
            {
                btnStartPoint = new Point(Rect.X, Rect.Y);
                btnEndPoint = new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height);
            }
            else // Find Button Image and Click
            {
                btnStartPoint = BlueStacks.TemplateMatch(this.ButtonImage, 0.99f)[0];
                if (btnStartPoint != null)
                    return false;
                btnEndPoint = new Point(btnStartPoint.X + ButtonImage.Width, btnStartPoint.Y + ButtonImage.Height);
            }

            // Click 
            BlueStacks.MouseClick(PointUtils.RandomPoint(btnStartPoint, btnEndPoint));

            return true;
        }


    }
}
