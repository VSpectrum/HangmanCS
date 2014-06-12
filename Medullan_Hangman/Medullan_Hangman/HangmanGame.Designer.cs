namespace Medullan_Hangman
{
    partial class HangmanGame
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonload = new System.Windows.Forms.Button();
            this.labellosses = new System.Windows.Forms.Label();
            this.labelwins = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonsave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelwrongletters = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonsubmit = new System.Windows.Forms.Button();
            this.textBoxUserInput = new System.Windows.Forms.TextBox();
            this.buttonstartmatch = new System.Windows.Forms.Button();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.labelhiddenword = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(446, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 227);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.buttonload);
            this.panel2.Controls.Add(this.labellosses);
            this.panel2.Controls.Add(this.labelwins);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonsave);
            this.panel2.Location = new System.Drawing.Point(446, 245);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 67);
            this.panel2.TabIndex = 1;
            // 
            // buttonload
            // 
            this.buttonload.Location = new System.Drawing.Point(127, 34);
            this.buttonload.Name = "buttonload";
            this.buttonload.Size = new System.Drawing.Size(78, 34);
            this.buttonload.TabIndex = 5;
            this.buttonload.Text = "Load Game";
            this.buttonload.UseVisualStyleBackColor = true;
            this.buttonload.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labellosses
            // 
            this.labellosses.AutoSize = true;
            this.labellosses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellosses.Location = new System.Drawing.Point(72, 34);
            this.labellosses.Name = "labellosses";
            this.labellosses.Size = new System.Drawing.Size(0, 24);
            this.labellosses.TabIndex = 5;
            // 
            // labelwins
            // 
            this.labelwins.AutoSize = true;
            this.labelwins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelwins.Location = new System.Drawing.Point(72, 10);
            this.labelwins.Name = "labelwins";
            this.labelwins.Size = new System.Drawing.Size(0, 24);
            this.labelwins.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Losses:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wins:";
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(127, 0);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(78, 34);
            this.buttonsave.TabIndex = 4;
            this.buttonsave.Text = "Save Game";
            this.buttonsave.UseVisualStyleBackColor = true;
            this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.labelwrongletters);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.buttonsubmit);
            this.panel3.Controls.Add(this.textBoxUserInput);
            this.panel3.Controls.Add(this.buttonstartmatch);
            this.panel3.Controls.Add(this.comboBoxCategories);
            this.panel3.Controls.Add(this.labelhiddenword);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 300);
            this.panel3.TabIndex = 2;
            // 
            // labelwrongletters
            // 
            this.labelwrongletters.AutoSize = true;
            this.labelwrongletters.Location = new System.Drawing.Point(131, 230);
            this.labelwrongletters.Name = "labelwrongletters";
            this.labelwrongletters.Size = new System.Drawing.Size(0, 13);
            this.labelwrongletters.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wrong Letters:";
            // 
            // buttonsubmit
            // 
            this.buttonsubmit.Location = new System.Drawing.Point(275, 249);
            this.buttonsubmit.Name = "buttonsubmit";
            this.buttonsubmit.Size = new System.Drawing.Size(93, 29);
            this.buttonsubmit.TabIndex = 1;
            this.buttonsubmit.Text = "Submit";
            this.buttonsubmit.UseVisualStyleBackColor = true;
            this.buttonsubmit.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxUserInput
            // 
            this.textBoxUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserInput.Location = new System.Drawing.Point(55, 249);
            this.textBoxUserInput.Name = "textBoxUserInput";
            this.textBoxUserInput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxUserInput.Size = new System.Drawing.Size(214, 29);
            this.textBoxUserInput.TabIndex = 3;
            // 
            // buttonstartmatch
            // 
            this.buttonstartmatch.Location = new System.Drawing.Point(214, 0);
            this.buttonstartmatch.Name = "buttonstartmatch";
            this.buttonstartmatch.Size = new System.Drawing.Size(214, 29);
            this.buttonstartmatch.TabIndex = 2;
            this.buttonstartmatch.Text = "Start Match";
            this.buttonstartmatch.UseVisualStyleBackColor = true;
            this.buttonstartmatch.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategories.Location = new System.Drawing.Point(1, 1);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(207, 28);
            this.comboBoxCategories.TabIndex = 6;
            // 
            // labelhiddenword
            // 
            this.labelhiddenword.AutoSize = true;
            this.labelhiddenword.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelhiddenword.Location = new System.Drawing.Point(51, 62);
            this.labelhiddenword.Name = "labelhiddenword";
            this.labelhiddenword.Size = new System.Drawing.Size(261, 24);
            this.labelhiddenword.TabIndex = 0;
            this.labelhiddenword.Text = "             Welcome to Hangman";
            // 
            // HangmanGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(663, 324);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HangmanGame";
            this.Text = "Hangman";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelhiddenword;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Button buttonstartmatch;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserInput;
        private System.Windows.Forms.Button buttonsubmit;
        private System.Windows.Forms.Label labellosses;
        private System.Windows.Forms.Label labelwins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelwrongletters;
        private System.Windows.Forms.Button buttonload;
    }
}