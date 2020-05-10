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
        public void testCreateFilesWhenAlreadyCreated()
        {
            Assert.AreEqual(true,manageDirectories());
        }
        public void testCreateFilesWhenNotThere()
        {
            Assert.AreEqual(true, manageDirectories());
        }


    }
}
