using MyCanvasDrawingApp.Entities;
using MyCanvasDrawingApp.Exceptions;
using MyCanvasDrawingApp.Interfaces;
using System;

namespace MyCanvasDrawingApp.Commands
{
    public class BucketFillCommand : ICommand
    {
        private IReceiver _receiver;

        public string Arguments => "x y c";

        public string Description => "fill the entire area connected to (x,y) with color c.";

        public string Key => "B";

        public BucketFillCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (args.Length < 3)
                throw new ArgumentException($"This command expects 3 arguments but only received {args.Length}");

            if (!uint.TryParse(args[0], out uint x)
             || !uint.TryParse(args[1], out uint y)
             || !char.TryParse(args[2], out char color))
                throw new ArgumentException("There are some invalid arguments. The 2 first arguments should be positive integer and the last one should be an alphanumerical character");

            if (_receiver.CurrentCanvas == null)
                throw new CanvasNotFoundException("No canvas exist. Please create one then try again.");

            _receiver.BucketFill(new Point(x - 1, y - 1), color);
        }
    }
}