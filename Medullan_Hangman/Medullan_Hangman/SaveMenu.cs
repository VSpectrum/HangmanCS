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
    public partial class SaveMenu : Form
    {
        HashSet<int> wordsplayedimported = new HashSet<int>();
        int wins;
        int losses;
        int latestID;
        public SaveMenu(int numwins, int numlosses, HashSet<int> wordsplayed)
        {
            InitializeComponent();
            foreach (int wordIDplayed in wordsplayed) wordsplayedimported.Add(wordIDplayed);
            wins = numwins;
            losses = numlosses;
        }

        private void button1_Click(object sender, EventArgs e) //save
        {
            System.Data.SqlServerCe.SqlCeConnection con = new System.Data.SqlServerCe.SqlCeConnection();
            System.Data.SqlServerCe.SqlCeDataAdapter daHangmanDB;
            DataRow drow;
            DataSet dsSavedGames = new DataSet();
            DataSet dsSavedGame_Words = new DataSet();
            con.ConnectionString = "Data Source=HangmanDB.sdf";

            con.Open();
            daHangmanDB = new System.Data.SqlServerCe.SqlCeDataAdapter("SELECT * From SavedGames", con);
            daHangmanDB.Fill(dsSavedGames, "SavedGames");
            con.Close();

            if (dsSavedGames.Tables["SavedGames"].Rows.Count > 0)
            {
                drow = dsSavedGames.Tables["SavedGames"].Rows[dsSavedGames.Tables["SavedGames"].Rows.Count - 1];
                latestID = System.Convert.ToInt32(drow[0]) + 1;
            }
            else latestID = 0;

            drow = dsSavedGames.Tables["SavedGames"].NewRow();
            drow[1] = textBox1.Text;
            drow[2] = wins;
            drow[3] = losses;
            drow[4] = DateTime.Now;
            dsSavedGames.Tables["SavedGames"].Rows.Add(drow);

            con.Open();
            System.Data.SqlServerCe.SqlCeCommandBuilder cb;
            cb = new System.Data.SqlServerCe.SqlCeCommandBuilder(daHangmanDB);
            cb.DataAdapter.Update(dsSavedGames.Tables["SavedGames"]);
            con.Close();

            /*---------------------------------------------------------------------*/

            con.Open();
            daHangmanDB = new System.Data.SqlServerCe.SqlCeDataAdapter("SELECT * From SavedGame_Words", con);
            daHangmanDB.Fill(dsSavedGame_Words, "SavedGame_Words");
            con.Close();

            foreach (int id in wordsplayedimported)
            {
                drow = dsSavedGame_Words.Tables["SavedGame_Words"].NewRow();
                drow[0] = latestID;
                drow[1] = id;
                dsSavedGame_Words.Tables["SavedGame_Words"].Rows.Add(drow);
            }

            con.Open();
            cb = new System.Data.SqlServerCe.SqlCeCommandBuilder(daHangmanDB);
            cb.DataAdapter.Update(dsSavedGame_Words.Tables["SavedGame_Words"]);
            con.Close();

            MessageBox.Show("Game Saved");
        }
    }
}
