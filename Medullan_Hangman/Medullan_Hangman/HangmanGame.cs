using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Medullan_Hangman
{
    public partial class HangmanGame : Form
    {
        List<WordInfo> wordlist = new List<WordInfo>(); //list containing ID, catergory and words
        HashSet<int> wordsplayed = new HashSet<int>(); //ID of words already played
        int wordIDtoplay; //ID of word currently being played
        String wordtoplay; //Word currently being played
        String moddedword; //Modified word to play for easier checking
        String hiddenword; //Word hidden by _ _ _ _
        short wrongguesses;
        int numwins, numlosses;
        bool matchstarted, isWrong, freed;
        bool[] strike = new bool[7];

        public HangmanGame()
        {
            InitializeComponent();

            matchstarted = false;
            Array.Clear(strike, 0, strike.Length);
            textBoxUserInput.ReadOnly = true;

            this.AcceptButton = buttonsubmit; //enter key toggles button3 (submit letter or word)
            labelhiddenword.AutoSize = true;
            labelhiddenword.MaximumSize =  new System.Drawing.Size(320,0); // prevents label from expanding horizontally too much
            wordIDtoplay = 0;

            PopulateDataSets(); //contains sqlce connects and populating datasets
        }

        public class WordInfo //used for creating list of these 3 params
        {
            public int ID { get; set; }
            public string Cat { get; set; }
            public string Words { get; set; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen BrownPen = new Pen(Color.RosyBrown, 2);
            Pen BlackPen = new Pen(Color.Black, 2);
            SolidBrush LightBrush = new SolidBrush(Color.MintCream);
            SolidBrush LightBlueBrush = new SolidBrush(Color.LightBlue);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            /*------------------------Gallows----------------------------------*/
            e.Graphics.DrawLine(BlackPen, new Point(102,10), new Point(190,10) );
            e.Graphics.DrawLine(BlackPen, new Point(190, 10), new Point(190, 217) );
            e.Graphics.DrawLine(BlackPen, new Point(190, 217), new Point(15, 217));

            e.Graphics.DrawLine(BrownPen, new Point(102, 10), new Point(102, 40));
            e.Graphics.DrawArc(BrownPen, new Rectangle(92, 40, 20, 30), 20, 125);
            e.Graphics.DrawArc(BrownPen, new Rectangle(92, 40, 20, 60), -40, -100);
            /*-----------------------------------------------------------------*/

            if (strike[1])
            {
                e.Graphics.FillPie(LightBrush, new Rectangle(92, 40, 28, 28), 0, 360); //head
                e.Graphics.DrawArc(BlackPen, new Rectangle(92, 40, 29, 29), 0, 360);
            }
            if (strike[2])
            {
                e.Graphics.DrawArc(BlackPen, new Rectangle(101, 35, 29, 100), 100, 125); //body
            }
            if (strike[3])
            {
                e.Graphics.DrawArc(BlackPen, new Rectangle(88, 75, 29, 130), -60, -30); //arm
            }
            if (strike[4])
            {
                e.Graphics.DrawArc(BlackPen, new Rectangle(88, 75, 29, 130), -60, -80); //both arms
            }
            if (strike[5])
            {
                e.Graphics.DrawArc(BlackPen, new Rectangle(91, 127, 29, 130), -50, -40); //leg
            }
            if (strike[6])
            {
                e.Graphics.DrawArc(BlackPen, new Rectangle(91, 127, 29, 130), -50, -100); //both legs
                e.Graphics.FillPie(LightBlueBrush, new Rectangle(92, 40, 28, 28), 0, 360); //head blue
            }
            if (freed)
            {

            }
        }

        /*----------------------------startmatch button----------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (wordIDtoplay != 0) //check if match is currently in progress
            {
                if (labelwrongletters.Text != "")
                {
                    DialogResult result1 = MessageBox.Show("If you start a next match, this current match will be counted as a loss.\n" +
                    "Press 'OK' if you accept this loss, or Cancel to continue your current match", "", MessageBoxButtons.OKCancel);
                    if (result1 == DialogResult.OK)
                    {
                        ++numlosses;
                        labellosses.Text = System.Convert.ToString(numlosses);
                        wordsplayed.Add(wordIDtoplay); //adds previous played word to list
                    }
                    else return;
                }
            }

            resetparameters();

            foreach (WordInfo wordinfo in wordlist)
            {
                if (wordinfo.Cat == (string)(comboBoxCategories.SelectedValue) && !wordsplayed.Contains(wordinfo.ID))
                {
                    wordIDtoplay = wordinfo.ID;
                    wordtoplay = wordinfo.Words;
                    break;
                }
            }

            foreach (char a in wordtoplay) moddedword += a + " ";

            Regex rg = new Regex("[^a-zA-Z0-9]"); //reg exp for choosing letters and numbers
            foreach (char a in moddedword)
            {
                if (!rg.IsMatch(System.Convert.ToString(a))) hiddenword += "_";
                else hiddenword += a;
            }

            labelhiddenword.Text = hiddenword;
        }

        /*------------------------------submitbutton------------------------------*/
        private void button3_Click(object sender, EventArgs e) 
        {
            if (textBoxUserInput.Text != "" && matchstarted) //if not blank and match started
            {
                isWrong = true;
                if (textBoxUserInput.Text.Trim().Length == 1) //if they guessed one char
                {

                    char guessed = System.Convert.ToChar(textBoxUserInput.Text.Trim().ToLower()[0]);
                    char[] hiddenw = hiddenword.ToCharArray();

                    for (int i = 0; i < moddedword.Length; ++i)
                        if (guessed == moddedword.ToLower()[i])
                        {
                            hiddenw[i] = moddedword[i];
                            isWrong = false;
                        }

                    hiddenword = new String(hiddenw);
                    labelhiddenword.Text = hiddenword;

                    if (hiddenword == moddedword) //word completed
                        matchwon(true);
                }

                else
                {
                    if (textBoxUserInput.Text.ToLower().Trim() == wordtoplay.ToLower().Trim())
                        matchwon(true);
                    else
                        matchwon(false);
                }

                if (isWrong)
                {
                    ++wrongguesses;
                    labelwrongletters.Text += textBoxUserInput.Text.Trim().ToLower() + " ";
                    strike[wrongguesses] = true;
                    if (wrongguesses == 6) matchwon(false);
                }
                labelwins.Text = System.Convert.ToString(numwins);
                labellosses.Text = System.Convert.ToString(numlosses);
            }
            panel1.Refresh();
            textBoxUserInput.Text = "";
        }

        /*--------------------------------savebutton------------------------------*/
        private void buttonsave_Click(object sender, EventArgs e) 
        {
            wordsplayed.Remove(wordIDtoplay); //removes current word from played list
            SaveMenu savemenu = new SaveMenu(numwins, numlosses, wordsplayed);
            savemenu.Show();
        }

        /*--------------------------------loadbutton------------------------------*/
        private void button1_Click_1(object sender, EventArgs e) 
        {
            using (LoadMenu loadform = new LoadMenu())
                if (loadform.ShowDialog() == DialogResult.OK)
                {
                    wordsplayed = loadform.WordsPlayedID;
                    numlosses = loadform.NumLosses;
                    numwins = loadform.NumWins;

                    labelwins.Text = System.Convert.ToString(numwins);
                    labellosses.Text = System.Convert.ToString(numlosses);
                    labelhiddenword.Text = "Click Start Match to Continue";
                }
        }

        /*------------------------------myfunctions-------------------------------*/
        private void resetparameters() //clearing parameters for starting a new match
        {
            textBoxUserInput.ReadOnly = false;
            freed = false;
            matchstarted = true;
            wrongguesses = 0;
            hiddenword = "";
            moddedword = "";
            labelwrongletters.Text = "";
            labelhiddenword.Text = "";
            Array.Clear(strike, 0, strike.Length); //all strikes back to 0
            panel1.Refresh();
            return;
        }

        private void matchwon(bool won)
        {
            if (won)
            {
                ++numwins;
                isWrong = false;
                freed = true;
                Array.Clear(strike, 0, strike.Length);
                panel1.Refresh();
                MessageBox.Show("You've freed him!");
            }
            else
            {
                ++numlosses;
                isWrong = true;
                freed = false;
                for (int i = 0; i < strike.Length; ++i) strike[i] = true;
                panel1.Refresh();
                MessageBox.Show("You've freed him! Of his life.");
            }
            matchstarted = false;
            wordsplayed.Add(wordIDtoplay);
            wordIDtoplay = 0;
            textBoxUserInput.ReadOnly = true;
            //labelhiddenword.Text = "";
            return;
        }

        private void PopulateDataSets()
        {
            System.Data.SqlServerCe.SqlCeConnection con = new System.Data.SqlServerCe.SqlCeConnection();
            System.Data.SqlServerCe.SqlCeDataAdapter daHangmanDB;
            DataRow drow;
            DataSet dsWordlist = new DataSet();
            con.ConnectionString = "Data Source=HangmanDB.sdf";

            con.Open();
            daHangmanDB = new System.Data.SqlServerCe.SqlCeDataAdapter("SELECT * From Wordlist", con);
            daHangmanDB.Fill(dsWordlist, "Wordlist");
            con.Close();

            for (int i = 0; i < dsWordlist.Tables["Wordlist"].Rows.Count; ++i)
            {
                drow = dsWordlist.Tables["Wordlist"].Rows[i];
                wordlist.Add(new WordInfo { ID = System.Convert.ToInt32(drow[0]), Cat = drow[1].ToString(), Words = drow[2].ToString() });
            }

            HashSet<String> categories = new HashSet<String>(); //unique list of categories
            foreach (WordInfo wordinf in wordlist) categories.Add(wordinf.Cat);
            comboBoxCategories.DataSource = categories.ToList();
            return;
        }

    } //classform
} //namespace