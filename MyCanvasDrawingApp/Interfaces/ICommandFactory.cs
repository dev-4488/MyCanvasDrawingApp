using MyCanvasDrawingApp.Entities;
using System.Linq;

namespace MyCanvasDrawingApp.Interfaces
{
    public interface ICommandFactory
    {
        ICommand GetCommand(Input input);

        IQueryable<ICommand> GetCommands();
    }
}