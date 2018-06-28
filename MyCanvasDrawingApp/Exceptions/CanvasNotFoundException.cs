using System;

namespace MyCanvasDrawingApp.Exceptions
{
    public class CanvasNotFoundException : Exception
    {
        public CanvasNotFoundException()
        {
        }

        public CanvasNotFoundException(string message)
            : base(message)
        {
        }

        public CanvasNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}