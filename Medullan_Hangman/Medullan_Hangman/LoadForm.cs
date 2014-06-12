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
    public partial class LoadMenu : Form
    {
        
        HashSet<int> wordsplayed = new HashSet<int>(); //ID of words already played
        int wins, losses;

        public int NumWins
        {
            get { return wins; }
        }

        public int NumLosses
        {
            get { return losses; }
        }

        public HashSet<int> WordsPlayedID
        {
            get { return wordsplayed; }
        }

        public LoadMenu()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            System.Data.SqlServerCe.SqlCeConnection con = new System.Data.SqlServerCe.SqlCeConnection();
            System.Data.SqlServerCe.SqlCeDataAdapter daHangmanDB;
            DataRow drow;
            DataSet dsSavedGames = new DataSet();
            con.ConnectionString = "Data Source=HangmanDB.sdf";

            con.Open();
            daHangmanDB = new System.Data.SqlServerCe.SqlCeDataAdapter("SELECT * From SavedGames", con);
            daHangmanDB.Fill(dsSavedGames, "SavedGames");
            con.Close();

            for (int i = 0; i < dsSavedGames.Tables["SavedGames"].Rows.Count; ++i)
            {
                drow = dsSavedGames.Tables["SavedGames"].Rows[i];
                ListViewItem listItem = new ListViewItem(System.Convert.ToString(drow[0]));
                listItem.SubItems.Add(System.Convert.ToString(drow[1]));
                listItem.SubItems.Add(System.Convert.ToString(drow[2]));
                listItem.SubItems.Add(System.Convert.ToString(drow[3]));
                listItem.SubItems.Add(System.Convert.ToString(drow[4]));
                listView1.Items.Insert(0,listItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedID = System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            wins = System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[2].Text);
            losses = System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);

            System.Data.SqlServerCe.SqlCeConnection con = new System.Data.SqlServerCe.SqlCeConnection();
            System.Data.SqlServerCe.SqlCeDataAdapter daHangmanDB;
            DataRow drow;
            DataSet dsSavedGame_Words = new DataSet();
            con.ConnectionString = "Data Source=HangmanDB.sdf";

            con.Open();
            daHangmanDB = new System.Data.SqlServerCe.SqlCeDataAdapter("SELECT * From SavedGame_Words", con);
            daHangmanDB.Fill(dsSavedGame_Words, "SavedGame_Words");
            con.Close();

            for (int i = 0; i < dsSavedGame_Words.Tables["SavedGame_Words"].Rows.Count; ++i)
            {
                drow = dsSavedGame_Words.Tables["SavedGame_Words"].Rows[i];
                if (System.Convert.ToInt32(drow[0]) == selectedID)
                {
                    wordsplayed.Add(System.Convert.ToInt32(drow[1]));
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //delete
        {
            System.Data.SqlServerCe.SqlCeConnection con = new System.Data.SqlServerCe.SqlCeConnection();
            System.Data.SqlServerCe.SqlCeDataAdapter daHangmanDB;
            DataRow drow;
            DataSet dsSavedGame_Words = new DataSet();
            con.ConnectionString = "Data Source=HangmanDB.sdf";

            con.Open();
            daHangmanDB = new System.Data.SqlServerCe.SqlCeDataAdapter("SELECT * From SavedGame_Words", con);
            daHangmanDB.Fill(dsSavedGame_Words, "SavedGame_Words");
            con.Close();

            int selectedID = System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            for (int i = 0; i < dsSavedGame_Words.Tables["SavedGame_Words"].Rows.Count; ++i)
            {
                drow = dsSavedGame_Words.Tables["SavedGame_Words"].Rows[i];
                if (System.Convert.ToInt32(drow[0]) == selectedID)
                {
                    dsSavedGame_Words.Tables["SavedGame_Words"].Rows[i].Delete(); //Marks row for deletion (does not remove)
                }
            }

            con.Open();
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM SavedGame_Words";
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            System.Data.SqlServerCe.SqlCeCommandBuilder cb;
            cb = new System.Data.SqlServerCe.SqlCeCommandBuilder(daHangmanDB);
            cb.DataAdapter.Update(dsSavedGame_Words.Tables["SavedGame_Words"]);
            con.Close();
            MessageBox.Show("Database Updated.");
            con.Close();

            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM SavedGames WHERE ID=" + System.Convert.ToString(selectedID);
            cmd.ExecuteNonQuery();
            con.Close();

            listView1.Items.Remove(listView1.SelectedItems[0]);
        }
    }
}
