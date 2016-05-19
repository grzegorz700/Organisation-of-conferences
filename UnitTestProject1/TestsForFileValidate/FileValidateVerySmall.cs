using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfEF6MainPOApp.Model.RawModel;
using System.IO;

namespace UnitTestProject1.FileValidate
{
    [TestClass]
    public class FileValidateVerySmall
    {
        private static string relafivePath = @"../../Items\";

        [TestMethod]
        public void TestMetodVerySmallTxt()
        {
            Assert.IsTrue(UtuilsForValidates("1KB.txt"));
        }

        [TestMethod]
        public void TestMetodVerySmallDoc()
        {
            Assert.IsTrue(UtuilsForValidates("1KB.doc"));
        }

        [TestMethod]
        public void TestMetodVerySmallDocx()
        {
            Assert.IsTrue(UtuilsForValidates("1KB.docx"));
        }

        [TestMethod]
        public void TestMetodVerySmallPdf()
        {
            Assert.IsTrue(UtuilsForValidates("1KB.pdf"));
        }

        [TestMethod]
        public void TestMetodVerySmallDvi()
        {
            Assert.IsTrue(UtuilsForValidates("1KB.dvi"));
        }

        [TestMethod]
        public void TestMetodVerySmallDiferentExtension()
        {
            Assert.IsFalse(UtuilsForValidates("1KB.odt"));
        }

        private bool UtuilsForValidates(string fileName)
        {
            FileInfo file = new FileInfo(relafivePath + fileName);
            System.Diagnostics.Debug.WriteLine(file.FullName);
            return Artykul.FileValidate(file.FullName);
        }

    }
}
