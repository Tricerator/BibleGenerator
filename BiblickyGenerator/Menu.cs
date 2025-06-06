﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblickyGenerator
{
    /// <summary>
    /// Initial form for the whole program
    /// 
    /// Important methods are 
    ///         Button_exit_click - for exit
    ///         TrainNewModelButton_Click - for training and transforming text
    ///         Button_INLINE_W2V_Click - for inline paraphrasing from trained model
    ///         Button_help_Click - for viewing help
    ///         Button_W2V_Transform_File_Click - for paraphrasing file
    /// </summary>
    public partial class Menu : Form
    {
        /// <summary>
        ///  FileManager.manageDirectories() method creates directories needed for the program, 
        ///         mostly empty except for PlainTexts - there is one txt file
        ///  
        /// </summary>
        public Menu()
        {
            InitializeComponent();
            DirectoryManager.ManageDirectories();
        }

        private void TrainNewModelButton_Click(object sender, EventArgs e)
        {
            TrainNewModel trainNew = new TrainNewModel();
            this.Hide();
            trainNew.ShowDialog();
            this.Show();            

        }

        

        private void Button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_INLINE_W2V_Click(object sender, EventArgs e)
        {
            Inline_paraphrasing inlineP = new Inline_paraphrasing();
            Hide();
            inlineP.ShowDialog();
            Show();
        }

        private void Button_W2V_Transform_File_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void Button_help_Click(object sender, EventArgs e)
        {

            string help = "Nyní jste v hlavním okně celé aplikace. Buď můžete "
                + "natrénovat nový model, nebo můžete využít modelů již natrénovaných. "
                + "webových stránek. Pomocí těchto modelů můžete buď parafrázovat celý soubor, či si je vyzkoušet " +
                "v in-line parafrázování, kde si navíc můžete výsledky uložit. ";
                
            MessageBox.Show(help);
        }
    }
}
