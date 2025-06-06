﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace BiblickyGenerator
{
    /// <summary>
    /// This class provides a chance to compare outputs from 5 different models with/without MorphoDiTa
    ///     and provides chance to save file into Results
    /// </summary>
    
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

        private string ModelDir = DirectoryManager.GetSpecifiedDirectory("Models");

        /// <summary>
        /// Sets trained models into ListBox
        /// </summary>
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

                if (checkBox_useMorphoDiTa.Checked == true)
                {
                    wndw.UsedMorphodita = true;
                    if (!CheckInternetConnection())
                    {
                        string message = "Morphodita se nemohla spojit se serverem. Zkuste to za chvíli, " +
                            "nebo zvolte možnost parafrázování bez MorphoDiTy.";
                        MessageBox.Show(message, "Problém s připojením k internetu");

                    }
                    else   SendTextToParaphrase();

                }
                else
                {
                    wndw.UsedMorphodita = false;
                    SendTextToParaphrase();

                }
            }

        }


        /// <summary>
        /// This method modifies input texts and sends it to Word2Vec with words to paraphrase
        /// </summary>

        private void SendTextToParaphrase()
        {
            Window window = arrayOfWindows[numberOfUsedWindows];
            window.Model = ModelDir + DirectoryManager.sep + listBox_models.SelectedItem.ToString() + ".txt";

            window.Input = textBox_input.Text;

            /*
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
            }*/

            window.Output = ParaphraseText.Paraphrase(window.Input,window.Model,window.UsedMorphodita);
            window.Txtb.Text = window.Output;
           
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


            var myUniqueFileName = DirectoryManager.GetSpecifiedDirectory("Results") + DirectoryManager.sep + $@"{DateTime.Now.Ticks}.txt";
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


        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void PrintWaiting()
        {
            textBox_waiting.Text = "probíhá parafrázování, pro velké modely je třeba strpení";
        }

        private void button_help_Click(object sender, EventArgs e)
        {

            string help = "Nacházíte se v módu pro parafrázování. Pokud chcete parafrázovat libovolný text, musíte mít předem"
                + " natrénovaný alespoň jeden model. Vložte váš text do bílého okna a poté vyberte model. Bez vybraného modelu nelze parafrázovat."
                + " Pokud chcete použít MorphoDiTu, musíte být připojeni k internetu. Pokud bude špatné či žádné připojení, program vás sám upozorní."
                + " pokud chcete výsledky uložit či resetovat, všechny dosavadní výsledky se smažou. Uložené výsledky najdete ve složce Results v souboru s nejvyšším číslem v názvu."
                + " Pokud budete mít pět parafrázovaných odpovědí, program vás při dalším pokusu o parafrázování zarazí a navede vás buď k uložení či resetování výsledků.";
            MessageBox.Show(help);
        }
    }
}
