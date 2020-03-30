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
    public partial class ReadCount : Form
    {
        Word2VecModelCreate parent;
        public ReadCount(Word2VecModelCreate form)
        {
            InitializeComponent();
            parent = form;

            textBox1.KeyDown += (sender, args) => {
                if (args.KeyCode == Keys.Enter)
                {
                    button1.PerformClick();
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            long output;
            if (long.TryParse(textBox1.Text, out output) && output >= 0)
            {
                parent.setNumberOfOneFile(output);
                Close();
                
            }
            else
            {
                textBox3.Text = "Číslo musí být celé a nezáporné.";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ReadCount_Load(object sender, EventArgs e)
        {
          }
 
}
}
