﻿using System;

namespace MyCanvasDrawingApp.Exceptions
{
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException()
        {
        }

        public OutOfBoundsException(string message)
            : base(message)
        {
        }

        public OutOfBoundsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}