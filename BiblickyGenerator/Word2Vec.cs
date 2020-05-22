using System;
using System.IO;
using Word2Vec.Net;
using Word2vec.Tools;
using System.Collections.Generic;

namespace BiblickyGenerator
{
    class Word2Vec
    {
        /// <summary>
        /// This part trains model 
        /// </summary>
        /// <author>
        /// This method with libraries in Word2Vec.Net-master was programmed by GitHub user Eabdullin
        /// link to GitHub: https://github.com/eabdullin/Word2Vec.Net
        /// </author>
        /// <param name="trainfile">This file is located in SourceTXT folder</param>



        public static void TrainModel(string trainfile, int sizeOfVectors = 100, int minCount = 5, int iterations = 5)
        {
            string outputFileName = DirectoryManager.GetSpecifiedDirectory("Models") + DirectoryManager.sep + Path.GetFileName(trainfile);


            var word2Vec = Word2VecBuilder.Create()
                    .WithTrainFile(trainfile)// Use text data to train the model;
                    .WithOutputFile(outputFileName)//Use to save the resulting word vectors / word clusters
                    .WithSize(sizeOfVectors)//Set size of word vectors; default is 100
                    .WithDebug(2)//Set the debug mode (default = 2 = more info during training)
                    .WithCBow(1)//Use the continuous bag of words model; default is 1 (use 0 for skip-gram model)
                    .WithAlpha(0.05f)//Set the starting learning rate; default is 0.025 for skip-gram and 0.05 for CBOW
                    .WithSample((float)1e-3)//Set threshold for occurrence of words. 
                    .WithHs(0)//Use Hierarchical Softmax; default is 0 (not used)
                    .WithNegative(5)//Number of negative examples; default is 5, common values are 3 - 10 (0 = not used)
                    .WithThreads(12)//Use <int> threads (default 12)
                    .WithIter(iterations)//Run more training iterations (default 5)
                    .WithMinCount(minCount)//This will discard words that appear less than <int> times; default is 5
                    .Build();

            word2Vec.TrainModel();



        }


        /// <summary>
        /// This method generates synonyms
        /// </summary>
        /// <author>
        /// This code with libraries in TOOLSWord2vec.Tools-master
        /// was programmed by GitHub user: GuntaButya
        /// Link to GitHub code: https://github.com/GuntaButya/Word2Vec.Net-CSharp
        /// </author>
        /// <param name="path">This file is located in Models file</param>


        public static Dictionary<string, string> UseWord2Vec(string path, string[] words)
        {

            Dictionary<string, string> replacedWords = new Dictionary<string, string>();
            var vocabulary = new Word2VecTextReader().Read(path);

            foreach (string word in words)
            {
                int count = 10;
             
                var closest = vocabulary.Distance(word, count);

                foreach (var neightboor in closest)
                {
                    if ((neightboor.Representation.WordOrNull.ToLower() == neightboor.Representation.WordOrNull) && 
                        (neightboor.Representation.WordOrNull != null) && 
                        (
                            (word.StartsWith("ne") && neightboor.Representation.WordOrNull.StartsWith("ne")) ||
                            (!word.StartsWith("ne") && !neightboor.Representation.WordOrNull.StartsWith("ne"))
                        )
                        )
                    {
                        if(!replacedWords.ContainsKey(word))  replacedWords.Add(word, neightboor.Representation.WordOrNull);
                        break;
                    }
                }
            }
            return replacedWords;
        }
    }
}

