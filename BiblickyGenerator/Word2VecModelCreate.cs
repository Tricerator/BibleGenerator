using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BiblickyGenerator
{
        /// <summary>
        /// This class creates actual model for Word2Vec 
        /// </summary>

    public partial class Word2VecModelCreate : Form
    {

        private long NumberOfOneFile;

        private int NumberOfIterations;
        private int VectorLength;
        private int MinCountWords;



        private string DirectoryName;
        private SortedDictionary<string,long[]> DictFilesInModel;
        private long FinalLengthOFModel;
        public Word2VecModelCreate()
        {
            InitializeComponent();
            resetAll();
            DictFilesInModel = new SortedDictionary<string, long[]>();
            FinalLengthOFModel = 0;
            MinCountWords = 0;
            VectorLength = 0;
            NumberOfIterations = 0;
            DirectoryName = "";
        }

        public void setNumberOfOneFile(long num)
        {
            this.NumberOfOneFile = num;
        }

        private void Word2VecModelCreate_Load(object sender, EventArgs e)
        {
            LoadFiles();
        }


        /// <summary>
        /// This methods loads files into ListBox
        /// </summary>
        private void LoadFiles()
        {
            
            string path = FileManager.getSpecifiedDirectory("SourceTXTFiles");
            string[] files = Directory.GetFiles(path);
            if (files.Length == 0)
            {
                textBox_Error.Text = "Je třeba nejdříve upravit soubor .txt.";
            }
            else
            {
                DirectoryName = Path.GetDirectoryName(files[0]);
                for (int i = 0; i < files.Length; i++)
                {
                    listBox_modelFiles.Items.Add(Path.GetFileNameWithoutExtension(files[i]));
                }
            }
            

        }
       
       /// <summary>
       ///  If all params are set correctly, this model starts 
       ///    Word2Vec model create
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button_buildModel_Click(object sender, EventArgs e)
        {
            string answer = checkTheForm();
            if (answer == "everything is OK")
            {
                textBox_fileName.Text = "";
                string file = mergeAllFiles();
                Word2Vec.trainModel(file, VectorLength, MinCountWords, NumberOfIterations);
                deleteFile(file);
                textBox_Error.Text = "Model " + Path.GetFileNameWithoutExtension(file) + " úspěšně vytvořen";
            }
            else textBox_Error.Text = answer;
        }


        private string checkTheForm()
        {
            
            if (!int.TryParse(textBox_vectorSize.Text, out VectorLength)) return "Délka vektoru musí být celé číslo";
            else if (!int.TryParse(textBox_minimumAmountOfWords.Text, out MinCountWords)) return "Minimální počet slov musí být celé číslo";
            else if (!int.TryParse(textBox_numberOfIterations.Text, out NumberOfIterations)) return "Počet iterací musí být celé číslo";

            else if (textBox_fileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                return "Jméno modelu není validní";
            }
            else if (FinalLengthOFModel <= 0) return "Nelze vyrobit prázdný model";
        
            return "everything is OK";
        }


        /// <summary>
        /// This method merges all files multiplied by chosen constant to a single file
        ///         which will be saved in TMP file. 
        /// </summary>
        /// <returns></returns>
        private string mergeAllFiles()
        {

            string tmpFile = FileManager.getSpecifiedDirectory("Temp") +"\\" + textBox_fileName.Text + ".txt";

            foreach (var item in DictFilesInModel)
            {
                string source = FileManager.getSpecifiedDirectory("SourceTXTFiles") + "\\" + item.Key.ToString() + ".txt";
                for (int i = 0; i < item.Value[0]; i++)
                {
                    
                    using (Stream input = File.OpenRead(source))
                    using (Stream output = new FileStream(tmpFile, FileMode.Append,
                                                          FileAccess.Write, FileShare.None))
                    {
                        input.CopyTo(output);
                    }
                }

            }

            return tmpFile;
        }



        private void deleteFile(string file)
        {
            File.Delete(file);
        }
        
       
        private void resetAll()
        {

            textBox_vectorSize.Text = "100";
            textBox_Error.Text = "";
            textBox_minimumAmountOfWords.Text = "5";
            textBox_numberOfIterations.Text = "5";
            textBox_absoluteSize.Text = "0";
            listBox_finalFiles.Items.Clear();
            listBox_modelFiles.Items.Clear();
        }

        private void button_BackToMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
         
        private void button_putFileRight_Click(object sender, EventArgs e)
        {
            if(listBox_modelFiles.SelectedIndex >= 0) { 
            string selectedFile = listBox_modelFiles.SelectedItem.ToString();
            
            if (listBox_modelFiles.SelectedItems.Count != 1) textBox_Error.Text = "Je třeba vybrat jeden zdrojový soubor";
            else if(DictFilesInModel.ContainsKey(selectedFile)){
                textBox_Error.Text = "Tento soubor už je vybrán";
            }
            else 
            {   
                string file = DirectoryName + "//" + listBox_modelFiles.SelectedItem + ".txt";

                

                ReadCount rc = new ReadCount(this);
                rc.ShowDialog();
                                
                long[] arrayOfParams = { NumberOfOneFile, new FileInfo(file).Length};
                DictFilesInModel.Add(listBox_modelFiles.SelectedItem.ToString(),arrayOfParams);
                FinalLengthOFModel += new FileInfo(file).Length * NumberOfOneFile;

                fillTheForm();


                }
            }
        }

        /// <summary>
        /// For every insertion of new file this method recount size and percentage
        ///    of files
        /// </summary>
        private void fillTheForm()
        {
            listBox_NumberOfRepetition.Items.Clear();
            listBox_finalFiles.Items.Clear();
            listBox_sizeFile.Items.Clear();
            listBox_percentage.Items.Clear();

            foreach (var item in DictFilesInModel)
            {
                listBox_finalFiles.Items.Add(item.Key);
                listBox_NumberOfRepetition.Items.Add(item.Value[0]);
                listBox_sizeFile.Items.Add(countFileSize(item.Value[1] * item.Value[0]));
                listBox_percentage.Items.Add(Math.Round(100 * (double)(item.Value[1] * item.Value[0]) / FinalLengthOFModel, 2));
            }
            textBox_absoluteSize.Text = countFileSize( FinalLengthOFModel);
        }

        /// <summary>
        /// This method gives a user - readable output of file size
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private string countFileSize(double len)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.##} " + sizes[order], len);
        }

        private void listBox_modelFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
      
        
        /// <summary>
        /// This method gives a chance to roll back our choice of file with number
        ///     of repetition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_choiceBack_Click(object sender, EventArgs e)
        {
            if(listBox_finalFiles.SelectedIndex >= 0) { 
            string item = listBox_finalFiles.SelectedItem.ToString();
            long num = DictFilesInModel[item][0];
            long size = DictFilesInModel[item][1];
            FinalLengthOFModel -= (size * num);
            DictFilesInModel.Remove(item);

            fillTheForm();

            }

        }

        private void listBox_percentage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}









