using System;
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
        public Menu()
        {
            InitializeComponent();
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

        }
    }
}
