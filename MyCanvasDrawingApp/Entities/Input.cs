namespace MyCanvasDrawingApp.Entities
{
    public class Input
    {
        public string Command { get; private set; }

        public string[] Args { get; private set; }

        public Input(string command, string[] args)
        {
            Command = command;
            Args = args;
        }
    }
}