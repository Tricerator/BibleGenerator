using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestBibleGenerator
{
    [TestClass]
    public class CreateFiles: BiblickyGenerator.FileManager
    {
        [TestMethod]
        public void TestCreateFilesWhenAlreadyCreated()
        {
            Assert.AreEqual(true,ManageDirectories());
        }
        public void TestCreateFilesWhenNotThere()
        {
            Assert.AreEqual(true, ManageDirectories());
        }


    }
}
