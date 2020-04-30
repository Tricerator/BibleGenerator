using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BiblickyGenerator
{
    public class MorphoDiTa
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="wordsForReplacement">
        ///     This param is a Dictionary that conatins word and the word
        ///         thhat was chosen for exchange by Word2Vec    
        /// </param>
        /// <returns></returns>
        public static string useMorphoDiTa(string sentence, Dictionary<string,string> wordsForReplacement)
        {

            StringBuilder sb = new StringBuilder();
            string[] words = sentence.Split(' ');
            foreach(string word in words)
            {
                if (wordsForReplacement.ContainsKey(word))
                {
                    string 
                }
                else
                {
                    sb.Append(word + " ");
                }

            }
            return sb.ToString().Trim();
        }







        /// <summary>
        /// This method connects with MorphoDiTa web aplication and 
        /// gets a response based on request: 
        ///         1) analyze
        ///         2) generate
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected static string getUrlAnswer(string url)
        {
               using (WebClient client = new WebClient())
                {
                    client.Encoding = UTF8Encoding.UTF8;
                    return client.DownloadString(url);
                }
           
            
        }

        private static string getResultJsonVariableFromAnalyze(string answer)
        {
            return answer.Split(new[] { "result\":" }, StringSplitOptions.None)[1].Split('"')[1];

        }


        protected static Dictionary<string,string[]> getDictionaryForSentence(string sentence)
        {
            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/analyze?data=";
            string answer = getUrlAnswer(url + sentence.Replace(" ", "%20") + "&output=vertical");
            answer = getResultJsonVariableFromAnalyze(answer);
            string[] linesOfOneWord = Regex.Split(answer, @"\\n");


            Dictionary<string, string[]> dir = new Dictionary<string, string[]>();


            foreach (var line in linesOfOneWord)
            {
                string[] words = Regex.Split(line, @"\\t");

                string key = words[0];
                List<string> possibleConfigurations = new List<string>();
                for (int i = 1; i < words.Length; i++)
                {
                    possibleConfigurations.Add(words[i]);
                }
                dir.Add(key, possibleConfigurations.ToArray());
            }

            return dir;
        }





        /// <summary>
        /// This method gets all generated forms of given word in basic form
        /// </summary>
        /// <param name="word">Needs to be in nomitative singular if it is a noun</param>
        /// <returns></returns>
        private static Dictionary<string, string[]> generateFormsOfWord(string word)
        {
            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data=" + word;

                string data = getUrlAnswer(url);
                Dictionary<string, string[]> dict = getDictionaryResult(getResultJsonOutputInGenerate(data));
                return dict;
        }
        /// <summary>
        /// This method gets JSON value result either empty 
        ///           or as triplets of words between \t 
        /// </summary>
        /// <param name="dataResults">text</param>
        /// <returns>
        /// Dictionary of triplets, where Key is unique
        ///       string of word forms such as person, singular/plural etc...
        ///       example: NNMS1-----A----
        /// </returns>
        private static Dictionary<string, string[]> getDictionaryResult(string dataResults)
        {
            Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
            if (dataResults == "\\n") return null;
            else
            {
                string[] words = Regex.Split(dataResults, @"\t");
                for (int i = 0; i < words.Length; i += 3)
                {

                    string[] values = { words[i], words[i + 1] };
                    dict.Add(words[i + 2], values);
                }
            }
            return dict;
        }

        /// <summary>
        /// This method cuts result text from MorphoDiTa web page
        /// </summary>
        /// <param name="data">data is an answer of HTTP request</param>
        /// <returns>returns just JSON variable result from generate request</returns>
        protected static string getResultJsonOutputInGenerate(string data)
        {
            //this line prevents empty inputs to shut down the app
            data += "\"\\n";
            data = data.Split(']')[1].Split(':')[1].Split('"')[1];
            data = Regex.Split(data, @"\\n")[0];
            return data;



        }

    }

}
