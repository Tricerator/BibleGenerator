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
        public static string useMorphoDiTa(string sentence, Dictionary<string, string> wordsForReplacement)
        {
            if (wordsForReplacement.Count == 0) return sentence;
            Dictionary<string, string[]> dict = analyzeSentenceAndReturnDictionary(sentence);

            Dictionary<string, string> dictOfMorphCOmbinations = new Dictionary<string, string>();
            foreach(var selectedWord in dict.Keys)
            {
                if (wordsForReplacement.ContainsKey(selectedWord))
                {
                    dictOfMorphCOmbinations.Add(selectedWord, dict[selectedWord][1]);
                }
            }

            StringBuilder basicFormOfWOrdsRequest = new StringBuilder();
            foreach (var word in wordsForReplacement)
            {
                basicFormOfWOrdsRequest.Append(word.Value + "%20");
            }

            var basicForms = analyzeSentenceAndReturnDictionary(basicFormOfWOrdsRequest.ToString());
            string[] keys = basicForms.Keys.ToArray(); 
            StringBuilder sb = new StringBuilder();
            foreach (string line in basicForms.Keys)
            {
                sb.Append(basicForms[line][0] + "%0A");
            }

            var DictionaryOfDictionariesOfGeneratedWords = generateFormsOfWord(sb.ToString(),keys);



            StringBuilder resultSentence = new StringBuilder();
            string[] words = sentence.Split(' ');
            foreach(string word in words)
            {
                if (wordsForReplacement.ContainsKey(word))
                {
                    string resultWord = wordsForReplacement[word];
                    string resultWordMorphology = dictOfMorphCOmbinations[word];
                    string result = getMorphoDiTaWord(resultWord,DictionaryOfDictionariesOfGeneratedWords,resultWordMorphology);
                    resultSentence.Append(result + " ");
                }
                else
                {
                    resultSentence.Append(word + " ");
                }

            }
            return resultSentence.ToString().Trim();
        }


        protected static string getMorphoDiTaWord(string word, Dictionary<string,Dictionary<string,string[]>> dict, string morphCombination)
        {
            if (!dict.ContainsKey(word)) return null;
            else
            {
                Dictionary<string, string[]> line = dict[word];

                foreach (string key in line.Keys)
                {
                    for (int i = 0; i < key.Length; i++)
                    {
                        if (((i>= 0 && i < 2) || (i == 4)) && key[i] != morphCombination[i]) break;
                    }
                return line[key][0];
            }
            return null;
            }
        }




        /// <summary>
        /// This method connects with MorphoDiTa web aplication and 
        /// gets a response based on request: 
        ///         1) analyze(tag)
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

        protected static string getResultJsonVariableFromTagging(string answer)
        {
            if (answer == "") return "";
            try
            {
                return answer.Split(new[] { "result\":" }, StringSplitOptions.None)[1].Split('"')[1];
            }
            catch (IndexOutOfRangeException)
            {
                return "";
            }

        }

        /// <summary>
        /// This method creates Dictionary, where:
        ///     key = original word
        ///     values = array of strings
        ///         value[0] = basic form of word
        ///         value[1] = morphological notation
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        protected static Dictionary<string,string[]> analyzeSentenceAndReturnDictionary(string sentence)
        {
            if (sentence == "") return null;
            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/tag?data=" + sentence.Replace(" ","%20");
            string answer = getUrlAnswer(url  + "&output=vertical");
            answer = getResultJsonVariableFromTagging(answer);
            string[] linesOfOneWord = Regex.Split(answer, @"\\n");


            Dictionary<string, string[]> dir = new Dictionary<string, string[]>();


            foreach (var line in linesOfOneWord)
            {   if (line == "") continue;
                string[] words = Regex.Split(line, @"\\t");

                string key = words[0].ToLower();
               
                if (dir.ContainsKey(key)) continue;
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
        /// <param name="coupleOfWords">Needs to be in nomitative singular if it is a noun</param>
        /// <returns></returns>
        protected static Dictionary<string, Dictionary<string, string[]>> generateFormsOfWord(string coupleOfWords, string[] keys)
        {
            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data=" + coupleOfWords;

            string data = getUrlAnswer(url);
            string results = getResultJsonOutputInGenerate(data);
            var list = getDictionariesFromGeneratedRequest(coupleOfWords, results, keys);
            return list;
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
        private static Dictionary<string,Dictionary<string, string[]>> getDictionariesFromGeneratedRequest(string coupleOfWords, string dataResults, string[] keys)
        {

            if (dataResults == "\\n") return null;
            else
            {
                Dictionary<string, Dictionary<string, string[]>> DictionaryOfDictionaries = new Dictionary<string, Dictionary<string, string[]>>();
                string[] lines = Regex.Split(dataResults, @"\n");
                string[] originalWords = Regex.Split(coupleOfWords, "%20");
                for (int k  = 0; k < keys.Length; k++)
                {
                    foreach (var line in lines)
                    {
                        if (line.Length == 0) continue;
                        Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
                        string[] words = Regex.Split(line, @"\\t");
                        for (int i = 0; i < words.Length; i += 3)
                        {
                            string[] values = { words[i], words[i + 1] };
                            dict.Add(words[i + 2], values);
                        }
                        DictionaryOfDictionaries.Add(keys[k], dict);
                    }
                }
                return DictionaryOfDictionaries;
            }
        }

        /// <summary>
        /// This method cuts result text from MorphoDiTa web page
        /// </summary>
        /// <param name="data">data is an answer of HTTP request</param>
        /// <returns>returns just JSON variable result from generate request</returns>
        protected static string getResultJsonOutputInGenerate(string data)
        {
            try
            {
                //this line prevents empty inputs to shut down the app
                data += "\"\\n";
                data = data.Split(']')[1];
                //    ",\n \"result\": \"
                data = Regex.Split(data, "\"result\": \\\"")[1];

                data = Regex.Split(data, @"\\n")[0];
                return data;
            }
            catch (IndexOutOfRangeException)
            {
                return "";
            }
           
        }

      //  protected string getDictionaryOfgeneratedWords

    }

}
