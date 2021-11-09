using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zork;
using Newtonsoft.Json;
using System.IO;
using Zork.Builder.ViewModels;
using System.Reflection;

namespace Zork.Builder
{
    public partial class MainForm : Form
    {
        public static string AssemblyTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

        private GameViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    gameViewModelBindingSource.DataSource = _viewModel;
                }
            }
        }

        private bool IsGameLoaded
        {
            get => _isGameLoaded;
            set
            {
                _isGameLoaded = value;
                mainFormTabControl.Enabled = _isGameLoaded;
                saveToolStripMenuItem.Enabled = _isGameLoaded;
                saveAsToolStripMenuItem.Enabled = _isGameLoaded;
            }
        }

        public string AssignedLocation
        {
            get => (string)startLocationComboBox.SelectedItem;
            set => startLocationComboBox.SelectedItem = value;
        }

        public string StartLocation
        {
            get => _startLocation;
            set
            {
                if (_startLocation != value)
                {
                    _startLocation = value;
                }

                if (_startLocation != null)
                {
                    var roomNames = new List<string>();
                    foreach (Room room in ViewModel.Rooms)
                    {
                        roomNames.Add(room.Name);
                    }
                    roomNames.Insert(0, NoLocation);

                    startLocationComboBox.SelectedIndexChanged -= StartLocationComboBox_SelectedIndexChanged;
                    startLocationComboBox.DataSource = roomNames;

                    AssignedLocation = _startLocation;

                    startLocationComboBox.SelectedIndexChanged += StartLocationComboBox_SelectedIndexChanged;
                }
                else
                {
                    AssignedLocation = NoLocation;
                    startLocationComboBox.DataSource = null;
                }

                if (_startLocation != value)
                {
                    _startLocation = value;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new GameViewModel();
            IsGameLoaded = false;

            _roomNeighborControlMap = new Dictionary<Directions, RoomNeighborControl>
            {
                {Directions.NORTH, northRoomNeighborControl },
                {Directions.SOUTH, southRoomNeighborControl },
                {Directions.EAST, eastRoomNeighborControl },
                {Directions.WEST, westRoomNeighborControl },
                {Directions.UP, upRoomNeighborControl },
                {Directions.DOWN, downRoomNeighborControl }
            };
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;

                StartLocation = ViewModel.Game.World.StartingLocation;
                Room selectedRoom = roomsListBox.SelectedItem as Room;
                foreach (var control in _roomNeighborControlMap.Values)
                {
                    control.Game = ViewModel.Game;
                    control.Room = selectedRoom;
                }

                IsGameLoaded = true;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWorld();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                SaveWorld();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (AddRoomForm addRoomForm = new AddRoomForm())
            {
                if (addRoomForm.ShowDialog() == DialogResult.OK)
                {
                    Room room = new Room(addRoomForm.RoomName);
                    ViewModel.Rooms.Add(room);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this room?", AssemblyTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViewModel.Rooms.Remove((Room)roomsListBox.SelectedItem);
                roomsListBox.SelectedItem = ViewModel.Rooms.FirstOrDefault();
            }
        }

        private void RoomsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = roomsListBox.SelectedItem != null;

            UpdateNeighborNames();

            Room selectedRoom = roomsListBox.SelectedItem as Room;
            foreach (var control in _roomNeighborControlMap.Values)
            {
                control.Game = ViewModel.Game;
                control.Room = selectedRoom;
            }

            
            string selectedLocation = startLocationComboBox.SelectedItem as string;
            StartLocation = selectedLocation;
        }

        private void StartLocationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_startLocation != null)
            {
                string assignedLocation = AssignedLocation;
                if (assignedLocation == NoLocation)
                {
                    ViewModel.Game.World.StartingLocation = Empty;
                }
                else
                {
                    ViewModel.Game.World.StartingLocation = assignedLocation;
                }
            }
        }

        private void UpdateNeighborNames()
        {
            foreach (Room room in ViewModel.Rooms)
            {
                if (room.Neighbors != null)
                {
                    foreach (Directions direction in room.Neighbors.Keys)
                    {
                        if (room.Neighbors[direction].Name != room.NeighborNames[direction])
                        {
                            room.NeighborNames[direction] = room.Neighbors[direction].Name;
                        }
                    }
                }
            }
        }

        private void SaveWorld()
        {
            UpdateNeighborNames();

            if (string.IsNullOrEmpty(ViewModel.Filename))
            {
                throw new InvalidProgramException("Filename expected.");
            }

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (StreamWriter streamWriter = new StreamWriter(ViewModel.Filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, ViewModel.Game);
            }
        }

        private static readonly string NoLocation = "None";
        public static readonly string Empty = String.Empty;

        private GameViewModel _viewModel;
        private bool _isGameLoaded;
        private string _startLocation;
        private readonly Dictionary<Directions, RoomNeighborControl> _roomNeighborControlMap;

    }
}
