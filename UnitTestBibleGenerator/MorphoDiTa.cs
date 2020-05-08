using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestBibleGenerator
{
    [TestClass]
    public class MorphoDiTa : BiblickyGenerator.MorphoDiTa
    {
      
        [TestMethod]
        public void TestGetsJsonGenerateResultValute()
        {
            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data=člověk";
            string data = getUrlAnswer(url);
            string a = getResultJsonOutputInGenerate(data);
            string myResult = @"lidi\tčlověk\tNNMP1-----A----\tlidi\tčlověk\tNNMP4-----A----\tlidi\tčlověk\tNNMP5-----A----\tlidma\tčlověk\tNNMP7-----A---7\tlidmi\tčlověk\tNNMP7-----A----\tlidem\tčlověk\tNNMP3-----A----\tlidé\tčlověk\tNNMP1-----A---1\tlidé\tčlověk\tNNMP5-----A---1\tlidí\tčlověk\tNNMP2-----A----\tlidech\tčlověk\tNNMP6-----A----\tčlověk\tčlověk\tNNMS1-----A----\tčlověka\tčlověk\tNNMS2-----A----\tčlověka\tčlověk\tNNMS4-----A----\tčlověku\tčlověk\tNNMS3-----A----\tčlověku\tčlověk\tNNMS6-----A----\tčlověče\tčlověk\tNNMS5-----A----\tčlověkem\tčlověk\tNNMS7-----A----\tčlověkovi\tčlověk\tNNMS3-----A---1\tčlověkovi\tčlověk\tNNMS6-----A---1\tčlověkům\tčlověk_,h\tNNMP3-----A---6\tčlověkama\tčlověk_,h\tNNMP7-----A---6\tčlověkách\tčlověk_,h\tNNMP6-----A---6\tčéče\tčlověk_,h\tNNMS5-----A---1";
            Assert.AreEqual(myResult, a);


            string word = "člověk";
            url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data="
            + word;
             data = getUrlAnswer(url);
             a = getResultJsonOutputInGenerate(data);
             myResult = @"lidi\tčlověk\tNNMP1-----A----\tlidi\tčlověk\tNNMP4-----A----\tlidi\tčlověk\tNNMP5-----A----\tlidma\tčlověk\tNNMP7-----A---7\tlidmi\tčlověk\tNNMP7-----A----\tlidem\tčlověk\tNNMP3-----A----\tlidé\tčlověk\tNNMP1-----A---1\tlidé\tčlověk\tNNMP5-----A---1\tlidí\tčlověk\tNNMP2-----A----\tlidech\tčlověk\tNNMP6-----A----\tčlověk\tčlověk\tNNMS1-----A----\tčlověka\tčlověk\tNNMS2-----A----\tčlověka\tčlověk\tNNMS4-----A----\tčlověku\tčlověk\tNNMS3-----A----\tčlověku\tčlověk\tNNMS6-----A----\tčlověče\tčlověk\tNNMS5-----A----\tčlověkem\tčlověk\tNNMS7-----A----\tčlověkovi\tčlověk\tNNMS3-----A---1\tčlověkovi\tčlověk\tNNMS6-----A---1\tčlověkům\tčlověk_,h\tNNMP3-----A---6\tčlověkama\tčlověk_,h\tNNMP7-----A---6\tčlověkách\tčlověk_,h\tNNMP6-----A---6\tčéče\tčlověk_,h\tNNMS5-----A---1";
            Assert.AreEqual(myResult, a);

            word = "člověkano4";
            url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data=" + word;
            data = getUrlAnswer(url);
            a = getResultJsonOutputInGenerate(data);
            myResult = ""; 
            Assert.AreEqual(myResult, a);

            word = "aaaaaa";
            url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data=" + word;
            data = getUrlAnswer(url);
            a = getResultJsonOutputInGenerate(data);
            myResult = "";
            Assert.AreEqual(myResult, a);

            word = "";
            url = "http://lindat.mff.cuni.cz/services/morphodita/api/generate?data=" + word;
            data = getUrlAnswer(url);
            a = getResultJsonOutputInGenerate(data);
            myResult = "";
            Assert.AreEqual(myResult, a);
        }

        [TestMethod]
        public void TestGetsJsonTokenizeValue()
        {



            string url = "http://lindat.mff.cuni.cz/services/morphodita/api/tag?data=&vertical";
            string data = getUrlAnswer(url);
            string a = getResultJsonVariableFromTagging(data);
            string myResult = "";
            Assert.AreEqual(myResult, a);



            string sentence = "Děti pojedou k babičce. ";
            url = "http://lindat.mff.cuni.cz/services/morphodita/api/tag?data=" + sentence.Replace(" ","%20") + "&output=vertical";
            data = getUrlAnswer(url);
            a = getResultJsonVariableFromTagging(data);
            myResult = @"Děti\tdítě\tNNFP1-----A----\npojedou\tjet-1_^(pohybovat_se,_ne_však_chůzí)\tVB-P---3F-AA---\nk\tk-1\tRR--3----------\nbabičce\tbabička\tNNFS3-----A----\n.\t.\tZ:-------------\n\n";
            Assert.AreEqual(myResult, a);


        }


        [TestMethod]
        public void TestAnalyzeSentenceAndReturnDictionary()
        {
            string sentence = "";
            Dictionary<string, string[]> dict = analyzeSentenceAndReturnDictionary(sentence);
            Assert.AreEqual(null, dict);


            sentence = "Děti pojedou k babičce. ";
            dict = new Dictionary<string, string[]>();
            dict = analyzeSentenceAndReturnDictionary(sentence);
            Dictionary<string, string[]> ideal = new Dictionary<string, string[]>();
            string[] values1 = { "dítě", "NNFP1-----A----" };
            ideal.Add("děti", values1);


            string[] values2 = { "jet-1_^(pohybovat_se,_ne_však_chůzí)", "VB-P---3F-AA---" } ;
            ideal.Add("pojedou", values2);

            string[] values3 = { "k-1", "RR--3----------" };
            ideal.Add("k", values3);

            string[] values4 = { "babička", "NNFS3-----A----" };
            ideal.Add("babičce", values4);

            string[] values5 = { ".", "Z:-------------" };
            ideal.Add(".", values5);
            
            foreach(var key in ideal.Keys)
            {
                for(int i = 0; i < ideal[key].Length; i++)
                {
                    Assert.AreEqual(ideal[key][i], dict[key][i]);
                }
            }
        }








        [TestMethod]
        public void TestUseMorphoDiTaNouns() 
        {
            
            {
                string sentence1 = "Moje děti jí malinu";
                string answer1 = "Moje děti jí párek";
                Dictionary<string, string> testDict1 = new Dictionary<string, string>();
                testDict1.Add("malinu", "párek");
                string answer2 = useMorphoDiTa(sentence1, testDict1);
                Assert.AreEqual(answer1, answer2);

                testDict1["malinu"] = "párkem";
                Assert.AreEqual(answer1, useMorphoDiTa(sentence1, testDict1));

                testDict1["malinu"] = "párkem";
                Assert.AreEqual(answer1, useMorphoDiTa(sentence1, testDict1));

                testDict1["malinu"] = "párky";
                Assert.AreEqual(answer1, useMorphoDiTa(sentence1, testDict1));

                testDict1["malinu"] = "párků";
                Assert.AreEqual(answer1, useMorphoDiTa(sentence1, testDict1));

                testDict1["malinu"] = "párkách";
                Assert.AreEqual(answer1, useMorphoDiTa(sentence1, testDict1));

            }
            

        }


        [TestMethod]
        public void TestUseMorphoDiTaVerbs()
       {
        string sentence = "Šel jsem běhat";
        string answer = "Šel jsem zpívat";

        Dictionary<string, string> TestDict1 = new Dictionary<string, string>();
        TestDict1.Add("běhat", "zpívat");
        //        Assert.AreEqual(answer, useMorphoDiTa(sentence, TestDict1));
            }


}
}
