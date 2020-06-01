using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblickyGenerator
{
    public class ParaphraseText
    {

        public static string Paraphrase(string input, string model, bool morphoDiTa)
        {
            string output = "";

            string normalizeString = TransformTXTFile.TransformString(input);
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
            Dictionary<string, string> replacedWords = Word2Vec.UseWord2Vec(model, rightWords.ToArray());

            //   window.clear();

            if (morphoDiTa)
            {
                output = MorphoDiTa.UseMorphoDiTa(input, replacedWords);
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (string word in words)
                {
                    if (replacedWords.ContainsKey(word))
                    {
                        string tempWord = replacedWords[word];
                        char c = TransformTXTFile.ContainsDangerousChar(tempWord);
                        if ((word.Length <= 1) || (c == 'n'))
                        {
                            sb.Append(replacedWords[word] + " ");
                        }
                        else
                        {
                            string[] tempWords = tempWord.Split(c);
                            if (tempWords[0].Length > tempWords[1].Length) sb.Append(tempWords[0] + " ");
                            else sb.Append(tempWords[1] + " ");
                        }
                    }
                    else sb.Append(word + " ");
                }
                output = sb.ToString();

            }
            output = TransformTXTFile.TransformStringBack(output);

            return output;
        }
    }
}
