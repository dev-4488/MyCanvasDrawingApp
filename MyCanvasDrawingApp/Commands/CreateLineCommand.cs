using MyCanvasDrawingApp.Entities;
using MyCanvasDrawingApp.Exceptions;
using MyCanvasDrawingApp.Interfaces;
using System;

namespace MyCanvasDrawingApp.Commands
{
    public class CreateLineCommand : ICommand
    {
        private IReceiver _receiver;

        public string Description => "Create a new line from (x1,y1) to (x2,y2).";

        public string Key => "L";

        public string Arguments => "x1 y1 x2 y2";

        public CreateLineCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (args.Length < 4)
                throw new ArgumentException($"This command expects 4 arguments but only received {args.Length}");

            if (!uint.TryParse(args[0], out uint x1)
             || !uint.TryParse(args[1], out uint y1)
             || !uint.TryParse(args[2], out uint x2)
             || !uint.TryParse(args[3], out uint y2)
            )
                throw new ArgumentException("There is some invalid arguments. All 4 arguments should be positive integers");

            if (_receiver.CurrentCanvas == null)
                throw new CanvasNotFoundException("No canvas exist. Please create one then try again.");

            Point start = new Point(x1 - 1, y1 - 1);
            Point end = new Point(x2 - 1, y2 - 1);
            _receiver.CreateLine(new Line(start, end));
        }
    }
}