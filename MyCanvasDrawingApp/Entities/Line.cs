using System;
using System.Collections.Generic;

namespace MyCanvasDrawingApp.Entities
{
    public class Line
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public bool IsHorizontal => Start.X.Equals(End.X);
        public bool IsVertical => Start.Y.Equals(End.Y);

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public IEnumerable<Point> GetPoints()
        {
            if (Start.Equals(End))
                return new List<Point> { Start };

            var points = new List<Point>();
            if (IsHorizontal)
            {
                if (End.Y > Start.Y)
                {
                    for (var i = Start.Y; i <= End.Y; i++)
                        points.Add(new Point(Start.X, i));
                }
                else
                {
                    for (var i = Start.Y; i >= End.Y; i--)
                        points.Add(new Point(Start.X, i));
                }
            }
            else if (IsVertical)
            {
                if (End.X > Start.X)
                {
                    for (var i = Start.X; i <= End.X; i++)
                        points.Add(new Point(i, Start.Y));
                }
                else
                {
                    for (var i = Start.X; i >= End.X; i--)
                        points.Add(new Point(i, Start.Y));
                }
            }
            else
                throw new NotImplementedException("Only implemented for horizontal and vertical lines");

            return points;
        }
    }
}