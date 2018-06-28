using MyCanvasDrawingApp.Entities;
using MyCanvasDrawingApp.Enum;
using MyCanvasDrawingApp.Exceptions;
using MyCanvasDrawingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCanvasDrawingApp
{
    public class Receiver : IReceiver
    {
        #region Private Members

        private Canvas _currentCanvas;

        #endregion Private Members

        #region Properties

        public Canvas CurrentCanvas
        {
            get
            {
                return _currentCanvas;
            }
        }

        #endregion Properties

        #region IReceiver Implementation

        public void BucketFill(Point point, char color)
        {
            if (PointIsOutOfBounds(point))
                throw new Exception("The target point is out of the canvas boundaries");

            var contentTypeToFill = CurrentCanvas.Cells[point.X, point.Y].ContentType;

            var processed = new List<Point>();
            var toProcess = new Queue<Point>();

            toProcess.Enqueue(point);

            while (toProcess.Count > 0)
            {
                var currentPoint = toProcess.Dequeue();
                if (processed.Any(e => e.Equals(currentPoint)))
                {
                    continue;
                }
                processed.Add(currentPoint);
                if (!PointIsOutOfBounds(currentPoint))
                {
                    if (CurrentCanvas.Cells[currentPoint.X, currentPoint.Y].ContentType == contentTypeToFill)
                    {
                        CurrentCanvas.Cells[currentPoint.X, currentPoint.Y] = new CanvasCell(contentTypeToFill, color);

                        var leftNeighbour = new Point(currentPoint.X - 1, currentPoint.Y);
                        if (CanProcessCell(leftNeighbour, processed, toProcess))
                            toProcess.Enqueue(leftNeighbour);

                        var rightNeighbour = new Point(currentPoint.X + 1, currentPoint.Y);
                        if (CanProcessCell(rightNeighbour, processed, toProcess))
                            toProcess.Enqueue(rightNeighbour);

                        var topNeighbour = new Point(currentPoint.X, currentPoint.Y - 1);
                        if (CanProcessCell(topNeighbour, processed, toProcess))
                            toProcess.Enqueue(topNeighbour);

                        var bottomNeighbour = new Point(currentPoint.X, currentPoint.Y + 1);
                        if (CanProcessCell(bottomNeighbour, processed, toProcess))
                            toProcess.Enqueue(bottomNeighbour);
                    }
                }
            }
        }

        public void CreateRectangle(Rectangle rectangle)
        {
            if (PointIsOutOfBounds(rectangle.UpperLeft)
              || PointIsOutOfBounds(rectangle.UpperRight)
              || PointIsOutOfBounds(rectangle.LowerLeft)
              || PointIsOutOfBounds(rectangle.LowerRight)
              )
                throw new Exception("This item exceeds the canvas boundaries and cannot be drawn");

            var lines = rectangle.GetLines();

            foreach (var line in lines)
                CreateLine(line);
        }

        public void CreateCanvas(Canvas canvas)
        {
            for (var i = 0; i < canvas.Width; i++)
                for (var j = 0; j < canvas.Height; j++)
                    canvas.Cells[i, j] = new CanvasCell(CanvasCellContentType.Empty, ' ');
            _currentCanvas = canvas;
        }

        public void CreateLine(Line line)
        {
            if (!line.IsHorizontal && !line.IsVertical)
                throw new InvalidLineException("Line should be either vertical or horizontal");

            if (PointIsOutOfBounds(line.Start) || PointIsOutOfBounds(line.End))
                throw new OutOfBoundsException("This item exceeds the canvas boundaries and cannot be drawn");

            var points = line.GetPoints();
            foreach (var point in points)
                DrawPoint(point);
        }

        #endregion IReceiver Implementation

        #region Private Methods

        private bool CanProcessCell(Point point, List<Point> processed, Queue<Point> toProcess)
        {
            return !processed.Any(e => e.Equals(point)) && !toProcess.Contains(point) && !PointIsOutOfBounds(point);
        }

        private bool PointIsOutOfBounds(Point point)
        {
            return point.X >= _currentCanvas.Width || point.Y >= _currentCanvas.Height || point.X < 0 || point.Y < 0;
        }

        private void DrawPoint(Point point)
        {
            var cellContent = new CanvasCell(CanvasCellContentType.Line, 'x');
            _currentCanvas.Cells[point.X, point.Y] = cellContent;
        }

        #endregion Private Methods
    }
}