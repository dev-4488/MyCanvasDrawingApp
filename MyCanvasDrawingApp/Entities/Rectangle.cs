using System.Collections.Generic;

namespace MyCanvasDrawingApp.Entities
{
    public class Rectangle
    {
        public Point UpperLeft { get; private set; }
        public Point UpperRight { get; private set; }
        public Point LowerRight { get; private set; }
        public Point LowerLeft { get; private set; }

        public Rectangle(Point upperLeft, Point lowerRight)
        {
            UpperLeft = upperLeft;
            UpperRight = new Point(upperLeft.X, lowerRight.Y);
            LowerRight = lowerRight;
            LowerLeft = new Point(lowerRight.X, upperLeft.Y);
        }

        public IEnumerable<Line> GetLines()
        {
            return new List<Line>
            {
                new Line (UpperLeft, UpperRight),
                new Line (UpperRight, LowerRight),
                new Line (LowerLeft, LowerRight),
                new Line (LowerLeft, UpperLeft)
            };
        }
    }
}