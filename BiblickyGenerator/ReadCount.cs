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

        private void Button1_Click(object sender, EventArgs e)
        {

            if (long.TryParse(textBox1.Text, out long output) && output >= 0)
            {
                parent.SetNumberOfOneFile(output);
                Close();
            }
            else
            {
                textBox3.Text = "Číslo musí být celé a nezáporné.";
            }
        }

      

        private void ReadCount_Load(object sender, EventArgs e)
        {
        }
 
}
}
