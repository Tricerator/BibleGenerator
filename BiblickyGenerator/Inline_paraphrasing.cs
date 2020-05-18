using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace BiblickyGenerator
{
    
    public partial class Inline_paraphrasing : Form
    {
        private static Window w1 = new Window();
        private static Window w2 = new Window();
        private static Window w3 = new Window();
        private static Window w4 = new Window();
        private static Window w5 = new Window();

        private static Window[] arrayOfWindows = {w1,w2,w3,w4,w5 };
        
        //  private static Queue<Window> queueOfUsedWindows;
        private static byte numberOfUsedWindows;


        //  private string ModelDir = Environment.CurrentDirectory + "\\..\\..\\Models";
        private string ModelDir = FileManager.GetSpecifiedDirectory("Models");
        public Inline_paraphrasing()
        {
            InitializeComponent();
            foreach (var dir in Directory.GetFiles(ModelDir))
            {
                listBox_models.Items.Add(Path.GetFileNameWithoutExtension(dir));
            }
            
            numberOfUsedWindows = 0;

        }


        private void Button_paraphrase_Click(object sender, EventArgs e)
        {
           
            if (numberOfUsedWindows >= 5)
            {
                string message = "Buď uložte výsledky do souboru, nebo je resetujte";
                string title = "Chyba";
                MessageBox.Show(message, title);
                return;
            }
            else if (listBox_models.SelectedIndex >= 0)
            {
                PrintWaiting();
                Window wndw = arrayOfWindows[numberOfUsedWindows];
       //         try
         //       {
                    if (checkBox_useMorphoDiTa.Checked == true) wndw.UsedMorphodita = true;
                    else                       wndw.UsedMorphodita = false;
                    
                    ParaphraseText();

   /*             }
                catch (Exception ex)
                {
                    if (ex is WebException
                        || ex is System.Net.Http.HttpRequestException
                        || ex is System.Net.Sockets.SocketException)
                    {


                        string message = "Morphodita se nemohla spojit se serverem. Zkuste to za chvíli, " +
                            "nebo zvolte moznost bez MorphoDiTy";
                        MessageBox.Show(message);
 //                   }else throw;*/
               // }
                
            }

        }

        private void ParaphraseText()
        {
            Window window = arrayOfWindows[numberOfUsedWindows];
            window.Model = ModelDir + FileManager.sep + listBox_models.SelectedItem.ToString() + ".txt";
            
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

         //   window.clear();

            if (window.UsedMorphodita)
            {
                window.Output = MorphoDiTa.UseMorphoDiTa(window.Input, replacedWords);
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
            if (window.UsedMorphodita)
            {
                window.Txtb.Text = TransformTXTFile.TransformStringBack(window.Output);
                window.Output = window.Txtb.Text;
            }
            else
            {
                window.Txtb.Text = TransformTXTFile.TransformStringBack(window.Output);
                window.Output = window.Txtb.Text;
            }
           
            numberOfUsedWindows++;
            textBox_waiting.Text = "Text parafrázován";
        }


        private void Inline_paraphrasing_Load(object sender, EventArgs e)
        {
            w1.Txtb = textBox_output1;
            w2.Txtb = textBox_output2;
            w3.Txtb = textBox_output3;
            w4.Txtb = textBox_output4;
            w5.Txtb = textBox_output5;

            //  reset();            
        }

    private void Button_back_Click(object sender, EventArgs e)
        {
            Close();
        }

     
        private void Button_reset_Click(object sender, EventArgs e)
        {
            
            Reset();
        }

        private void Reset()
        {
            textBox_waiting.Text = "";
            numberOfUsedWindows = 0;
            foreach (var window in arrayOfWindows)
            {
                    var wndw = window;
                    wndw.Output = "";
                    wndw.Input = "";
                    wndw.UsedMorphodita = false;
                    wndw.Model = "";
                    wndw.Txtb.Text = "";
            }
            textBox_input.Text = "";
            checkBox_useMorphoDiTa.Checked = false;
            listBox_models.ClearSelected();

            /*
            
            */
        }

        private void Button_saveResults_Click(object sender, EventArgs e)
        {


            var myUniqueFileName = FileManager.GetSpecifiedDirectory("Results") + FileManager.sep + $@"{DateTime.Now.Ticks}.txt";
            using (var sw = new StreamWriter(myUniqueFileName))
            {
                for (int i = 0; i < numberOfUsedWindows; i++)
                {
                    Window w = arrayOfWindows[i];
                    if (w.Txtb.Text == "") break;
                    sw.WriteLine("Model: " + Path.GetFileName(w.Model));
                    sw.WriteLine("Input: " + w.Input);
                    if (w.UsedMorphodita)
                    {
                        sw.WriteLine("Output: " + w.Output);
                        sw.WriteLine("MorphoDiTa: pouzita");
                    }
                    else
                    {
                        sw.WriteLine("Output: " + w.Output);
                        sw.WriteLine("MorphoDiTa: nepouzita");
                    }
                    sw.WriteLine();
                   

                }

            }
            Reset();

        }

        private void PrintWaiting()
        {
            textBox_waiting.Text = "probíhá parafrázování, pro velké modely je třeba strpení";
        }
    }
}
