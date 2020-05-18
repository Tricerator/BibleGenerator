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
        /// No.	 Name 	Description
        ///1 	 POS Part of Speech
        ///2 	 SUBPOS Detailed Part of Speech
        ///3 	 GENDER Gender
        ///4 	 NUMBER Number
        ///5 	 CASE Case
        ///6 	 POSSGENDER Possessor's Gender
        ///7 	 POSSNUMBER Possessor's Number
        ///8 	 PERSON Person
        ///9 	 TENSE Tense
        ///10 	 GRADE Degree of comparison
        ///11 	 NEGATION Negation
        ///12 	 VOICE Voice
        ///13 	 RESERVE1 Unused
        ///14 	 RESERVE2 Unused
        ///15 	 VAR Variant, Style, Register, Special Usage

        /// </summary>

        private static readonly SortedSet<int> indexesNoun = new SortedSet<int>{ 1, 2, 4 };
        private static readonly SortedSet<int> indexesAdjective = new SortedSet<int> { 1, 2, 3, 4};
        private static readonly SortedSet<int> indexesPronoun = new SortedSet<int> { 1, 2, 3, 4};
        private static readonly SortedSet<int> indexesNumeral = new SortedSet<int> { 1, 2, 3, 4 };

        private static readonly SortedSet<int> indexesVerb = new SortedSet<int> { 1, 2, 3, 4, 8, 9 };

        private static readonly SortedSet<int> indexesAdverb = new SortedSet<int> { 1, 2, 3, 4 };
        private static readonly SortedSet<int> indexesPreposition = new SortedSet<int> { 1, 2, 3, 4};
        private static readonly SortedSet<int> indexesConjunction = new SortedSet<int> { 1, 2, 3, 4 };

        private static readonly SortedSet<int> indexesRest = new SortedSet<int> { 1, 2, 3, 4 };






        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="wordsForReplacement">
        ///     This param is a Dictionary that conatins word and the word
        ///         thhat was chosen for exchange by Word2Vec    
        /// </param>
        /// <returns></returns>
        public static string UseMorphoDiTa(string sentence, Dictionary<string, string> wordsForReplacement)
        {
            if (wordsForReplacement.Count == 0) return sentence;
            Dictionary<string, string[]> dict = AnalyzeSentenceAndReturnDictionary(sentence);

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
            // Az potud vse v pohode...

            var basicForms = AnalyzeSentenceAndReturnDictionary(basicFormOfWOrdsRequest.ToString());
            string[] keys = basicForms.Keys.ToArray(); 
            StringBuilder sb = new StringBuilder();
            foreach (string line in basicForms.Keys)
            { 
                sb.Append(basicForms[line][0] + "%0A");
            }
// potud dobry
            var DictionaryOfDictionariesOfGeneratedWords = GenerateFormsOfWord(sb.ToString(),keys);

            Dictionary<string,string> basicFormOfGeneratedWord = new Dictionary<string, string>();
            foreach(string line in basicForms.Keys)
            {
                basicFormOfGeneratedWord.Add(line, basicForms[line][0]);
            }



            StringBuilder resultSentence = new StringBuilder();
            string[] words = TransformTXTFile.TransformString(sentence).Split(' ');
            foreach(string word in words)
            {
                if (wordsForReplacement.ContainsKey(word.ToLower()))
                {
                    string resultWord = wordsForReplacement[word];
                    string resultWordMorphology = dictOfMorphCOmbinations[word];
                    //send normalize form

                    string result = GetMorphoDiTaWord(basicFormOfGeneratedWord[resultWord],DictionaryOfDictionariesOfGeneratedWords,resultWordMorphology);
                    if (result == null) resultSentence.Append(word + " ");
                    else    resultSentence.Append(result + " ");
                }
                else
                {
                    resultSentence.Append(word + " ");
                }

            }
            return resultSentence.ToString().Trim();
        }

        /// <summary>
        /// This method gets original word, the dictionary of generated words and original morphological combination
        /// 
        /// In this method I decide what to reeplece by what and what are the morphological combinations I want to be 
        ///    the same
        /// </summary>
        /// <param name="word"></param>
        /// <param name="dict"></param>
        /// <param name="morphCombination"></param>
        /// <returns></returns>
        protected static string GetMorphoDiTaWord(string word, Dictionary<string,Dictionary<string,string[]>> dict, string morphCombination)
        {
            if (!dict.ContainsKey(word)) return null;
            else
            {
                Dictionary<string, string[]> line = dict[word];
                List<string>[] arrayOfLists = new List<string>[16];
                for(int i = 0; i < arrayOfLists.Length; i++)
                {
                    arrayOfLists[i] = new List<string>();
                }

                foreach (string key in line.Keys)
                {
                    int numOfSameChars = 0;
                    if ((key[0] != morphCombination[0]) || (key[1] != morphCombination[1])) continue;
                    else
                    {
                        for(int i = 0; i < key.Length; i++)
                        {
                            if (key[i] == morphCombination[i]) numOfSameChars++;
                        }
                        arrayOfLists[numOfSameChars].Add(key);
                    }
                }
                for(int i = 15; i > 0; i--)
                {
                    if (arrayOfLists[i].Count == 0) continue;
                    if (arrayOfLists[i].Count >= 1) return line[arrayOfLists[i][0]][0];
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
        protected static string GetUrlAnswer(string url)
        {
               using (WebClient client = new WebClient())
                {
                    client.Encoding = UTF8Encoding.UTF8;
                    return client.DownloadString(url);
                }
                        
        }
        /// <summary>
        /// Method cuts the JSON output
        /// </summary>
        /// <param name="answer"></param>
        /// <returns>Tagged sentence</returns>
        protected static string GetResultJsonVariableFromTagging(string answer)
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
        protected static Dictionary<string,string[]> AnalyzeSentenceAndReturnDictionary(string sentence)
        {
            if (sentence == "") return null;
            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/tag?data=" + sentence.Replace(" ","%20");
            string answer = GetUrlAnswer(url  + "&output=vertical");
            answer = GetResultJsonVariableFromTagging(answer);
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
        protected static Dictionary<string, Dictionary<string, string[]>> GenerateFormsOfWord(string coupleOfWords, string[] keys)
        {
            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data=" + coupleOfWords;

            string data = GetUrlAnswer(url);
            Dictionary<string,string> results = GetResultJsonOutputInGenerate(data);
            var list = GetDictionariesFromGeneratedRequest(coupleOfWords, results, keys);
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
        private static Dictionary<string,Dictionary<string, string[]>> GetDictionariesFromGeneratedRequest(
                            string coupleOfWords, Dictionary<string, string> dataResults, string[] keys)
        {

            if (dataResults == null ) return null;
            else
            {
                Dictionary<string, Dictionary<string, string[]>> DictionaryOfDictionaries = new Dictionary
                                                                            <string, Dictionary<string, string[]>>();
                string[] lines = dataResults.Keys.ToArray();
                string[] originalWords = Regex.Split(coupleOfWords, "%0A");
                foreach (string key in dataResults.Keys)
                {
                  
                        if (dataResults[key] == "") continue;
                    Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
                        string[] words = Regex.Split(dataResults[key], @"\\t");
                        for (int i = 0; i < words.Length; i += 3)
                        {
                            string[] values = { words[i], words[i + 1] };
                            if(!dict.ContainsKey(words[i+2])) dict.Add(words[i + 2], values);
                        }
                        DictionaryOfDictionaries.Add(key, dict);
                   
                }
                return DictionaryOfDictionaries;
            }
        }

        /// <summary>
        /// This method cuts result text from MorphoDiTa web page
        /// </summary>
        /// <param name="data">data is an answer of HTTP request</param>
        /// <returns>returns just JSON variable result from generate request</returns>
        protected static Dictionary<string,string> GetResultJsonOutputInGenerate(string data)
        {
            try
            {
                //this line prevents empty inputs to shut down the app
                data += "\"\\n";
                data = data.Split(']')[1];
                //    ",\n \"result\": \"
                data = Regex.Split(data, "\"result\": \\\"")[1];
                string[] linesOfData = Regex.Split(data, @"\\n");
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach(var line in linesOfData)
                {
                    if (line == "" || !line.Contains("\\t")) continue;
                    string key = Regex.Split(line, @"\\t")[1];
                    result.Add(key, line);
                }
              //  data = Regex.Split(data, @"\\n")[0];
                return result;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
           
        }

      //  protected string getDictionaryOfgeneratedWords

    }

}


















/*
                    char s = key[0];
                    bool correct = true;
                    switch (s)
                    {
                        case 'N':
                            for (int i = 0; i < key.Length; i++)
                            {
                                if ((indexesNoun.Contains(i))   && (key[i] != morphCombination[i]))
                                {
                                    correct = false;
                                    break;
                                }
                            }
                            if (correct)
                            {
                                return line[key][0];
                            }
                            else
                            {
                                correct = true;
                                continue;
                            }

                        case 'A':
                            for (int i = 0; i < key.Length; i++)
                            {
                                if ((indexesAdjective.Contains(i)) && (key[i] != morphCombination[i])) continue;
                                {
                                    correct = false;
                                    break;
                                }
                            }
                            if (correct) return line[key][0];
                            else
                            {
                                correct = true;
                                continue;
                            }
                        case 'C':
                            for (int i = 0; i < key.Length; i++)
                            {
                                if ((indexesNumeral.Contains(i)) && (key[i] != morphCombination[i])) continue;
                                {
                                    correct = false;
                                    break;
                                }
                            }
                            if (correct) return line[key][0];
                            else
                            {
                                correct = true;
                                continue;
                            }
                        case 'D':
                            for (int i = 0; i < key.Length; i++)
                            {
                                if ((indexesAdverb.Contains(i)) && (key[i] != morphCombination[i])) continue;
                                {
                                    correct = false;
                                    break;
                                }
                            }
                            if (correct) return line[key][0];
                            else
                            {
                                correct = true;
                                continue;
                            }
                        case 'P':
                            for (int i = 0; i < key.Length; i++)
                            {
                                if ((indexesPronoun.Contains(i)) && (key[i] != morphCombination[i])) continue;
                                {
                                    correct = false;
                                    break;
                                }
                            }
                            if (correct) return line[key][0];
                            else
                            {
                                correct = true;
                                continue;
                            }
                        case 'R':
                            for (int i = 0; i < key.Length; i++)
                            {
                                if ((indexesPreposition.Contains(i)) && (key[i] != morphCombination[i])) continue;
                                {
                                    correct = false;
                                    break;
                                }
                            }
                            if (correct) return line[key][0];
                            else
                            {
                                correct = true;
                                continue;
                            }
                        default:
                            for (int i = 0; i < key.Length; i++)
                            {
                                if ((indexesRest.Contains(i)) && (key[i] != morphCombination[i])) continue;
                                {
                                    correct = false;
                                    break;
                                }
                            }
                            if (correct) return line[key][0];
                            else
                            {
                                correct = true;
                                continue;
                            }
                    }*/
