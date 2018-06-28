using System;
using System.Text;

namespace MyCanvasDrawingApp.Entities
{
    public class Canvas
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        public CanvasCell[,] Cells { get; private set; }

        public Canvas(uint width, uint height)
        {
            Cells = new CanvasCell[width, height];
            Width = Cells.GetUpperBound(0) + 1;
            Height = Cells.GetUpperBound(1) + 1;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(' ');
            for (var i = 0; i < Width; i++) sb.Append('-');

            sb.Append(Environment.NewLine);

            for (var j = 0; j < Height; j++)
            {
                sb.Append('|');
                for (var i = 0; i < Width; i++)
                {
                    sb.Append(Cells[i, j].Colour);
                }
                sb.Append('|');
                sb.Append(Environment.NewLine);
            }

            sb.Append(' ');
            for (var i = 0; i < Width; i++) sb.Append('-');

            return sb.ToString();
        }
    }
}