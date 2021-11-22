using System.IO;
using Newtonsoft.Json;

namespace Zork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename);

            ConsoleInputService input = new ConsoleInputService();
            ConsoleOutputService output = new ConsoleOutputService();

            Game.StartFromFile(gameFilename, input, output);

            output.WriteLine(string.IsNullOrWhiteSpace(Game.Instance.WelcomeMessage) ? "Welcome to Zork!" : Game.Instance.WelcomeMessage);
            output.WriteLine($"{Game.Instance.Player.Location.Name}\n{Game.Instance.Player.Location.Description}\n");

            while (Game.Instance.IsRunning)
            {
                
                output.Write("> ");
                input.ProcessInput();
            }

            output.WriteLine(string.IsNullOrWhiteSpace(Game.Instance.ExitMessage) ? "Thank you for playing!" : Game.Instance.ExitMessage);

        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}