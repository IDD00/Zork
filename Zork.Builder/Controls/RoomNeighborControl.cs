using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zork
{
    public partial class RoomNeighborControl : UserControl
    {
        public Room Room
        {
            get => _room;
            set
            {
                if (_room != value)
                {
                    _room = value;
                    if (_room != null)
                    {
                        var rooms = new List<Room>(Rooms);
                        rooms.Remove(_room);
                        rooms.Insert(0, NoNeighbor);

                        roomNeighborComboBox.SelectedIndexChanged -= RoomNeighborComboBox_SelectedIndexChanged;
                        roomNeighborComboBox.DataSource = rooms;

                        if (_room.Neighbors != null)
                        {
                            if (_room.Neighbors.TryGetValue(Direction, out Room neighbor))
                            {
                                AssignedNeighbor = neighbor;
                            }
                            else
                            {
                                AssignedNeighbor = NoNeighbor;
                            }
                        }
                        else
                        {
                            _room.NeighborNames = new Dictionary<Directions, string>();
                            _room.Neighbors = new Dictionary<Directions, Room>();
                        }
                        

                        roomNeighborComboBox.SelectedIndexChanged += RoomNeighborComboBox_SelectedIndexChanged;
                    }
                    else
                    {
                        roomNeighborComboBox.DataSource = null;
                    }
                }
            }
        }

        public Directions Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                neighborDirectionTextBox.Text = _direction.ToString();
            }
        }

        public Room AssignedNeighbor
        {
            get => (Room)roomNeighborComboBox.SelectedItem;
            set => roomNeighborComboBox.SelectedItem = value;
        }

        public RoomNeighborControl()
        {
            InitializeComponent();
        }
        private void RoomNeighborComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_room != null)
            {
                Room assignedNeighbor = AssignedNeighbor;
                if (assignedNeighbor == NoNeighbor)
                {
                    _room.Neighbors.Remove(Direction);
                    _room.NeighborNames.Remove(Direction);
                }
                else
                {
                    if (_room.Neighbors != null)
                    {
                        _room.Neighbors[Direction] = assignedNeighbor;
                        _room.NeighborNames[Direction] = assignedNeighbor.Name;
                    }
                    else
                    {
                        _room.Neighbors.Add(Direction, assignedNeighbor);
                        _room.NeighborNames.Add(Direction, assignedNeighbor.Name);
                    }
                }
            }
        }

        public BindingList<Room> Rooms { get; set; }

        public Game Game
        {
            get => _game;
            set
            {
                if (_game != value)
                {
                    _game = value;

                    if (_game != null)
                    {
                        Rooms = new BindingList<Room>(_game.World.Rooms);
                    }
                    else
                    {
                        Rooms = new BindingList<Room>(Array.Empty<Room>());
                    }
                }
            }
        }

        private Game _game;

        private static readonly Room NoNeighbor = new Room("None");

        private Directions _direction;
        private Room _room;

    }
}
