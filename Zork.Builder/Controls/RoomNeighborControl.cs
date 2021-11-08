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
    public partial class RoomNeighborControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

                        roomNeighborComboBox.SelectedIndexChanged -= roomNeighborComboBox_SelectedIndexChanged;
                        roomNeighborComboBox.DataSource = rooms;

                        if (_room.Neighbors.TryGetValue(Direction, out Room neighbor))
                        {
                            AssignedNeighbor = neighbor;
                        }
                        else
                        {
                            AssignedNeighbor = NoNeighbor;
                        }

                        roomNeighborComboBox.SelectedIndexChanged += roomNeighborComboBox_SelectedIndexChanged;
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
        private void roomNeighborComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_room != null)
            {
                Room assignedNeighbor = AssignedNeighbor;
                if (assignedNeighbor == NoNeighbor)
                {
                    _room.Neighbors.Remove(Direction);
                }
                else
                {
                    _room.Neighbors[Direction] = assignedNeighbor;
                }
            }
        }

        public List<Room> Rooms { get; set; }

        private static readonly Room NoNeighbor = new Room("None");

        private Directions _direction;
        private Room _room;

    }
}
