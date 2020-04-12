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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void trainNewModelButton_Click(object sender, EventArgs e)
        {
            TrainNewModel trainNew = new TrainNewModel();
            this.Hide();
            trainNew.ShowDialog();
            this.Show();            

        }

        

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_INLINE_W2V_Click(object sender, EventArgs e)
        {
            Inline_paraphrasing inlineP = new Inline_paraphrasing();
            Hide();
            inlineP.ShowDialog();
            Show();
        }

        private void button_W2V_Transform_File_Click(object sender, EventArgs e)
        {

        }
    }
}
