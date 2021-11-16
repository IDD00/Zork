
namespace Zork.Builder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.worldTabPage = new System.Windows.Forms.TabPage();
            this.startLocationComboBox = new System.Windows.Forms.ComboBox();
            this.startLocationLabel = new System.Windows.Forms.Label();
            this.roomsInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.roomNeighborsGroupBox = new System.Windows.Forms.GroupBox();
            this.downRoomNeighborControl = new Zork.RoomNeighborControl();
            this.upRoomNeighborControl = new Zork.RoomNeighborControl();
            this.westRoomNeighborControl = new Zork.RoomNeighborControl();
            this.eastRoomNeighborControl = new Zork.RoomNeighborControl();
            this.southRoomNeighborControl = new Zork.RoomNeighborControl();
            this.northRoomNeighborControl = new Zork.RoomNeighborControl();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.roomDescriptionLabel = new System.Windows.Forms.Label();
            this.roomsGroupBox = new System.Windows.Forms.GroupBox();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.mainFormTabControl = new System.Windows.Forms.TabControl();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormMenuStrip.SuspendLayout();
            this.worldTabPage.SuspendLayout();
            this.roomsInfoGroupBox.SuspendLayout();
            this.roomNeighborsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameViewModelBindingSource)).BeginInit();
            this.roomsGroupBox.SuspendLayout();
            this.mainFormTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsToolStripMenuItem.Text = "&Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // mainFormMenuStrip
            // 
            this.mainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainFormMenuStrip.Name = "mainFormMenuStrip";
            this.mainFormMenuStrip.Size = new System.Drawing.Size(632, 28);
            this.mainFormMenuStrip.TabIndex = 0;
            this.mainFormMenuStrip.Text = "menuStrip1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Game files|*.json";
            this.openFileDialog.Title = "Open Game File";
            // 
            // worldTabPage
            // 
            this.worldTabPage.Controls.Add(this.startLocationComboBox);
            this.worldTabPage.Controls.Add(this.startLocationLabel);
            this.worldTabPage.Controls.Add(this.roomsInfoGroupBox);
            this.worldTabPage.Controls.Add(this.roomsGroupBox);
            this.worldTabPage.Location = new System.Drawing.Point(4, 25);
            this.worldTabPage.Name = "worldTabPage";
            this.worldTabPage.Size = new System.Drawing.Size(600, 581);
            this.worldTabPage.TabIndex = 0;
            this.worldTabPage.Text = "World";
            this.worldTabPage.UseVisualStyleBackColor = true;
            // 
            // startLocationComboBox
            // 
            this.startLocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startLocationComboBox.FormattingEnabled = true;
            this.startLocationComboBox.Location = new System.Drawing.Point(11, 32);
            this.startLocationComboBox.Name = "startLocationComboBox";
            this.startLocationComboBox.Size = new System.Drawing.Size(300, 24);
            this.startLocationComboBox.TabIndex = 5;
            this.startLocationComboBox.SelectedIndexChanged += new System.EventHandler(this.StartLocationComboBox_SelectedIndexChanged);
            // 
            // startLocationLabel
            // 
            this.startLocationLabel.AutoSize = true;
            this.startLocationLabel.Location = new System.Drawing.Point(8, 12);
            this.startLocationLabel.Name = "startLocationLabel";
            this.startLocationLabel.Size = new System.Drawing.Size(119, 17);
            this.startLocationLabel.TabIndex = 4;
            this.startLocationLabel.Text = "&Starting Location:";
            // 
            // roomsInfoGroupBox
            // 
            this.roomsInfoGroupBox.Controls.Add(this.roomNeighborsGroupBox);
            this.roomsInfoGroupBox.Controls.Add(this.roomNameLabel);
            this.roomsInfoGroupBox.Controls.Add(this.descriptionTextBox);
            this.roomsInfoGroupBox.Controls.Add(this.nameTextBox);
            this.roomsInfoGroupBox.Controls.Add(this.roomDescriptionLabel);
            this.roomsInfoGroupBox.Location = new System.Drawing.Point(192, 78);
            this.roomsInfoGroupBox.Name = "roomsInfoGroupBox";
            this.roomsInfoGroupBox.Size = new System.Drawing.Size(400, 500);
            this.roomsInfoGroupBox.TabIndex = 1;
            this.roomsInfoGroupBox.TabStop = false;
            // 
            // roomNeighborsGroupBox
            // 
            this.roomNeighborsGroupBox.Controls.Add(this.downRoomNeighborControl);
            this.roomNeighborsGroupBox.Controls.Add(this.upRoomNeighborControl);
            this.roomNeighborsGroupBox.Controls.Add(this.westRoomNeighborControl);
            this.roomNeighborsGroupBox.Controls.Add(this.eastRoomNeighborControl);
            this.roomNeighborsGroupBox.Controls.Add(this.southRoomNeighborControl);
            this.roomNeighborsGroupBox.Controls.Add(this.northRoomNeighborControl);
            this.roomNeighborsGroupBox.Location = new System.Drawing.Point(6, 167);
            this.roomNeighborsGroupBox.Name = "roomNeighborsGroupBox";
            this.roomNeighborsGroupBox.Size = new System.Drawing.Size(388, 321);
            this.roomNeighborsGroupBox.TabIndex = 4;
            this.roomNeighborsGroupBox.TabStop = false;
            this.roomNeighborsGroupBox.Text = "Neighbors";
            // 
            // downRoomNeighborControl
            // 
            this.downRoomNeighborControl.AssignedNeighbor = null;
            this.downRoomNeighborControl.Direction = Zork.Directions.DOWN;
            this.downRoomNeighborControl.Game = null;
            this.downRoomNeighborControl.Location = new System.Drawing.Point(200, 206);
            this.downRoomNeighborControl.Name = "downRoomNeighborControl";
            this.downRoomNeighborControl.Room = null;
            this.downRoomNeighborControl.Rooms = null;
            this.downRoomNeighborControl.Size = new System.Drawing.Size(150, 60);
            this.downRoomNeighborControl.TabIndex = 5;
            // 
            // upRoomNeighborControl
            // 
            this.upRoomNeighborControl.AssignedNeighbor = null;
            this.upRoomNeighborControl.Direction = Zork.Directions.UP;
            this.upRoomNeighborControl.Game = null;
            this.upRoomNeighborControl.Location = new System.Drawing.Point(32, 206);
            this.upRoomNeighborControl.Name = "upRoomNeighborControl";
            this.upRoomNeighborControl.Room = null;
            this.upRoomNeighborControl.Rooms = null;
            this.upRoomNeighborControl.Size = new System.Drawing.Size(150, 60);
            this.upRoomNeighborControl.TabIndex = 4;
            // 
            // westRoomNeighborControl
            // 
            this.westRoomNeighborControl.AssignedNeighbor = null;
            this.westRoomNeighborControl.Direction = Zork.Directions.WEST;
            this.westRoomNeighborControl.Game = null;
            this.westRoomNeighborControl.Location = new System.Drawing.Point(200, 121);
            this.westRoomNeighborControl.Name = "westRoomNeighborControl";
            this.westRoomNeighborControl.Room = null;
            this.westRoomNeighborControl.Rooms = null;
            this.westRoomNeighborControl.Size = new System.Drawing.Size(150, 60);
            this.westRoomNeighborControl.TabIndex = 3;
            // 
            // eastRoomNeighborControl
            // 
            this.eastRoomNeighborControl.AssignedNeighbor = null;
            this.eastRoomNeighborControl.Direction = Zork.Directions.EAST;
            this.eastRoomNeighborControl.Game = null;
            this.eastRoomNeighborControl.Location = new System.Drawing.Point(32, 121);
            this.eastRoomNeighborControl.Name = "eastRoomNeighborControl";
            this.eastRoomNeighborControl.Room = null;
            this.eastRoomNeighborControl.Rooms = null;
            this.eastRoomNeighborControl.Size = new System.Drawing.Size(150, 60);
            this.eastRoomNeighborControl.TabIndex = 2;
            // 
            // southRoomNeighborControl
            // 
            this.southRoomNeighborControl.AssignedNeighbor = null;
            this.southRoomNeighborControl.Direction = Zork.Directions.SOUTH;
            this.southRoomNeighborControl.Game = null;
            this.southRoomNeighborControl.Location = new System.Drawing.Point(200, 35);
            this.southRoomNeighborControl.Name = "southRoomNeighborControl";
            this.southRoomNeighborControl.Room = null;
            this.southRoomNeighborControl.Rooms = null;
            this.southRoomNeighborControl.Size = new System.Drawing.Size(150, 60);
            this.southRoomNeighborControl.TabIndex = 1;
            // 
            // northRoomNeighborControl
            // 
            this.northRoomNeighborControl.AssignedNeighbor = null;
            this.northRoomNeighborControl.Direction = Zork.Directions.NORTH;
            this.northRoomNeighborControl.Game = null;
            this.northRoomNeighborControl.Location = new System.Drawing.Point(32, 35);
            this.northRoomNeighborControl.Name = "northRoomNeighborControl";
            this.northRoomNeighborControl.Room = null;
            this.northRoomNeighborControl.Rooms = null;
            this.northRoomNeighborControl.Size = new System.Drawing.Size(150, 60);
            this.northRoomNeighborControl.TabIndex = 0;
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Location = new System.Drawing.Point(6, 23);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(49, 17);
            this.roomNameLabel.TabIndex = 0;
            this.roomNameLabel.Text = "&Name:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.descriptionTextBox.Location = new System.Drawing.Point(9, 99);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(347, 60);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataMember = "Rooms";
            this.roomsBindingSource.DataSource = this.gameViewModelBindingSource;
            // 
            // gameViewModelBindingSource
            // 
            this.gameViewModelBindingSource.DataSource = typeof(Zork.Builder.ViewModels.GameViewModel);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nameTextBox.Location = new System.Drawing.Point(9, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(300, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // roomDescriptionLabel
            // 
            this.roomDescriptionLabel.AutoSize = true;
            this.roomDescriptionLabel.Location = new System.Drawing.Point(6, 79);
            this.roomDescriptionLabel.Name = "roomDescriptionLabel";
            this.roomDescriptionLabel.Size = new System.Drawing.Size(83, 17);
            this.roomDescriptionLabel.TabIndex = 2;
            this.roomDescriptionLabel.Text = "&Description:";
            // 
            // roomsGroupBox
            // 
            this.roomsGroupBox.Controls.Add(this.roomsListBox);
            this.roomsGroupBox.Controls.Add(this.addButton);
            this.roomsGroupBox.Controls.Add(this.deleteButton);
            this.roomsGroupBox.Location = new System.Drawing.Point(5, 78);
            this.roomsGroupBox.Name = "roomsGroupBox";
            this.roomsGroupBox.Size = new System.Drawing.Size(180, 500);
            this.roomsGroupBox.TabIndex = 0;
            this.roomsGroupBox.TabStop = false;
            this.roomsGroupBox.Text = "Rooms";
            // 
            // roomsListBox
            // 
            this.roomsListBox.DataSource = this.roomsBindingSource;
            this.roomsListBox.DisplayMember = "Name";
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.ItemHeight = 16;
            this.roomsListBox.Location = new System.Drawing.Point(9, 21);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(160, 436);
            this.roomsListBox.TabIndex = 0;
            this.roomsListBox.ValueMember = "Description";
            this.roomsListBox.SelectedIndexChanged += new System.EventHandler(this.RoomsListBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 463);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 25);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "&Add...";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(99, 463);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 25);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // mainFormTabControl
            // 
            this.mainFormTabControl.Controls.Add(this.worldTabPage);
            this.mainFormTabControl.Location = new System.Drawing.Point(12, 31);
            this.mainFormTabControl.Name = "mainFormTabControl";
            this.mainFormTabControl.SelectedIndex = 0;
            this.mainFormTabControl.Size = new System.Drawing.Size(608, 610);
            this.mainFormTabControl.TabIndex = 1;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Game files|*.json";
            this.saveFileDialog.Title = "Save Game File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closeToolStripMenuItem.Text = "&Close";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 653);
            this.Controls.Add(this.mainFormTabControl);
            this.Controls.Add(this.mainFormMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Zork Builder";
            this.mainFormMenuStrip.ResumeLayout(false);
            this.mainFormMenuStrip.PerformLayout();
            this.worldTabPage.ResumeLayout(false);
            this.worldTabPage.PerformLayout();
            this.roomsInfoGroupBox.ResumeLayout(false);
            this.roomsInfoGroupBox.PerformLayout();
            this.roomNeighborsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameViewModelBindingSource)).EndInit();
            this.roomsGroupBox.ResumeLayout(false);
            this.mainFormTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage worldTabPage;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.TabControl mainFormTabControl;
        private System.Windows.Forms.GroupBox roomsGroupBox;
        private System.Windows.Forms.GroupBox roomsInfoGroupBox;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label roomDescriptionLabel;
        private System.Windows.Forms.Label startLocationLabel;
        private System.Windows.Forms.ComboBox startLocationComboBox;
        private System.Windows.Forms.GroupBox roomNeighborsGroupBox;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.BindingSource gameViewModelBindingSource;
        private System.Windows.Forms.BindingSource roomsBindingSource;
        private RoomNeighborControl northRoomNeighborControl;
        private RoomNeighborControl downRoomNeighborControl;
        private RoomNeighborControl upRoomNeighborControl;
        private RoomNeighborControl westRoomNeighborControl;
        private RoomNeighborControl eastRoomNeighborControl;
        private RoomNeighborControl southRoomNeighborControl;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

