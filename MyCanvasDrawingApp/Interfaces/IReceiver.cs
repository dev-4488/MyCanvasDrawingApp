using MyCanvasDrawingApp.Entities;

namespace MyCanvasDrawingApp.Interfaces
{
    public interface IReceiver
    {
        Canvas CurrentCanvas { get; }

        void CreateCanvas(Canvas canvas);

        void CreateLine(Line line);

        void CreateRectangle(Rectangle rectangle);

        void BucketFill(Point point, char color);
    }
}