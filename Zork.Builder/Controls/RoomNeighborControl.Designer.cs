namespace Zork
{
    partial class RoomNeighborControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.neighborDirectionTextBox = new System.Windows.Forms.TextBox();
            this.roomNeighborComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // neighborDirectionTextBox
            // 
            this.neighborDirectionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neighborDirectionTextBox.Location = new System.Drawing.Point(3, 3);
            this.neighborDirectionTextBox.Name = "neighborDirectionTextBox";
            this.neighborDirectionTextBox.ReadOnly = true;
            this.neighborDirectionTextBox.Size = new System.Drawing.Size(143, 22);
            this.neighborDirectionTextBox.TabIndex = 0;
            this.neighborDirectionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // roomNeighborComboBox
            // 
            this.roomNeighborComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomNeighborComboBox.FormattingEnabled = true;
            this.roomNeighborComboBox.Location = new System.Drawing.Point(3, 31);
            this.roomNeighborComboBox.Name = "roomNeighborComboBox";
            this.roomNeighborComboBox.Size = new System.Drawing.Size(143, 24);
            this.roomNeighborComboBox.TabIndex = 1;
            this.roomNeighborComboBox.SelectedIndexChanged += new System.EventHandler(this.roomNeighborComboBox_SelectedIndexChanged);
            // 
            // RoomNeighborControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roomNeighborComboBox);
            this.Controls.Add(this.neighborDirectionTextBox);
            this.Name = "RoomNeighborControl";
            this.Size = new System.Drawing.Size(150, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox neighborDirectionTextBox;
        public System.Windows.Forms.ComboBox roomNeighborComboBox;
    }
}
