using MyCanvasDrawingApp.Exceptions;
using MyCanvasDrawingApp.Utils;
using System;

namespace MyCanvasDrawingApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Initialize Application
            Receiver receiver = new Receiver();
            Invoker invoker = new Invoker();
            var commandFactory = CommandFactory.GetInstance(receiver);
            var commands = commandFactory.GetCommands();

            Console.WriteLine("Hello Welcome to Canvas Drawing Application!");
            Console.WriteLine("Please input from below commands");

            Console.WriteLine("====================================================================================================================================");

            foreach (var command in commands)
            {
                Console.WriteLine(@"Key: {0}, Arguments: {1}, Description: {2}", command.Key, command.Arguments, command.Description);
            }

            Console.WriteLine("=====================================================================================================================================");

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the command you want to execute");
                    var rawInput = Console.ReadLine();
                    var input = InputParser.ParseInput(rawInput);
                    invoker.Command = commandFactory.GetCommand(input);
                    invoker.ExecuteCommand(input.Args);
                    Console.WriteLine(receiver.CurrentCanvas.ToString());
                }
                catch (CommandNotFoundException cex)
                {
                    Console.WriteLine($"Error: {cex.Message}");
                }
                catch (CanvasNotFoundException cnex)
                {
                    Console.WriteLine($"Error: {cnex.Message}");
                }
                catch (InvalidLineException lnex)
                {
                    Console.WriteLine($"Error: {lnex.Message}");
                }
                catch (OutOfBoundsException oex)
                {
                    Console.WriteLine($"Error: {oex.Message}");
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine($"Error: {aex.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}