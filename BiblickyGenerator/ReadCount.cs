using System;
using System.Windows.Forms;

namespace BiblickyGenerator
{
    /// <summary>
    /// Miniform just for accepting the number of repeating 
    ///   of the selected file
    /// </summary>
    public partial class ReadCount : Form
    {
        Word2VecModelCreate parent;

        /// <summary>
        /// This method reads number, otherwise it throws warning message
        ///  it works even for the key Enter 
        /// </summary>
        /// <param name="parentForm"></param>
        public ReadCount(Word2VecModelCreate parentForm)
        {
            InitializeComponent();
            parent = parentForm;

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
