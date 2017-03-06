/*
 * Clash Sharp Bot Base
 * 
 * Author : Moien007
 * Desc : Utils for System.Drawing.Point
 */ 

using System.Drawing;
using System.Collections.Generic;
using ClashSharpBot.Base;


namespace ClashSharpBot 
{
    class PointUtils
    {
        public static Point RandomPoint(Point a, Point b) // Anti-Ban is HERE :)
        {
            int x = BasicMath.RandomInt(a.X, b.X);
            int y = BasicMath.RandomInt(a.Y, b.Y);
            return new Point(x, y);
        }
        public static Point Int2Point(int x, int y) // for save time ;)
        {
            return new Point(x, y);
        }
        
        public static Point[] MakeLine(Point source, Point destination) // for linear strategy
        {
            List<Point> points = new List<Point>();

            Point copy_of_source = source;

            points.Add(source);

            while (!copy_of_source.Equals(destination))
            {
                if (copy_of_source.X < destination.X)
                    copy_of_source.X++;

                if(copy_of_source.Y < destination.Y)
                    copy_of_source.Y++;

                points.Add(copy_of_source);
            }

            return points.ToArray();
        }
    }
}
