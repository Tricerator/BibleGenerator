using System;
using System.IO;
using Word2Vec.Net;
using Word2vec.Tools;


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



        public static void trainModel(string trainfile, int sizeOfVectors = 100, int minCount = 5, int iterations = 5)
        {
            string outputFileName =  Path.GetDirectoryName(trainfile) + "\\..\\" +
            "Models\\" + Path.GetFileName(trainfile);


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


        static void UseWord2Vec(string path)
        {

        
            var vocabulary = new Word2VecTextReader().Read(path);

            Console.WriteLine("vectors file: " + path);
            Console.WriteLine("vocabulary size: " + vocabulary.Words.Length);
            Console.WriteLine("w2v vector dimensions count: " + vocabulary.VectorDimensionsCount);

            Console.WriteLine();


            while (true)
            {
                int count = 7;
                Console.Write("Enter the main word: ");

                string word = Console.ReadLine();

                /*   Console.Write("Enter the second word: ");
                     string anotherWord = Console.ReadLine();

                     Console.Write("Enter the third word: ");

                     string thirdWord = Console.ReadLine();


                  */

                #region distance

                int actualCount = 1;

                Console.WriteLine("top " + actualCount + " closest to \"" + word + "\" words:");
                var closest = vocabulary.Distance(word, count);

                // Is simmilar to:
                // var closest = vocabulary[boy].GetClosestFrom(vocabulary.Words.Where(w => w != vocabulary[boy]), count);

                foreach (var neightboor in closest)
                    // --                 if (actualCount < 15)
                    // --               {
                    if (neightboor.Representation.WordOrNull.ToLower() == neightboor.Representation.WordOrNull)
                        Console.WriteLine(neightboor.Representation.WordOrNull + "\t\t" + neightboor.DistanceValue);
                //               actualCount++;
                //             }
                //              else break;
                #endregion

                Console.WriteLine();
                /*
                #region analogy

                actualCount = 1;
                Console.WriteLine("\"" + anotherWord + "\" relates to \"" + word + "\" as \"" + thirdWord + "\" relates to ...");
                var analogies = vocabulary.Analogy(anotherWord, word, thirdWord, count);
                foreach (var neightboor in analogies)
                    if ((actualCount < 35) && (neightboor.Representation.WordOrNull == neightboor.Representation.WordOrNull.ToLower()))
                    {

                        Console.WriteLine(neightboor.Representation.WordOrNull + "\t\t" + neightboor.DistanceValue);
                        actualCount++;
                    }
                    else break;
               #endregion

                Console.WriteLine();
               #region addition
                            Console.WriteLine("\"" + word + "\" + \"" + anotherWord + "\" = ...");
                            var additionRepresentation = vocabulary[word].Add(vocabulary[anotherWord]);
                            var closestAdditions = vocabulary.Distance(additionRepresentation, count);
                            foreach (var neightboor in closestAdditions)
                                Console.WriteLine(neightboor.Representation.WordOrNull + "\t\t" + neightboor.DistanceValue);
                            #endregion

                            Console.WriteLine();

                            #region subtraction
                            Console.WriteLine("\"" + word + "\" - \"" + anotherWord + "\" = ...");
                            var subtractionRepresentation = vocabulary[word].Substract(vocabulary[anotherWord]);
                            var closestSubtractions = vocabulary.Distance(subtractionRepresentation, count);
                            foreach (var neightboor in closestSubtractions)
                                Console.WriteLine(neightboor.Representation.WordOrNull + "\t\t" + neightboor.DistanceValue);
                #endregion
                */
           /*     Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            */

                /*


                            var distance = new Distance(outputFileName);
                            BestWord[] bestwords = distance.Search("Nulla");
                            Console.WriteLine(bestwords.GetLength(0));

                            Console.WriteLine("_________________________________________________");
                  */

                /* foreach (BestWord bs in bestwords)
                {
                    bs.ToString();
                        }
                        */

            }
        }
    }
}
