using MyCanvasDrawingApp.Commands;
using MyCanvasDrawingApp.Entities;
using MyCanvasDrawingApp.Exceptions;
using MyCanvasDrawingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCanvasDrawingApp
{
    public class CommandFactory : ICommandFactory
    {
        private static ICommandFactory _factory;
        private static IReceiver _receiver;

        private CommandFactory(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public ICommand GetCommand(Input input)
        {
            var commands = GetCommands();
            if (commands.Any(x => x.Key.Equals(input.Command, StringComparison.InvariantCultureIgnoreCase)))
            {
                return commands.FirstOrDefault(x => x.Key.Equals(input.Command, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                throw new CommandNotFoundException($"Command {input.Command} you have entered does not exist, please enter valid command");
            }
        }

        public IQueryable<ICommand> GetCommands()
        {
            List<ICommand> commands = new List<ICommand>
            {
                new CreateCanvasCommand(_receiver),
                new CreateLineCommand(_receiver),
                new CreateRectangleCommand(_receiver),
                new BucketFillCommand(_receiver),
                new QuitApplicationCommand()
            };
            return commands.AsQueryable();
        }

        public static ICommandFactory GetInstance(IReceiver receiver)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException("Receiver Object cannot be null");
            }
            else
            {
                if (_factory == null)
                {
                    _factory = new CommandFactory(receiver);
                }
                return _factory;
            }
        }
    }
}