using Newtonsoft.Json;
using System;

namespace Zork
{
    public class Player
    {
        public event EventHandler<Room> LocationChanged;

        public event EventHandler<int> MovesChanged;

        public event EventHandler<int> ScoreChanged;

        public World World { get; }

        [JsonIgnore]
        public Room Location
        {
            get => _location;
            private set
            {
                if (_location != value)
                {
                    _location = value;
                    LocationChanged?.Invoke(this, _location);
                }
            }
        }

        [JsonIgnore]
        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    ScoreChanged?.Invoke(this, _score);
                }
            }
        }

        [JsonIgnore]
        public int Moves
        {
            get => _moves;
            set
            {
                if (_moves != value)
                {
                    _moves = value;
                    MovesChanged?.Invoke(this, _moves);
                }
            }
        }

        public Player(World world, string startingLocation)
        {
            Assert.IsTrue(world != null);

            if (world.RoomsByName.Count != 0)
            {
                Assert.IsTrue(world.RoomsByName.ContainsKey(startingLocation));
            }

            World = world;

            if (world.RoomsByName.Count != 0)
            {
                Location = world.RoomsByName[startingLocation];
            }

            Score = 0;
            Moves = 0;
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }

        private Room _location;
        private int _score;
        private int _moves;
    }
}