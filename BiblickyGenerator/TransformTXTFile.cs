using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblickyGenerator
{
    /// <summary>
    /// This class transforms a simple TXT file for Word2Vec so every potentialy 
    /// dangerous symbol gets blanks around it
    /// 
    /// </summary>
    public class TransformTXTFile
    {
        private static char[] bannedChars = { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_',
                               '-', '.', ',','/','\\','\'','"',';','}',']','{','[','|','?','>','<'
                               ,'+','=',':','“', '„' };

        //suitable for czech and english chars
        private static char[] smallCzechChars = { 'a','á','b','c','č','d','ď','e','é',
                                                  'ě','f','g','h','i','í','j','k','l',
                                                  'm','n','ň','o','ó','p','q','r','ř',
                                                  's','š','t','ť','u','ú','ů','v','w','x',
                                                  'y','ý','z','ž' };

        private static char[] bigCzechChars = { 'A','Á','B','C','Č','D','Ď','E','É','Ě',
                                                'F','G','H','I','Í','J','K','L','M','N',
                                                'Ň','O','Ó','P','Q','R','Ř','S','Š','T',
                                                'Ť','U','Ú','Ů','V','W','X','Y','Ý','Z','Ž'};

        private static char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        private static Dictionary<String, bool> dictThisWordIsName = new Dictionary<string, bool>();


        private static string ModifyDangerousSymbols(char oneChar)
        {
            if (bannedChars.Contains(oneChar)) return " " + oneChar + " ";
            else return "" + oneChar;
        }
        /// <summary>
        /// This method takes string and every symbol not included in Czech alphabet
        ///    will be wrapped by spaces
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string TransformString(string line)
        {
            if (line.Length == 0) return "";
            StringBuilder sb = new StringBuilder(line[0]);
            for (int i = 0; i < line.Length; i++)
            {
                if (bannedChars.Contains(line[i]))
                {
                    sb.Append(" " + line[i] + " ");
                }
                else sb.Append(line[i]);
            }
            return sb.ToString();

        }

        /// <summary>
        /// Inverse function to the TransformString(string line)
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string TransformStringBack(string line)
        {
            if (line.Length == 0) return "";
            StringBuilder sb = new StringBuilder(line[0]);
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (bannedChars.Contains(line[i + 1]))
                {
                    sb.Append(line[i + 1]);
                    i++;
                    i++;
                }
                else
                {
                    sb.Append(line[i]);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// The file will be transformed:
        ///     all letters except names toLower
        ///     all interpunction is wrapped by spaces   
        /// 
        /// </summary>
        /// <param name="file"></param>
        public static void TransformFile(string file)
        {


            string basenameOfFileWithoutExtensions = Path.GetFileNameWithoutExtension(file);
            string basenameOfFile = basenameOfFileWithoutExtensions + ".txt";
            dictThisWordIsName.Clear();
            FillDictionaryOfNames(file);


            string result = FileManager.GetSpecifiedDirectory("SourceTXTFiles") +FileManager.sep + basenameOfFileWithoutExtensions + ".txt";
            if (File.Exists(result))
            {
                int i = 1;
                while (File.Exists(result))
                {
                    result = FileManager.GetSpecifiedDirectory("SourceTXTFiles") + FileManager.sep + basenameOfFileWithoutExtensions + "_" + i + "_.txt";
                    i++;
                }

            }

            try
            {

                using (StreamReader MyStreamReader = new StreamReader(file))
                {
                    using (StreamWriter MyStreamWriter = new StreamWriter(result))
                    {

                        char oneChar;
                        StringBuilder sb = new StringBuilder();

                        while (MyStreamReader.Peek() >= 0)
                        {

                            oneChar = (char)MyStreamReader.Read();
                            if (bigCzechChars.Contains(oneChar) ||
                                       smallCzechChars.Contains(oneChar) ||
                                               numbers.Contains(oneChar))
                            {
                                sb.Append(oneChar);
                            }
                            else
                            {
                                string word = sb.ToString();
                                sb.Clear();
                                if (word.Length == 0)
                                {
                                    MyStreamWriter.Write(ModifyDangerousSymbols(oneChar));
                                }
                                else if (word[0] <= 'Z' && word[0] >= 'A')
                                {
                                    if (dictThisWordIsName.ContainsKey(word.ToLower()) && dictThisWordIsName[word.ToLower()])
                                    {
                                        MyStreamWriter.Write(word);
                                    }
                                    else
                                    {
                                        MyStreamWriter.Write(word.ToLower());
                                    }
                                }
                                else
                                {
                                    MyStreamWriter.Write(word);
                                }
                                MyStreamWriter.Write(ModifyDangerousSymbols(oneChar));

                            }

                        }

                    }
                }

            }
            catch (System.Text.EncoderFallbackException)
            {

            }



        }

        /// <summary>
        /// This method tries to detect names and all non-names words 
        ///    transform to lower cases
        /// </summary>
        /// <param name="file"></param>
        private static void FillDictionaryOfNames(string file)
        {
            using (StreamReader str = new StreamReader(file))
            {
                StringBuilder sb = new StringBuilder();
                while (str.Peek() >= 0)
                {
                    char c = (char)str.Read();
                    if (c.Equals(' ') || c.Equals('\t') || c.Equals('\n') || c.Equals('\r'))
                    {
                        string word = sb.ToString();
                        sb.Clear();
                        if (word.Length == 0 || !bigCzechChars.Contains(word[0])) continue;
                        else
                        {
                            if (!dictThisWordIsName.ContainsKey(word.ToLower()))
                                dictThisWordIsName.Add(word.ToLower(), true);
                        }
                    }
                    else sb.Append(c);
                }
            }

            using (StreamReader str = new StreamReader(file))
            {
                StringBuilder sb = new StringBuilder();
                while (str.Peek() >= 0)
                {
                    char c = (char)str.Read();
                    if (c.Equals(' ') || c.Equals('\t') || c.Equals('\n') || c.Equals('\r'))
                    {
                        string word = sb.ToString();
                        sb.Clear();
                        if (word.Length == 0 || bigCzechChars.Contains(word[0])) continue;
                        else
                        {
                            if (dictThisWordIsName.ContainsKey(word))
                            {
                                dictThisWordIsName[word] = false;
                            }
                        }
                    }
                    else sb.Append(c);
                }
            }
        }

    }
}

