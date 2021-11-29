using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using CsvHelper;


namespace MusicPlayerProject
{
    public partial class MusicPlayerForm : Form
    {
        MediaElement musicPlayerMediaElement;
        LinkedList<string> songs = new LinkedList<string>();

        public MusicPlayerForm()
        {
            InitializeComponent();
        }

        public MusicPlayerForm(string username)
        {
            InitializeComponent();
            pictureBox1.Visible = true;
            labelUserWelcome.Text = "Welcome, " + username;
        }

        private void buttonAddSong_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Filter = "wav files (*.wav)|*.wav";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string filePath in fileDialog.FileNames)
                {
                    addSong(filePath);
                }

            }

        }

        private void addSong(string fileName)
        {
            songs.AddLast(fileName);
            sortSongs();
        }

        private void sortSongs()
        {
            string[] sortedSongs = (string[])MergeSorter.MergeSort(songs);
            songs.Clear();
            foreach (string song in sortedSongs)
            {
                songs.AddLast(song);
            }
            updateListBox();

        }



        private void updateListBox()
        {
            listBoxSongs.Items.Clear();
            foreach (string path in songs)
            {
                listBoxSongs.Items.Add(Path.GetFileName(path));
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkedListNode<string> filePath = songs.First;
            for (int i = 0; i < listBoxSongs.SelectedIndex; i++)
            {
                filePath = filePath.Next;
            }
            axWindowsMediaPlayer1.URL = filePath.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                //axWindowsMediaPlayer1.Dispose();
                Hide();
                loginForm.ShowDialog();
                Close();
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveSongs();
        }

        private void saveSongs()
        {
            string filePath;
            if (MessageBox.Show("This program does not store your songs locally. If you move your saved songs, they won't be available to the program anymore. Save anyway?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Comma Separated Values Files | *.csv";
                fileDialog.FileName = "SavedSongList";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = fileDialog.FileName;
                    using (CsvWriter writer = new CsvWriter(File.CreateText(filePath), CultureInfo.CurrentCulture))
                    {
                        foreach (string fileName in songs)
                        {
                            writer.WriteField(fileName);
                            writer.NextRecord();
                        }
                    }
                }


            }
        }

        private void loadSongs()
        {
            string filePath;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Comma Separated Values Files | *.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                songs.Clear();
                filePath = fileDialog.FileName;
                using (CsvParser parser = new CsvParser(File.OpenText(filePath), CultureInfo.CurrentCulture))
                {
                    while (parser.Read())
                    {
                        addSong(parser.Record[0]);
                    }
                }
            }
        }

        private void buttonLoadSongs_Click(object sender, EventArgs e)
        {
            loadSongs();
        }
    }
}
