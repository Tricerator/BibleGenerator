using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Net;
namespace BiblickyGenerator
{

    struct Window
    {
        private TextBox txtb;
        public TextBox Txtb { get => txtb; set => txtb = value; }

        private string input;
        public string Input { get => input; set => input = value; }

        private string output;
        public string Output { get => output; set => output = value; }
        

        private string model;
        public string Model { get => model; set => model = value; }

        private bool usedMorphodita;
        public bool UsedMorphodita { get => usedMorphodita; set => usedMorphodita = value; }

        public void clear()
        {
            txtb.Text = "";
            output = "";
        }
    }
    public partial class Inline_paraphrasing : Form
    {
        private Window[] arrayOfWindows;
        private Queue<Window> queueOfUsedWindows;

       
        private string ModelDir = Environment.CurrentDirectory + "\\..\\..\\Models";
        public Inline_paraphrasing()
        {
            InitializeComponent();
            foreach (var dir in Directory.GetFiles(ModelDir))
            {

                listBox_models.Items.Add(Path.GetFileNameWithoutExtension(dir));
            }

        }

        private void button_paraphrase_Click(object sender, EventArgs e)
        {
            Window wndw = new Window();

            if (queueOfUsedWindows.Count >= 5)
            {
                string message = "Buď uložte výsledky do souboru, nebo je resetujte";
                string title = "Chyba";
                MessageBox.Show(message, title);
                return;
            }
            else if (listBox_models.SelectedIndex >= 0)
            {
                wndw = arrayOfWindows[queueOfUsedWindows.Count];
                queueOfUsedWindows.Enqueue(wndw);
                try
                {
                    if (checkBox_useMorphoDiTa.Checked == true) wndw.UsedMorphodita = true;
                    else                       wndw.UsedMorphodita = false;
                    ParaphraseText(wndw);
                    
                }
                catch (Exception ex)
                {
                    if (ex is WebException
                        || ex is System.Net.Http.HttpRequestException
                        || ex is System.Net.Sockets.SocketException)
                    {


                        wndw.Txtb.Text = "Morphodita se nemohla spojit se serverem. Zkuste to za chvíli, " +
                            "nebo zvolte moznost bez MorphoDiTy"; ;
                    }else throw;
                }
            }

        }

        private void ParaphraseText(Window window)
        {
            window.Model = ModelDir + "\\" + listBox_models.SelectedItem.ToString() + ".txt";
            
            window.Input = textBox_input.Text;

            string normalizeString = TransformTXTFile.TransformString(window.Input);
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
            Dictionary<string, string> replacedWords = Word2Vec.UseWord2Vec(window.Model, rightWords.ToArray());

            window.clear();

            if (window.UsedMorphodita)
            {
                window.Output = MorphoDiTa.useMorphoDiTa(window.Input, replacedWords);
            }
            else
            {
                foreach (string word in words)
                {
                    if (replacedWords.ContainsKey(word))
                    {
                        window.Output += replacedWords[word] + " ";
                    }
                    else window.Output += word + " ";
                }

            }
            window.Txtb.Text = window.Output;

        }


        private void Inline_paraphrasing_Load(object sender, EventArgs e)
        {
            reset();            
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
            if (queueOfUsedWindows != null)
            {
                foreach (var window in queueOfUsedWindows)
                {
                    var wndw = window;
                    wndw.Output = "";
                    wndw.Input = "";
                    wndw.UsedMorphodita = false;
                    wndw.Model = "";
                    wndw.Txtb.Text = "";
                }
            }
        
            textBox_input.Text = "";
            checkBox_useMorphoDiTa.Checked = false;
            listBox_models.ClearSelected();


            Window w1 = new Window();
            w1.Txtb = textBox_output1;
            Window w2 = new Window();
            w2.Txtb = textBox_output2;
            Window w3 = new Window();
            w3.Txtb = textBox_output3;
            Window w4 = new Window();
            w4.Txtb = textBox_output4;
            Window w5 = new Window();
            w5.Txtb = textBox_output5;
            arrayOfWindows = new Window[] { w1, w2, w3, w4, w5 };
            queueOfUsedWindows = new Queue<Window>();

        }

        private void button_saveResults_Click(object sender, EventArgs e)
        {
            DateTime now = new DateTime();
            
            string pathOfNewFile = ModelDir + "\\..\\Results\\" + now.ToString().Replace(" ","_").Replace("/","-") + ".txt";
            using (var sw = new StreamWriter(pathOfNewFile))
            {
                for (int i = 0; i < queueOfUsedWindows.Count; i++)
                {
                    Window w = queueOfUsedWindows.Dequeue();
                    sw.WriteLine("Model: " + w.Model);
                    sw.WriteLine("Input: " + w.Input);
                    sw.WriteLine("Output: " + w.Output);
                    if (w.UsedMorphodita) sw.WriteLine("MorphoDiTa: pouzita");
                    else sw.WriteLine("MorphoDiTa: nepouzita");

                }

            }

        }
    }
}
