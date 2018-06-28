using MyCanvasDrawingApp.Enum;

namespace MyCanvasDrawingApp.Entities
{
    public class CanvasCell
    {
        public CanvasCellContentType ContentType { get; private set; }
        public char Colour { get; private set; }

        public CanvasCell(CanvasCellContentType contentType, char colour)
        {
            ContentType = contentType;
            Colour = colour;
        }
    }
}