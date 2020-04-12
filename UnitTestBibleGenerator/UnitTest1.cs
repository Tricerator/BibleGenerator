using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace UnitTestBibleGenerator
{
    [TestClass]
    public class TestingTransformTXT : BiblickyGenerator.TransformTXTFile
    {
        [TestMethod]
        public void TestFromDangerToNormal()
        {

            string someString = "`1234567890-;'[p=0-=098\"097654~!@#$%^&*()_";
            Assert.AreEqual(someString, TransformStringBack(TransformString(someString)));
            string answer = TransformStringBack(" .  .  . ");
            Assert.AreEqual("...", answer);
            answer = TransformStringBack(" . ppkj . 56 # ");
            Assert.AreEqual(".ppkj.56#", answer);
        }
      
    }
}
