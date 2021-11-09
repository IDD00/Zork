using System;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace Zork
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonIgnore]
        public IOutputService Output { get; set; }

        public World World { get; private set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        private bool IsRunning { get; set; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;
        }

        public void Run()
        {
            IsRunning = true;
            Room previousRoom = null;
            while (IsRunning)
            {
                Output.WriteLine(Player.Location);
                if (previousRoom != Player.Location)
                {
                    Output.WriteLine(Player.Location.Description);
                    previousRoom = Player.Location;
                }

                Output.Write("\n> ");

                Commands command = ToCommand(Console.ReadLine().Trim());
                switch (command)
                {
                    case Commands.QUIT:
                        IsRunning = false;
                        break;

                    case Commands.LOOK:
                        Output.WriteLine(Player.Location.Description);
                        Player.Moves++;
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                    case Commands.UP:
                    case Commands.DOWN:
                        Directions direction = (Directions)command;
                        if (Player.Move(direction) == false)
                        {
                            Output.WriteLine("The way is shut!");
                        }
                        Player.Moves++;
                        break;

                    case Commands.SCORE:
                        Output.WriteLine($"Your score would be {Player.Score}, in {Player.Moves} move(s).");
                        Player.Moves++;
                        break;

                    case Commands.REWARD:
                        Player.Score += 1;
                        Player.Moves++;
                        break;

                    default:
                        Output.WriteLine("Unrecognized command.");
                        break;
                }
            }
        }

        public static Game Load(string filename, IOutputService output)
        {
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(filename));
            game.Player = game.World.SpawnPlayer();
            game.Output = output;
            return game;
        }

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, ignoreCase: true, out Commands command) ? command : Commands.UNKNOWN;
        }
    }
}
