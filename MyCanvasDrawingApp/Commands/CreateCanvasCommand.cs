using MyCanvasDrawingApp.Entities;
using MyCanvasDrawingApp.Interfaces;
using System;

namespace MyCanvasDrawingApp.Commands
{
    public class CreateCanvasCommand : ICommand
    {
        private IReceiver _receiver;
        public string Description => "Create a new canvas of width w and height h. Usage: C w h";

        public string Key => "C";

        public string Arguments => "w h";

        public CreateCanvasCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (args.Length < 2)
                throw new ArgumentException($"This command expects 2 arguments but only received {args.Length}");

            if (!uint.TryParse(args[0], out uint width)
             || !uint.TryParse(args[1], out uint height))
                throw new ArgumentException("There is some invalid arguments. Both arguments should be positive integers");

            _receiver.CreateCanvas(new Canvas(width, height));
        }
    }
}