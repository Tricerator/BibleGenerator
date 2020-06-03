namespace BiblickyGenerator
{
    partial class Word2VecModelCreate
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
            this.listBox_modelFiles = new System.Windows.Forms.ListBox();
            this.listBox_finalFiles = new System.Windows.Forms.ListBox();
            this.button_BackToMenu = new System.Windows.Forms.Button();
            this.button_choiceBack = new System.Windows.Forms.Button();
            this.button_buildModel = new System.Windows.Forms.Button();
            this.textBox_vectorSize = new System.Windows.Forms.TextBox();
            this.textBox_minimumAmountOfWords = new System.Windows.Forms.TextBox();
            this.textBox_numberOfIterations = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox_6 = new System.Windows.Forms.TextBox();
            this.button_putFileRight = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox_Error = new System.Windows.Forms.TextBox();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.listBox_sizeFile = new System.Windows.Forms.ListBox();
            this.listBox_percentage = new System.Windows.Forms.ListBox();
            this.listBox_NumberOfRepetition = new System.Windows.Forms.ListBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox_absoluteSize = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button_helpUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_modelFiles
            // 
            this.listBox_modelFiles.FormattingEnabled = true;
            this.listBox_modelFiles.HorizontalScrollbar = true;
            this.listBox_modelFiles.ItemHeight = 20;
            this.listBox_modelFiles.Location = new System.Drawing.Point(45, 64);
            this.listBox_modelFiles.Name = "listBox_modelFiles";
            this.listBox_modelFiles.Size = new System.Drawing.Size(201, 344);
            this.listBox_modelFiles.Sorted = true;
            this.listBox_modelFiles.TabIndex = 0;
            this.listBox_modelFiles.SelectedIndexChanged += new System.EventHandler(this.ListBox_modelFiles_SelectedIndexChanged);
            // 
            // listBox_finalFiles
            // 
            this.listBox_finalFiles.FormattingEnabled = true;
            this.listBox_finalFiles.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBox_finalFiles.ItemHeight = 20;
            this.listBox_finalFiles.Location = new System.Drawing.Point(415, 64);
            this.listBox_finalFiles.Name = "listBox_finalFiles";
            this.listBox_finalFiles.Size = new System.Drawing.Size(191, 344);
            this.listBox_finalFiles.TabIndex = 1;
            // 
            // button_BackToMenu
            // 
            this.button_BackToMenu.Location = new System.Drawing.Point(1090, 364);
            this.button_BackToMenu.Name = "button_BackToMenu";
            this.button_BackToMenu.Size = new System.Drawing.Size(136, 44);
            this.button_BackToMenu.TabIndex = 2;
            this.button_BackToMenu.Text = "Zpět do menu";
            this.button_BackToMenu.UseVisualStyleBackColor = true;
            this.button_BackToMenu.Click += new System.EventHandler(this.Button_BackToMenu_Click);
            // 
            // button_choiceBack
            // 
            this.button_choiceBack.Location = new System.Drawing.Point(266, 274);
            this.button_choiceBack.Name = "button_choiceBack";
            this.button_choiceBack.Size = new System.Drawing.Size(126, 44);
            this.button_choiceBack.TabIndex = 3;
            this.button_choiceBack.Text = "Zpět";
            this.button_choiceBack.UseVisualStyleBackColor = true;
            this.button_choiceBack.Click += new System.EventHandler(this.Button_choiceBack_Click);
            // 
            // button_buildModel
            // 
            this.button_buildModel.Location = new System.Drawing.Point(1090, 313);
            this.button_buildModel.Name = "button_buildModel";
            this.button_buildModel.Size = new System.Drawing.Size(136, 45);
            this.button_buildModel.TabIndex = 4;
            this.button_buildModel.Text = "Vytvořit model";
            this.button_buildModel.UseVisualStyleBackColor = true;
            this.button_buildModel.Click += new System.EventHandler(this.Button_buildModel_Click);
            // 
            // textBox_vectorSize
            // 
            this.textBox_vectorSize.Location = new System.Drawing.Point(1100, 109);
            this.textBox_vectorSize.Name = "textBox_vectorSize";
            this.textBox_vectorSize.Size = new System.Drawing.Size(126, 26);
            this.textBox_vectorSize.TabIndex = 5;
            this.textBox_vectorSize.Text = "100";
            // 
            // textBox_minimumAmountOfWords
            // 
            this.textBox_minimumAmountOfWords.Location = new System.Drawing.Point(1100, 143);
            this.textBox_minimumAmountOfWords.Name = "textBox_minimumAmountOfWords";
            this.textBox_minimumAmountOfWords.Size = new System.Drawing.Size(126, 26);
            this.textBox_minimumAmountOfWords.TabIndex = 6;
            this.textBox_minimumAmountOfWords.Text = "5";
            // 
            // textBox_numberOfIterations
            // 
            this.textBox_numberOfIterations.Location = new System.Drawing.Point(1100, 181);
            this.textBox_numberOfIterations.Name = "textBox_numberOfIterations";
            this.textBox_numberOfIterations.Size = new System.Drawing.Size(126, 26);
            this.textBox_numberOfIterations.TabIndex = 7;
            this.textBox_numberOfIterations.Text = "5";
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(977, 112);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(117, 19);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "velikost vektoru";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(893, 146);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(201, 19);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "minimální počet výskytu slov";
            this.textBox5.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
            // 
            // textBox_6
            // 
            this.textBox_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_6.Location = new System.Drawing.Point(996, 184);
            this.textBox_6.Name = "textBox_6";
            this.textBox_6.ReadOnly = true;
            this.textBox_6.Size = new System.Drawing.Size(98, 19);
            this.textBox_6.TabIndex = 10;
            this.textBox_6.Text = "počet iterací";
            // 
            // button_putFileRight
            // 
            this.button_putFileRight.Location = new System.Drawing.Point(266, 143);
            this.button_putFileRight.Name = "button_putFileRight";
            this.button_putFileRight.Size = new System.Drawing.Size(126, 45);
            this.button_putFileRight.TabIndex = 12;
            this.button_putFileRight.Text = "Přidej";
            this.button_putFileRight.UseVisualStyleBackColor = true;
            this.button_putFileRight.Click += new System.EventHandler(this.Button_putFileRight_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(283, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 37);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "⇒⇒⇒⇒";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(283, 231);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 37);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "⇐⇐⇐⇐";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Error
            // 
            this.textBox_Error.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Error.Location = new System.Drawing.Point(893, 274);
            this.textBox_Error.Multiline = true;
            this.textBox_Error.Name = "textBox_Error";
            this.textBox_Error.ReadOnly = true;
            this.textBox_Error.Size = new System.Drawing.Size(191, 134);
            this.textBox_Error.TabIndex = 15;
            this.textBox_Error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Location = new System.Drawing.Point(1100, 68);
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.Size = new System.Drawing.Size(126, 26);
            this.textBox_fileName.TabIndex = 16;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(977, 71);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(117, 23);
            this.textBox6.TabIndex = 17;
            this.textBox6.Text = "jméno modelu";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox7.Location = new System.Drawing.Point(45, 21);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(201, 30);
            this.textBox7.TabIndex = 18;
            this.textBox7.Text = "zdrojové soubory";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox8.Location = new System.Drawing.Point(415, 21);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(191, 30);
            this.textBox8.TabIndex = 19;
            this.textBox8.Text = "model";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox11.Location = new System.Drawing.Point(690, 21);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(97, 30);
            this.textBox11.TabIndex = 22;
            this.textBox11.Text = "velikost";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox12.Location = new System.Drawing.Point(793, 21);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(72, 30);
            this.textBox12.TabIndex = 23;
            this.textBox12.Text = "%";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBox_sizeFile
            // 
            this.listBox_sizeFile.Enabled = false;
            this.listBox_sizeFile.FormattingEnabled = true;
            this.listBox_sizeFile.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBox_sizeFile.ItemHeight = 20;
            this.listBox_sizeFile.Location = new System.Drawing.Point(690, 64);
            this.listBox_sizeFile.Name = "listBox_sizeFile";
            this.listBox_sizeFile.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_sizeFile.Size = new System.Drawing.Size(97, 344);
            this.listBox_sizeFile.TabIndex = 24;
            // 
            // listBox_percentage
            // 
            this.listBox_percentage.Enabled = false;
            this.listBox_percentage.FormattingEnabled = true;
            this.listBox_percentage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBox_percentage.ItemHeight = 20;
            this.listBox_percentage.Location = new System.Drawing.Point(793, 64);
            this.listBox_percentage.Name = "listBox_percentage";
            this.listBox_percentage.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_percentage.Size = new System.Drawing.Size(72, 344);
            this.listBox_percentage.TabIndex = 25;
            // 
            // listBox_NumberOfRepetition
            // 
            this.listBox_NumberOfRepetition.Enabled = false;
            this.listBox_NumberOfRepetition.FormattingEnabled = true;
            this.listBox_NumberOfRepetition.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBox_NumberOfRepetition.ItemHeight = 20;
            this.listBox_NumberOfRepetition.Location = new System.Drawing.Point(612, 64);
            this.listBox_NumberOfRepetition.Name = "listBox_NumberOfRepetition";
            this.listBox_NumberOfRepetition.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_NumberOfRepetition.Size = new System.Drawing.Size(72, 344);
            this.listBox_NumberOfRepetition.TabIndex = 26;
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox9.Location = new System.Drawing.Point(612, 21);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(72, 30);
            this.textBox9.TabIndex = 27;
            this.textBox9.Text = "počet";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_absoluteSize
            // 
            this.textBox_absoluteSize.Location = new System.Drawing.Point(1100, 216);
            this.textBox_absoluteSize.Name = "textBox_absoluteSize";
            this.textBox_absoluteSize.ReadOnly = true;
            this.textBox_absoluteSize.Size = new System.Drawing.Size(126, 26);
            this.textBox_absoluteSize.TabIndex = 28;
            // 
            // textBox13
            // 
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Location = new System.Drawing.Point(977, 216);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(117, 19);
            this.textBox13.TabIndex = 29;
            this.textBox13.Text = "velikost modelu";
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox10.Location = new System.Drawing.Point(1233, 67);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(37, 23);
            this.textBox10.TabIndex = 30;
            this.textBox10.Text = ".txt";
            // 
            // button_helpUser
            // 
            this.button_helpUser.Location = new System.Drawing.Point(1090, 262);
            this.button_helpUser.Name = "button_helpUser";
            this.button_helpUser.Size = new System.Drawing.Size(136, 45);
            this.button_helpUser.TabIndex = 31;
            this.button_helpUser.Text = "Nápověda";
            this.button_helpUser.UseVisualStyleBackColor = true;
            this.button_helpUser.Click += new System.EventHandler(this.button_helpUser_Click);
            // 
            // Word2VecModelCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 506);
            this.Controls.Add(this.button_helpUser);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox_absoluteSize);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.listBox_NumberOfRepetition);
            this.Controls.Add(this.listBox_percentage);
            this.Controls.Add(this.listBox_sizeFile);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox_fileName);
            this.Controls.Add(this.textBox_Error);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_putFileRight);
            this.Controls.Add(this.textBox_6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox_numberOfIterations);
            this.Controls.Add(this.textBox_minimumAmountOfWords);
            this.Controls.Add(this.textBox_vectorSize);
            this.Controls.Add(this.button_buildModel);
            this.Controls.Add(this.button_choiceBack);
            this.Controls.Add(this.button_BackToMenu);
            this.Controls.Add(this.listBox_finalFiles);
            this.Controls.Add(this.listBox_modelFiles);
            this.Name = "Word2VecModelCreate";
            this.Text = "Tvorba modelu";
            this.Load += new System.EventHandler(this.Word2VecModelCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_modelFiles;
        private System.Windows.Forms.ListBox listBox_finalFiles;
        private System.Windows.Forms.Button button_BackToMenu;
        private System.Windows.Forms.Button button_choiceBack;
        private System.Windows.Forms.Button button_buildModel;
        private System.Windows.Forms.TextBox textBox_vectorSize;
        private System.Windows.Forms.TextBox textBox_minimumAmountOfWords;
        private System.Windows.Forms.TextBox textBox_numberOfIterations;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox_6;
        private System.Windows.Forms.Button button_putFileRight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox_Error;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.ListBox listBox_sizeFile;
        private System.Windows.Forms.ListBox listBox_percentage;
        private System.Windows.Forms.ListBox listBox_NumberOfRepetition;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox_absoluteSize;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button button_helpUser;
    }
}