using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BiblickyGenerator
{
    public partial class Inline_paraphrasing : Form
    {
        private string ProjectDir = Environment.CurrentDirectory + "..\\..\\..\\Models";
        public Inline_paraphrasing()
        {
            InitializeComponent();
            foreach (var dir in Directory.GetFiles(ProjectDir))
            {

                listBox_models.Items.Add(Path.GetFileNameWithoutExtension(dir));
            }

        }

        private void button_paraphrase_Click(object sender, EventArgs e)
        {
            TextBox textBoxChoice;
            Label labelChoice;

            if (textBox_output1.Text == "")
            {
                textBoxChoice = textBox_output1;
                labelChoice = label_output1;
            }
            else if (textBox_output2.Text == "")
            {
                textBoxChoice = textBox_output2;
                labelChoice = label_output2;
            }
            else if (textBox_output3.Text == "")
            {
                textBoxChoice = textBox_output3;
                labelChoice = label_output3;
            }
            else if (textBox_output4.Text == "")
            {
                textBoxChoice = textBox_output4;
                labelChoice = label_output4;
            }
            else if (textBox_output5.Text == "")
            {
                textBoxChoice = textBox_output5;
                labelChoice = label_output5;
            }
            else
            {
                string message = "Buď uložte výsledky do souboru, nebo je resetujte";
                string title = "Chyba";
                MessageBox.Show(message, title);
                return;
            }



            if ((checkBox_useMorphoDiTa.Checked == false) && listBox_models.SelectedIndex >= 0)
            {
                WordToVecWithoutMorphodita(textBoxChoice);
            }
        }

        private void WordToVecWithoutMorphodita(TextBox textBoxChoice)
        {
            string file = ProjectDir + "\\" + listBox_models.SelectedItem.ToString() + ".txt";
          
            string textFromTextbox = textBox_input.Text;

            string normalizeString = TransformTXTFile.TransformString(textFromTextbox);
            string[] words = normalizeString.Split(' ');
            List<string> rightWords = new List<string>();

            // in this section I choose 
            foreach (string word in words)
            {
                if (word.Length > 3)
                {
                    rightWords.Add(word);
                }
            }
            Dictionary<string, string> replacedWords = Word2Vec.UseWord2Vec(file, rightWords.ToArray());

            textBoxChoice.Clear();
            foreach (string word in words)
            {
                if (replacedWords.ContainsKey(word))
                {
                    textBoxChoice.Text += replacedWords[word] + " ";
                }
                else textBoxChoice.Text += word + " ";
            }

        }


        private void Inline_paraphrasing_Load(object sender, EventArgs e)
        {

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            textBox_output1.Text = textBox_output2.Text = textBox_output3.Text = textBox_output4.Text = textBox_output5.Text = "";

        }

        private void button_saveResults_Click(object sender, EventArgs e)
        {

        }
    }
}
