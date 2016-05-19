using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfEF6MainPOApp.Model.RawModel;
using System.IO;

namespace UnitTestProject1.FileValidate
{
    [TestClass]
    public class FileValidateNormal
    {
        private static string relafivePath = @"../../Items\";

        [TestMethod]
        public void TestMetodNormalTxt()
        {
            Assert.IsTrue(UtuilsForValidates("pan-tadeusz.txt"));
        }

        [TestMethod]
        public void TestMetodNormalDoc()
        {
            Assert.IsTrue(UtuilsForValidates("pan-tadeusz.doc"));
        }

        [TestMethod]
        public void TestMetodNormalDocx()
        {
            Assert.IsTrue(UtuilsForValidates("pan-tadeusz.docx"));
        }

        [TestMethod]
        public void TestMetodNormalPdf()
        {
            Assert.IsTrue(UtuilsForValidates("pan-tadeusz.pdf"));
        }

        [TestMethod]
        public void TestMetodNormalDvi()
        {
            Assert.IsTrue(UtuilsForValidates("pan-tadeusz.dvi"));
        }

        [TestMethod]
        public void TestMetodNormalDiferentExtension()
        {
            Assert.IsFalse(UtuilsForValidates("pan-tadeusz.mobi"));
        }

        private bool UtuilsForValidates(string fileName)
        {
            FileInfo file = new FileInfo(relafivePath + fileName);
            System.Diagnostics.Debug.WriteLine(file.FullName);
            return Artykul.FileValidate(file.FullName);
        }

    }
}
