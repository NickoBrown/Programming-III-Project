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

        /// <summary>
        /// Adds a song to the linkedList and sorts it.
        /// </summary>
        /// <param name="fileName">The File Path of the new song.</param>
        private void addSong(string filePath)
        {
            songs.AddLast(filePath);
            sortSongs();
        }

        /// <summary>
        /// Sorts the songs in the linkedlist via mergesort, then updates the listBox.
        /// </summary>
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


        /// <summary>
        /// Populates the visible listBox with the contents of the linkedlist "songs".
        /// </summary>
        private void updateListBox()
        {
            listBoxSongs.Items.Clear();
            foreach (string path in songs)
            {
                listBoxSongs.Items.Add(Path.GetFileName(path));
            }
        }


        /// <summary>
        /// Displays a dialog allowing the user to save songs to a CSV file.
        /// </summary>
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

        /// <summary>
        /// Displays a dialog allowing the user to open a CSV file, containing song data written by the program.
        /// </summary>
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
                        if (File.Exists(parser.Record[0]))
                        {
                            addSong(parser.Record[0]);
                        }
                        
                    }
                    if(songs.Count == 0)
                    {
                        MessageBox.Show("Could not load any songs.", "Load Error");
                    }
                }
            }
        }

        #region event handlers
        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkedListNode<string> filePath = songs.First;
            for (int i = 0; i < listBoxSongs.SelectedIndex; i++)
            {
                filePath = filePath.Next;
            }
            axWindowsMediaPlayer1.URL = filePath.Value;
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
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveSongs();
        }
        private void buttonLoadSongs_Click(object sender, EventArgs e)
        {
            loadSongs();
        }



        #endregion

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LinkedList<string> songsSearchable = new LinkedList<string>();
            LinkedListNode<string> node = songs.First;
            for (int i = 0; i < songs.Count(); i++)
            {
                songsSearchable.AddLast(Path.GetFileName(node.Value));
                node = node.Next;
            }
            string searchTerm = textBoxSearch.Text;
            listBoxSongs.SelectedIndex = BinarySearcher.BinarySearch(songsSearchable, searchTerm);
            
        }
    }
}
