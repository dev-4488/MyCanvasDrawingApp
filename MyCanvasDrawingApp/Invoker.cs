using MyCanvasDrawingApp.Interfaces;

namespace MyCanvasDrawingApp
{
    public class Invoker
    {
        public ICommand Command { get; set; }

        public void ExecuteCommand(string[] args)
        {
            Command.Execute(args);
        }
    }
}