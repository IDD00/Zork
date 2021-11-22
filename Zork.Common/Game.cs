using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Zork
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonIgnore]
        public static Game Instance { get; private set; }

        public World World { get; private set; }

        public string StartingLocation { get; set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        public bool IsRunning { get; set; }

        [JsonIgnore]
        public Dictionary<string, Command> Commands { get; private set; }

        [JsonIgnore]
        public IInputService Input { get; private set; }

        [JsonIgnore]
        public IOutputService Output { get; private set; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;

            Commands = new Dictionary<string, Command>()
            {
                { "QUIT", new Command("QUIT", new string[] { "QUIT", "Q", "BYE" }, Quit) },
                { "LOOK", new Command("LOOK", new string[] { "LOOK", "L" }, Look) },
                { "NORTH", new Command("NORTH", new string[] { "NORTH", "N" }, game => Move(game, Directions.North)) },
                { "SOUTH", new Command("SOUTH", new string[] { "SOUTH", "S" }, game => Move(game, Directions.South)) },
                { "EAST", new Command("EAST", new string[] { "EAST", "E"}, game => Move(game, Directions.East)) },
                { "WEST", new Command("WEST", new string[] { "WEST", "W" }, game => Move(game, Directions.West)) },
                { "UP", new Command("UP", new string[] { "UP", "U" }, game => Move(game, Directions.Up)) },
                { "DOWN", new Command("DOWN", new string[] { "DOWN", "D" }, game => Move(game, Directions.Down)) },
                { "SCORE", new Command("SCORE", new string[] { "SCORE" }, Score) },
                { "REWARD", new Command("REWARD", new string[] { "REWARD" }, Reward) },
            };
        }

        public static void Start(string gameFilename, IInputService input, IOutputService output)
        {
            Assert.IsNotNull(gameFilename);

            Instance = Game.Load(gameFilename);
            Instance.Input = input;
            Instance.Output = output;
            Instance.IsRunning = true;
            Instance.Input.InputReceived += Instance.InputReceivedHandler;
        }

        public static void StartFromFile(string gameFilename, IInputService input, IOutputService output)
        {
            if (!File.Exists(gameFilename))
            {
                throw new FileNotFoundException("Expected file.", gameFilename);
            }

            Instance = Game.LoadFromFile(gameFilename);
            Instance.Input = input;
            Instance.Output = output;
            Instance.IsRunning = true;
            Instance.Input.InputReceived += Instance.InputReceivedHandler;
        }

        private void InputReceivedHandler(object sender, string inputString)
        {
            Room previousRoom = Player.Location;
            Command foundCommand = null;
            foreach (Command command in Commands.Values)
            {
                if (command.Verbs.Contains(inputString.Trim().ToUpper()))
                {
                    foundCommand = command;
                    break;
                }
            }

            if (foundCommand != null)
            {
                foundCommand.Action(this);

                if (previousRoom != Player.Location)
                {
                    Look(this);
                }

            }
            else
            {
                Output.WriteLine("Unknown command.\n");
            }
        }

        private static void Move(Game game, Directions direction)
        {
            if (game.Player.Move(direction) == false)
            {
                game.Output.WriteLine("The way is shut!\n");
            }
        }

        private static void Look(Game game)
        {
            game.Output.WriteLine($"{game.Player.Location.Name}\n{game.Player.Location.Description}\n");
            game.Player.Moves += 1;
        }

        private static void Quit(Game game) => game.IsRunning = false;

        private static void Score(Game game)
        {
            game.Output.WriteLine($"Your score would be {game.Player.Score}, in {game.Player.Moves} move(s).\n");
            game.Player.Moves += 1;
        }

        private static void Reward(Game game)
        {
            game.Player.Score += 1;
            game.Player.Moves += 1;
        }

        public static Game Load(string gameJsonString)
        {
            Game game = JsonConvert.DeserializeObject<Game>(gameJsonString);
            game.Player = new Player(game.World, game.StartingLocation);

            return game;
        }

        public static Game LoadFromFile(string gameJsonString)
        {
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameJsonString));
            game.Player = new Player(game.World, game.StartingLocation);

            return game;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context) => Player = new Player(World, StartingLocation);
    }
}