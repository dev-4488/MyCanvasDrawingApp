using System;

namespace MyCanvasDrawingApp.Exceptions
{
    public class InvalidLineException : Exception
    {
        public InvalidLineException()
        {
        }

        public InvalidLineException(string message)
            : base(message)
        {
        }

        public InvalidLineException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}