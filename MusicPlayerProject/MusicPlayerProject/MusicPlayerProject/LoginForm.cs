using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace MusicPlayerProject
{
    public partial class LoginForm : Form
    {
        CultureInfo cultureInfo = CultureInfo.CurrentCulture;
        public LoginForm()
        {
            InitializeComponent();
        }

        public void addUser(string username, string password)
        {
            using (TextWriter writer = File.CreateText("users.csv"))
            using (CsvWriter csvWriter = new CsvWriter(writer, cultureInfo))
            {
                csvWriter.WriteField(username);
                csvWriter.WriteField(SecurePasswordHasher.Hash(password));
                csvWriter.NextRecord();
                csvWriter.Flush();

            }
        }

        private bool doLoginCheck(string username, string password)
        {
            TextReader reader = File.OpenText("users.csv");
            
            CsvConfiguration config = new CsvConfiguration(cultureInfo);
            CsvParser parser = new CsvParser(reader, config);
            Dictionary<string, string> users = new Dictionary<string, string>();
            while (parser.Read())
            {
                users.Add(parser.Record[0], parser.Record[1]);
            }
            
            if(users.ContainsKey(username))
            {
                users.TryGetValue(username, out string storedPassword);
                if(SecurePasswordHasher.Verify(password, storedPassword)){
                    return true;
                }
            }
            return false;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(doLoginCheck(textBoxUsername.Text, textBoxPassword.Text))
            {
                MusicPlayerForm musicPlayerForm = new MusicPlayerForm(textBoxUsername.Text);
                Hide();
                musicPlayerForm.ShowDialog();
                Close();
            }
            else
            {
                errorProvider1.SetError(buttonLogin, "Incorrect username or password.");
            }
        }
    }
}
