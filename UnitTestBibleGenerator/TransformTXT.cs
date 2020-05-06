using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace UnitTestBibleGenerator
{
    /// <summary>
    /// Test of transforming file for dangerous characters (interpunction etc...)
    /// </summary>
    [TestClass]
    public class TestingTransformTXT : BiblickyGenerator.TransformTXTFile
    {

        /// <summary>
        /// It works even for languages as Hebrew 
        /// </summary>
        [TestMethod]
        public void TestFromDangerToNormal()
        {

            string someString = "`1234567890-;'[p=0-=098\"097654~!@#$%^&*()_";
            Assert.AreEqual(someString, TransformStringBack(TransformString(someString)));
            string answer = TransformStringBack(" .  .  . ");
            Assert.AreEqual("...", answer);
            answer = TransformStringBack(" . ppkj . 56 # ");
            Assert.AreEqual(".ppkj.56#", answer);

            answer = ".בְּרֵאשִׁית.";
            Assert.AreEqual(" . בְּרֵאשִׁית . ", TransformString(answer));

            answer = "В начале сотворил Бог небо и землю.";
            Assert.AreEqual("В начале сотворил Бог небо и землю . ", TransformString(answer));
        }

    }
}
