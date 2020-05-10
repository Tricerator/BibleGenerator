using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblickyGenerator
{
    public partial class TrainNewModel : Form
    {
        public TrainNewModel()
        {
            InitializeComponent();
        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Button_Word2Vec_Model_train_Click(object sender, EventArgs e)
        {
            Hide();
              Word2VecModelCreate wc = new Word2VecModelCreate();
              wc.ShowDialog();
            return;
            
         }

        private void MakeResultsVisible(bool succeded, string extension, string fileName)
        {
            if (succeded)
            {
                button_change_TXT.Visible = true;
                button3.Visible = true;
                button_Word2Vec_Model_train.Visible = true;
                textbox_warning.Visible = false;
                if (extension == ".txt") textBox_result.Text = "Soubor " + Path.GetFileName(fileName) + " úspěšně upraven";
                else textBox_result.Text = "Model ze souboru " + Path.GetFileName(fileName) + " natrénován.";
                textBox_result.Visible = true;
                Show();
            }
            else
            {
                textbox_warning.Text = "Soubor musí mít příponu " + extension;
                button_change_TXT.Visible = false;
                button3.Visible = false;
                button_Word2Vec_Model_train.Visible = false;
                textbox_warning.Visible = true;
                textBox_result.Visible = false;


            }

        }

        private void ResetWindow()
        {
            button_change_TXT.Visible = true;
            button3.Visible = true;
            button_Word2Vec_Model_train.Visible = true;
            textbox_warning.Visible = false;
            textBox_result.Visible = false;
         
        }

        private void Button_change_TXT_Click(object sender, EventArgs e)
        {
            Hide();
            while (true) {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = FileManager.GetSpecifiedDirectory("PlainTexts"),
                    Filter = "Formát txt (*.txt)|*.txt|Všechny formáty (*.*)|*.*",
                    RestoreDirectory = true
                };


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (openFileDialog1.FileName.EndsWith(".txt"))
                        {
                            TransformTXTFile.TransformFile(openFileDialog1.FileName);
                            MakeResultsVisible(true, ".txt", openFileDialog1.FileName);
                            break;
                        }
                        else
                        {
                            MakeResultsVisible(false, ".txt", openFileDialog1.FileName);
                            Show();
                        }
                    }
                    catch (SecurityException)
                    {
                        MessageBox.Show("Chyba při načítání souboru.");
                    }
                }
                else
                {
                    ResetWindow();
                    Show();
                    break;
                    
                }
            }
           
        }

        private void Textbox_warning_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
