using MyCanvasDrawingApp.Entities;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyCanvasDrawingApp.Utils
{
    public class InputParser
    {
        public static Input ParseInput(string rawInput)
        {
            var input = RemoveDuplicatedSpaces(rawInput);
            var commandParts = input.Split(' ');
            var commandName = commandParts[0];
            var commandArgs = commandParts.Skip(1).ToArray();

            return new Input(commandName, commandArgs);
        }

        private static string RemoveDuplicatedSpaces(string input)
        {
            var regex = new Regex("[ ]{2,}", RegexOptions.None);
            return regex.Replace(input, " ");
        }
    }
}