namespace MyCanvasDrawingApp.Entities
{
    public class Point
    {
        public uint X { get; private set; }
        public uint Y { get; private set; }

        public Point(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                var point = obj as Point;
                return this.X == point.X && Y == point.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
    }
}