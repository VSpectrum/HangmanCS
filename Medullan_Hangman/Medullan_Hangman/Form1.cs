using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Medullan_Hangman
{
    public partial class Form1 : Form
    {
        HangmanGame fHangmanGame; //form

        public Form1()
        {
            InitializeComponent();
            fHangmanGame = new HangmanGame();
        }

        private void button1_Click(object sender, EventArgs e) //New Game btn
        {
            if (fHangmanGame.IsDisposed) fHangmanGame = new HangmanGame();
            fHangmanGame.Show();
        }

        private void button3_Click(object sender, EventArgs e) //Loading a new wordlist
        {
            
            OpenFileDialog loadlist = new OpenFileDialog();

            loadlist.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            loadlist.FilterIndex = 1;
            loadlist.Multiselect = false;
            loadlist.InitialDirectory = "";

            if ( loadlist.ShowDialog() == DialogResult.OK ) //user clicked ok
            {
                String Filepath = loadlist.FileName;
                System.IO.StreamReader inpfile = new System.IO.StreamReader(Filepath);


                System.Data.SqlServerCe.SqlCeConnection con = new System.Data.SqlServerCe.SqlCeConnection();
                System.Data.SqlServerCe.SqlCeDataAdapter daHangmanDB;
                DataRow drow;
                DataSet dsWordlist = new DataSet();
                con.ConnectionString = "Data Source=HangmanDB.sdf";

                con.Open();
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Wordlist";
                cmd.ExecuteNonQuery();

                daHangmanDB = new System.Data.SqlServerCe.SqlCeDataAdapter("SELECT * From Wordlist", con);
                daHangmanDB.Fill(dsWordlist, "Wordlist");
                con.Close();

                String data, category, words;
                while ( (data = inpfile.ReadLine()) != null )
                {
                    category = data.Split(',')[0];
                    words = data.Split(',')[1];
                    drow = dsWordlist.Tables["Wordlist"].NewRow();
                    drow[1] = category;
                    drow[2] = words;
                    dsWordlist.Tables["Wordlist"].Rows.Add(drow);
                }

                con.Open();
                System.Data.SqlServerCe.SqlCeCommandBuilder cb;
                cb = new System.Data.SqlServerCe.SqlCeCommandBuilder(daHangmanDB);
                cb.DataAdapter.Update(dsWordlist.Tables["Wordlist"]);
                con.Close();
                MessageBox.Show("Database Updated.");
            }

        }
    }
}