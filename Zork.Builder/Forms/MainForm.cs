﻿using System;
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;

                Room selectedRoom = roomsListBox.SelectedItem as Room;
                foreach (var control in _roomNeighborControlMap.Values)
                {
                    control.Rooms = new List<Room>(ViewModel.Rooms);
                    control.Room = selectedRoom;
                }

                IsGameLoaded = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this room?", AssemblyTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViewModel.Rooms.Remove((Room)roomsListBox.SelectedItem);
                roomsListBox.SelectedItem = ViewModel.Rooms.FirstOrDefault();
            }
        }

        private void roomsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = roomsListBox.SelectedItem != null;
            Room selectedRoom = roomsListBox.SelectedItem as Room;
            foreach (var control in _roomNeighborControlMap.Values)
            {
                control.Rooms = new List<Room>(ViewModel.Rooms);
                control.Room = selectedRoom;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWorld();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                SaveWorld();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveWorld()
        {
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

        private GameViewModel _viewModel;
        private bool _isGameLoaded;
        private readonly Dictionary<Directions, RoomNeighborControl> _roomNeighborControlMap;
    }
}
