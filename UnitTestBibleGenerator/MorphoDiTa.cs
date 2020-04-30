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
        public void TestGetsJsonResultValute()
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

    }
}
