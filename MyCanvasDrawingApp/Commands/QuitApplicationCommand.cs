using MyCanvasDrawingApp.Interfaces;
using System;

namespace MyCanvasDrawingApp.Commands
{
    public class QuitApplicationCommand : ICommand
    {
        public string Arguments => "";

        public string Description => "Quit Application";

        public string Key => "Q";

        public void Execute(string[] args)
        {
            Console.WriteLine("Thank you for using Drawing Application, Press Any Key to exit application");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}