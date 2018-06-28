namespace MyCanvasDrawingApp.Interfaces
{
    public interface ICommand
    {
        string Arguments { get; }
        string Description { get; }
        string Key { get; }

        void Execute(string[] args);
    }
}