namespace MusicPlayerProject
{
    partial class MusicPlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayerForm));
            this.buttonAddSong = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.listBoxSongs = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelUserWelcome = new System.Windows.Forms.Label();
            this.linkLabelLogout = new System.Windows.Forms.LinkLabel();
            this.groupBoxLoggedInUser = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoadSongs = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxLoggedInUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddSong
            // 
            this.buttonAddSong.Location = new System.Drawing.Point(376, 429);
            this.buttonAddSong.Name = "buttonAddSong";
            this.buttonAddSong.Size = new System.Drawing.Size(201, 23);
            this.buttonAddSong.TabIndex = 0;
            this.buttonAddSong.Text = "Add Song...";
            this.buttonAddSong.UseVisualStyleBackColor = true;
            this.buttonAddSong.Click += new System.EventHandler(this.buttonAddSong_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(339, 352);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            // 
            // listBoxSongs
            // 
            this.listBoxSongs.FormattingEnabled = true;
            this.listBoxSongs.Location = new System.Drawing.Point(376, 13);
            this.listBoxSongs.Name = "listBoxSongs";
            this.listBoxSongs.Size = new System.Drawing.Size(201, 381);
            this.listBoxSongs.TabIndex = 3;
            this.listBoxSongs.SelectedIndexChanged += new System.EventHandler(this.listBoxSongs_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // labelUserWelcome
            // 
            this.labelUserWelcome.AutoSize = true;
            this.labelUserWelcome.Location = new System.Drawing.Point(49, 23);
            this.labelUserWelcome.Name = "labelUserWelcome";
            this.labelUserWelcome.Size = new System.Drawing.Size(78, 13);
            this.labelUserWelcome.TabIndex = 5;
            this.labelUserWelcome.Text = "Welcome, user";
            // 
            // linkLabelLogout
            // 
            this.linkLabelLogout.AutoSize = true;
            this.linkLabelLogout.Location = new System.Drawing.Point(162, 46);
            this.linkLabelLogout.Name = "linkLabelLogout";
            this.linkLabelLogout.Size = new System.Drawing.Size(46, 13);
            this.linkLabelLogout.TabIndex = 6;
            this.linkLabelLogout.TabStop = true;
            this.linkLabelLogout.Text = "Logout?";
            this.linkLabelLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogout_LinkClicked);
            // 
            // groupBoxLoggedInUser
            // 
            this.groupBoxLoggedInUser.Controls.Add(this.pictureBox1);
            this.groupBoxLoggedInUser.Controls.Add(this.linkLabelLogout);
            this.groupBoxLoggedInUser.Controls.Add(this.labelUserWelcome);
            this.groupBoxLoggedInUser.Location = new System.Drawing.Point(12, 383);
            this.groupBoxLoggedInUser.Name = "groupBoxLoggedInUser";
            this.groupBoxLoggedInUser.Size = new System.Drawing.Size(214, 64);
            this.groupBoxLoggedInUser.TabIndex = 7;
            this.groupBoxLoggedInUser.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(482, 400);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(95, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save Songs";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoadSongs
            // 
            this.buttonLoadSongs.Location = new System.Drawing.Point(376, 400);
            this.buttonLoadSongs.Name = "buttonLoadSongs";
            this.buttonLoadSongs.Size = new System.Drawing.Size(95, 23);
            this.buttonLoadSongs.TabIndex = 9;
            this.buttonLoadSongs.Text = "Load Songs";
            this.buttonLoadSongs.UseVisualStyleBackColor = true;
            this.buttonLoadSongs.Click += new System.EventHandler(this.buttonLoadSongs_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(242, 390);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(116, 20);
            this.textBoxSearch.TabIndex = 10;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(242, 416);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(116, 23);
            this.buttonSearch.TabIndex = 11;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // MusicPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 459);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonLoadSongs);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxLoggedInUser);
            this.Controls.Add(this.listBoxSongs);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.buttonAddSong);
            this.Name = "MusicPlayerForm";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxLoggedInUser.ResumeLayout(false);
            this.groupBoxLoggedInUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddSong;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ListBox listBoxSongs;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelUserWelcome;
        private System.Windows.Forms.LinkLabel linkLabelLogout;
        private System.Windows.Forms.GroupBox groupBoxLoggedInUser;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoadSongs;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
    }
}