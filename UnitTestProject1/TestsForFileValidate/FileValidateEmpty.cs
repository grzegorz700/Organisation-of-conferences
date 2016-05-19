using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfEF6MainPOApp.Model.RawModel;
using System.IO;

namespace UnitTestProject1.FileValidate
{
    [TestClass]
    public class FileValidateEmpty
    {
        private static string relafivePath = @"../../Items\";

        [TestMethod]
        public void TestMetodEmptyTxt()
        {
            Assert.IsFalse(UtuilsForValidates("Pusty.txt"));
        }

        [TestMethod]
        public void TestMetodEmptyDoc()
        {
            Assert.IsFalse(UtuilsForValidates("Pusty.doc"));
        }

        [TestMethod]
        public void TestMetodEmptyDocx()
        {
            Assert.IsFalse(UtuilsForValidates("Pusty.docx"));
        }

        [TestMethod]
        public void TestMetodEmptyPdf()
        {
            Assert.IsFalse(UtuilsForValidates("Pusty.pdf"));
        }

        [TestMethod]
        public void TestMetodEmptyDvi()
        {
            Assert.IsFalse(UtuilsForValidates("Pusty.dvi"));
        }

        [TestMethod]
        public void TestMetodEmptyDiferentExtension()
        {
            Assert.IsFalse(UtuilsForValidates("Pusty.ttx"));
        }


        private bool UtuilsForValidates(string fileName)
        {
            FileInfo file = new FileInfo(relafivePath + fileName);
            System.Diagnostics.Debug.WriteLine(file.FullName);
            return Artykul.FileValidate(file.FullName);
        }



    }
}
